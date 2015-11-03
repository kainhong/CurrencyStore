using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.Configration;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Communication.Server
{
    public sealed class SocketServer
    {
        static SocketArgsPool socketArgsPool;
        static BufferPool bufferManager;
        static Int32 connections = 0;
        static Int32 messages = 0;
        static Int32 bytes = 0;
        static Int32 currencies = 0;
        static bool allowAllowAnonymous = false;
        // DataProcessor processor = new DataProcessor();

        public int Connections
        {
            get { return connections; }
        }
        public int Messages
        {
            get { return messages; }
        }
        public int Currencies
        {
            get { return currencies; }
        }
        public int Bytes
        {
            get { return bytes; }
        }

        TcpSocketListener socketListener;

        static SocketServer()
        {
            var max = CurrencyStoreSection.Instance.Server.Buffer.MaxLength;
            var size = CurrencyStoreSection.Instance.Server.Buffer.Size;
            socketArgsPool = new SocketArgsPool(max);
            bufferManager = new BufferPool(max * size, size);
            allowAllowAnonymous = CurrencyStoreSection.Instance.Authorization.AllowAnonymous;
        }

        public void Start()
        {
            DeviceCache.Current.Init();
            BlackTableHelper.Load();
            ServerInstrumentation.Current.Init();

            if (File.Exists("data.txt"))
            {
                File.Delete("data.txt");
            }

            var port = CurrencyStoreSection.Instance.Server.Port;
            var queue = CurrencyStoreSection.Instance.Server.Backlog;

            socketListener = new TcpSocketListener(IPAddress.Any, port, queue);
            socketListener.SocketConnected += new EventHandler<SocketEventArgs>(SocketConnected);
            socketListener.Start();
            //processor.Start();
        }

        public void Stop()
        {
            socketListener.Stop();
            // processor.Stop();
        }

        public void Reset()
        {
            bytes = 0;
        }

        void SocketConnected(object sender, SocketEventArgs e)
        {
            Interlocked.Increment(ref connections);
            ServerInstrumentation.Current.Connect();
            SocketAsyncEventArgs args = socketArgsPool.CheckOut();
            bufferManager.CheckOut(args);
            var connection = new ServerConnection(e.Socket, args,
                new DataReceivedCallback(DataReceived),
                new DisconnectedCallback(Disconnected));
        }

        static void DataReceived(ServerConnection sender, DataEventArgs e)
        {
            try
            {
                HandleDataReceived(sender, e);
            }
            catch (Exception ex)
            {
                CurrencyStore.Common.ElibExceptionHandler.Handle(ex as Exception);
            }
        }

        static void HandleDataReceived(ServerConnection sender, DataEventArgs e)
        {
            /*
            Interlocked.Increment(ref currencies);

            byte[] temp = new byte[] { 0xAA, 0xBB, 0x00, 0x09, 0xA0, 0x0A, 0x00, 0x00, 0x00 };

            sender.SendData(temp, 0, temp.Length);

            return;
            */
            /**/

            byte[] datas = e.Data;
            Interlocked.Increment(ref messages);
            Interlocked.Add(ref bytes, datas.Length);

            var msg = Message.ConvertFrom(datas);
            //var line = e.Data.ToHexString();
            //File.AppendAllText("data.txt", line + Environment.NewLine);
            if (msg == null)
            {
                return;
            }

            if (msg.Datas == null)
            {
                msg.Datas = new byte[] { 0 };
            }

            byte flag = 0;

            if (msg.Command == (int)CommandType.Beep)
            {
                UpdateDeviceInfo(msg, e.Device);
            }

            else if (msg.Command == (int)CommandType.Login)
            {
                if (msg.Device == null)
                {
                    ServerInstrumentation.Current.LoginFailed();

                    if (!allowAllowAnonymous)
                    {
                        flag = 1;
                        sender.Disconnect();
                        return;
                    }
                }

                if (!allowAllowAnonymous || msg.Device != null)
                {
                    UpdateDeviceInfo(msg, e.Device);
                    sender.AuthorizationType = Securtiy.AuthorizationType.Authorized;
                }
            }

            else if (msg.Command == (int)CommandType.Detail)
            {
                Interlocked.Increment(ref currencies);

                if (!allowAllowAnonymous && sender.AuthorizationType == Securtiy.AuthorizationType.Anonymous)
                {
                    ServerInstrumentation.Current.Unregisted();

                    if (!allowAllowAnonymous)
                    {
                        sender.Disconnect();
                        return;
                    }
                }
                UpdateDeviceInfo(msg, e.Device);
                e.Device.Increate();
                if (msg.Currency != null)
                {
                    DataPool.Push(msg.Currency);
                }
            }

            else if (msg.Command == (int)CommandType.BlackTable)
            {

            }

            else if (msg.Command == (int)CommandType.DownLoadBlackTable)
            {

            }

            var data = msg.GetBytes(flag);
            sender.SendData(data, 0, data.Length);
        }

        static void UpdateDeviceInfo(Message msg, Device device)
        {
            if (!allowAllowAnonymous || msg.Device != null)
            {
                device.Connected = true;
                device.Number = msg.Device.DeviceNumber;
                Unity.UpdateDeviceState(msg.Device, device, false);
            }
        }

        static void Disconnected(ServerConnection sender, SocketAsyncEventArgs e)
        {
            Interlocked.Decrement(ref connections);
            ServerInstrumentation.Current.Disconnect();
            bufferManager.CheckIn(e);
            socketArgsPool.CheckIn(e);
        }
    }
}
