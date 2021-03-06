﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using CurrencyStore.Common;
using CurrencyStore.Common.Configration;
using CurrencyStore.Communication.ExtensionMethods;
using CurrencyStore.Communication.Securtiy;

namespace CurrencyStore.Communication
{
    /// <summary>
    /// Represents a callback used to inform a listener that a ServerConnection has received data.
    /// </summary>
    /// <param name="sender">The sender of the callback.</param>
    /// <param name="e">The DataEventArgs object containging the received data.</param>
    public delegate void DataReceivedCallback(ServerConnection sender, DataEventArgs e);
    /// <summary>
    /// Represents a callback used to inform a listener that a ServerConnection has disconnected.
    /// </summary>
    /// <param name="sender">The sender of the callback.</param>
    /// <param name="e">The SocketAsyncEventArgs object used by the ServerConnection.</param>
    public delegate void DisconnectedCallback(ServerConnection sender, SocketAsyncEventArgs e);

    /// <summary>
    /// A connection to our server.
    /// </summary>
    public class ServerConnection
    {
        #region Internal Classes
        internal class State
        {
            public DataReceivedCallback dataReceived;
            public DisconnectedCallback disconnectedCallback;
            public Socket socket;
            public Device Device;
            public byte[] Buffer;
        }
        #endregion

        #region Fields
        public AuthorizationType AuthorizationType { get; set; }


        private SocketAsyncEventArgs eventArgs;

        ElibLogging logger;
        #endregion

