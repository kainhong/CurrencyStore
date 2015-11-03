using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CurrencyStore.Collector
{
    public class SocketServer
    {
        private SocketListener LocalSocketListener { get; set; }
        public bool IsRunning { get { return this.LocalSocketListener.IsListening; } }
        private int BufferSize { get; set; }
        private SocketAsyncEventArgsPool LocalSaeaPool { get; set; }
        public event EventHandler Socket_Accepted;
        public event EventHandler<SocketEventArgs> Socket_DataReceived;
        public event EventHandler Socket_Disconnected;

        public SocketServer()
        {
            this.BufferSize = 512;

            this.LocalSocketListener = new SocketListener();
            this.LocalSocketListener.Socket_Accepted += new EventHandler<SocketEventArgs>(this.Accepted_Handler);
        }
        public void Run(int port, int maxConnectCout)
        {
            if (!this.IsRunning)
            {
                this.LocalSaeaPool = new SocketAsyncEventArgsPool();

                for (int i = 0; i < maxConnectCout; i++)
                {
                    SocketAsyncEventArgs saea = new XSocketAsyncEventArgs(this.BufferSize);
                    saea.Completed += new EventHandler<SocketAsyncEventArgs>(this.e_Completed);
                    this.LocalSaeaPool.Set(saea);
                }

                this.LocalSocketListener.StartListen(port, maxConnectCout);
            }
        }
        private void Accepted_Handler(object sender, SocketEventArgs e)
        {
            if (e.Socket.Connected)
            {
                if (this.Socket_Accepted != null)
                {
                    this.Socket_Accepted(null, null);
                }

                SocketAsyncEventArgs saea = this.LocalSaeaPool.Get();

                saea.AcceptSocket = e.Socket;
                saea.SetBuffer(0, this.BufferSize);

                if (!e.Socket.ReceiveAsync(saea))
                {
                    this.eCompleted(saea);
                }
            }
        }
        private void Disconnected_Handler()
        {

        }
        public void BeginSend(Socket objSocket, byte[] data)
        {
            if (objSocket != null && objSocket.Connected)
            {
                objSocket.BeginSend(data, 0, data.Length, SocketFlags.None, this.SendAsynCallBack, objSocket);
            }
        }
        void SendAsynCallBack(IAsyncResult result)
        {
            Socket objSocket = result.AsyncState as Socket;

            if (objSocket != null)
            {
                objSocket.EndSend(result);
            }
        }
        void e_Completed(object sender, SocketAsyncEventArgs e)
        {
            eCompleted(e);
        }
        void eCompleted(SocketAsyncEventArgs e)
        {
            if (e.LastOperation == SocketAsyncOperation.Receive)
            {
                if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
                {
                    byte[] data = new byte[e.BytesTransferred];

                    Buffer.BlockCopy(e.Buffer, 0, data, 0, data.Length);

                    if (this.Socket_DataReceived != null)
                    {
                        this.Socket_DataReceived(null, new SocketEventArgs() { Socket = e.AcceptSocket, Data = data });
                    }

                    e.SetBuffer(0, this.BufferSize);

                    if (e.AcceptSocket.Connected)
                    {
                        if (!e.AcceptSocket.ReceiveAsync(e))
                        {
                            eCompleted(e);
                        }
                    }
                }

                else
                {
                    e.AcceptSocket = null;

                    this.LocalSaeaPool.Set(e);
                }
            }
        }
    }
}