        #region Constructor
        /// <summary>
        /// A connection to our server, always listening asynchronously.
        /// </summary>
        /// <param name="socket">The Socket for the connection.</param>
        /// <param name="args">The SocketAsyncEventArgs for asyncronous recieves.</param>
        /// <param name="dataReceived">A callback invoked when data is recieved.</param>
        /// <param name="disconnectedCallback">A callback invoked on disconnection.</param>
        public ServerConnection(Socket socket, SocketAsyncEventArgs args, DataReceivedCallback dataReceived,
            DisconnectedCallback disconnectedCallback)
        {
            logger = new ElibLogging("data");
            this.AuthorizationType = Securtiy.AuthorizationType.Anonymous;
            lock (this)
            {
                var remotIP = socket.RemoteEndPoint as IPEndPoint;
                var localIP = socket.LocalEndPoint as IPEndPoint;
                State state = new State()
                {
                    socket = socket,
                    dataReceived = dataReceived,
                    disconnectedCallback = disconnectedCallback,
                    Device = new Device()
                    {
                        RemoteIP = remotIP.Address.ToString(),
                        LocalIP = localIP.Address.ToString()
                    }
                };

                eventArgs = args;
                eventArgs.Completed += ReceivedCompleted;
                eventArgs.UserToken = state;

                ListenForData(eventArgs);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Disconnects the client.
        /// </summary>
        public void Disconnect()
        {
            lock (this)
            {
                CloseConnection(eventArgs);
            }
        }

        /// <summary>
        /// Sends data to the client.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="offset">The offset into the data.</param>
        /// <param name="count">The ammount of data to send.</param>
        public void SendData(Byte[] data, Int32 offset, Int32 count)
        {
            lock (this)
            {
                State state = eventArgs.UserToken as State;
                Socket socket = state.socket;
                if (socket.Connected)
                    try
                    {
                        socket.Send(data, offset, count, SocketFlags.None);
                    }
                    catch (SocketException se)
                    {
                        if (se.ErrorCode > 0)
                        {
                            Disconnect();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }

            }
        }


        #endregion

        #region Private Methods
        /// <summary>
        /// Starts and asynchronous recieve.
        /// </summary>
        /// <param name="args">The SocketAsyncEventArgs to use.</param>
        private void ListenForData(SocketAsyncEventArgs args)
        {
            lock (this)
            {
                Socket socket = (args.UserToken as State).socket;
                if (socket.Connected)
                {
                    socket.InvokeAsyncMethod(socket.ReceiveAsync,
                        ReceivedCompleted, args);
                }
            }
        }

        /// <summary>
        /// Called when an asynchronous receive has completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The SocketAsyncEventArgs for the operation.</param>
        private void ReceivedCompleted(Object sender, SocketAsyncEventArgs args)
        {

            if (args.BytesTransferred == 0)
            {
                CloseConnection(args); //Graceful disconnect
                return;
            }
            if (args.SocketError != SocketError.Success)
            {
                CloseConnection(args); //NOT graceful disconnect
                return;
            }

            State state = args.UserToken as State;
            Byte[] tmp = new Byte[args.BytesTransferred];
            Array.Copy(args.Buffer, args.Offset, tmp, 0, tmp.Length);
            try
            {
                foreach (var data in UnPackage(state, tmp, tmp.Length))
                {
                    OnDataReceived(data, args.RemoteEndPoint as IPEndPoint, state);
                }
            }
            catch (InvalideDataException)
            {
                //throw;
            }
            catch (Exception ex)
            {
                var txt = tmp.ToHexString();
                logger.Error(txt);
                CurrencyStore.Common.ElibExceptionHandler.Handle(ex);
            }
            ListenForData(args);
        }

        private int GetPackageLength(byte[] buff, int index = 2)
        {
            var len = buff.ReadShort(index);
            return len;
        }

        private IEnumerable<byte[]> UnPackage(State state, byte[] data, int length)
        {
            var index = 0;
            if (data.Length > 2 && data[0] == 0xAA && data[1] == 0xBB)
            {
                if (state.Buffer != null)//修正，防止上次数据污染
                    state.Buffer = null;
                var len = GetPackageLength(data);
                if (len == length)
                {
                    index = length;
                    var result = new byte[len];
                    Array.Copy(data, result, length);
                    yield return result;
                }
            }
            else if (data.Length > 2 && state.Buffer == null)
            {
                var j = FindHeader(data, 0);
                if (j > 0)
                {
                    var temp = new byte[data.Length - j];
                    Array.Copy(data, j, temp, 0, temp.Length);
                    data = temp;
                    length = temp.Length;
                }
            }
            if (index < length)
            {
                byte[] buffer;
                buffer = new byte[length + (state.Buffer == null ? 0 : state.Buffer.Length)];
                if (state.Buffer != null)
                    Array.Copy(state.Buffer, buffer, state.Buffer.Length);

                Array.Copy(data, 0, buffer, state.Buffer == null ? 0 : state.Buffer.Length, length);

                while (index < buffer.Length - 1)
                {
                    var len = 0;
                    index = FindHeader(buffer, index);
                    if (index < 0)
                    {
                        state.Buffer = null;//错误的数据，清除上次保留的剩余数据
                        break;
                    }
                    else if (index + 2 >= buffer.Length)//剩余数据刚好是AABB
                    {
                        state.Buffer = new byte[] { 0xAA, 0xBB };
                        break;
                    }
                    len = GetPackageLength(buffer, index + 2);
                    if ((index + len) > buffer.Length)
                    {
                        len = buffer.Length - index;
                        var result = new byte[len];
                        Array.Copy(buffer, index, result, 0, len);
                        state.Buffer = result;
                        break;
                    }
                    else
                    {
                        var result = new byte[len];
                        Array.Copy(buffer, index, result, 0, len);
                        index += len;
                        if (index == buffer.Length)
                            state.Buffer = null;
                        yield return result;
                    }
                }
            }

            //if (buff == null)
            //{
            //    var packageLength = GetPackageLength(buffer);
            //    if (packageLength > buffer.Length)
            //    {
            //        buff = buffer;
            //        return null;
            //    }
            //    if (packageLength == buffer.Length)
            //    {
            //        buff = null;
            //        return buffer;
            //    }
            //    if (packageLength < buffer.Length)
            //    {
            //        var temp = new byte[packageLength];
            //        Array.Copy(buffer, temp, packageLength);
            //        Array.Copy(buffer, packageLength, buff, 0, buff.Length - packageLength);
            //        return temp;
            //    }
            //}
            //else
            //{
            //    var packageLength = GetPackageLength(buff);

            //}
        }

        private int FindHeader(byte[] data, int index = 0)
        {
            var j = -1;
            for (int i = index; i < data.Length - 1; i++)
            {
                if (data[i] == 0xAA && data[i + 1] == 0xBB)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="args">The SocketAsyncEventArgs for the connection.</param>
        private void CloseConnection(SocketAsyncEventArgs args)
        {
            State state = args.UserToken as State;
            Socket socket = state.socket;
            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch { } // throws if client process has already closed
            socket.Close();
            socket = null;

            args.Completed -= ReceivedCompleted; //MUST Remember This!
            OnDisconnected(args, state.disconnectedCallback);
            state.Device.DisconnectionDate = DateTime.Now;
            state.Device.Connected = false;
            Unity.UpdateDeviceState(null, state.Device, true);
        }
        #endregion

        #region Events
        /// <summary>
        /// Fires the DataReceivedCallback.
        /// </summary>
        /// <param name="data">The data which was received.</param>
        /// <param name="remoteEndPoint">The address the data came from.</param>
        /// <param name="callback">The callback.</param>
        private void OnDataReceived(Byte[] data, IPEndPoint remoteEndPoint, State state)
        {
            state.dataReceived(this, new DataEventArgs()
            {
                RemoteEndPoint = remoteEndPoint,
                Device = state.Device,
                Data = data
            });
        }

        /// <summary>
        /// Fires the DisconnectedCallback.
        /// </summary>
        /// <param name="args">The SocketAsyncEventArgs for this connection.</param>
        /// <param name="callback">The callback.</param>
        private void OnDisconnected(SocketAsyncEventArgs args, DisconnectedCallback callback)
        {
            callback(this, args);
        }
        #endregion
    }
}