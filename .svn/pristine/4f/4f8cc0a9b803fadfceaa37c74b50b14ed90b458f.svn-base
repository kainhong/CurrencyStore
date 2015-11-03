using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CurrencyStore.Collector
{
    public class SocketListener
    {
        private Socket TcpSocket { get; set; }
        public bool IsListening { get; private set; }
        private SocketAsyncEventArgs SaeaAccept { get; set; }
        public event EventHandler<SocketEventArgs> Socket_Accepted;
        private AutoResetEvent wait = new AutoResetEvent(false);

        public SocketListener()
        {
            this.TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.TcpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);

            this.SaeaAccept = new SocketAsyncEventArgs();
            this.SaeaAccept.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
        }
        public void StartListen(int port, int maxConnectCount)
        {
            this.TcpSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            this.TcpSocket.Listen(maxConnectCount);

            this.IsListening = true;

            this.BeginAccept();

            wait.Set();
        }
        public void StopListen()
        {
            this.IsListening = false;

            if (this.TcpSocket != null)
            {
                this.TcpSocket.Close();
                this.TcpSocket.Dispose();
            }
        }
        private void BeginAccept()
        {
            if (this.IsListening)
            {
                wait.WaitOne();

                if (!this.TcpSocket.AcceptAsync(this.SaeaAccept))
                {
                    this.eCompleted(this.SaeaAccept);
                }
            }
        }
        void e_Completed(object sender, SocketAsyncEventArgs e)
        {
            eCompleted(e);
        }
        void eCompleted(SocketAsyncEventArgs e)
        {
            if (e.LastOperation == SocketAsyncOperation.Accept && e.SocketError == SocketError.Success)
            {
                Socket acceptSocket = e.AcceptSocket;

                e.AcceptSocket = null;

                wait.Reset();

                if (this.Socket_Accepted != null)
                {
                    this.Socket_Accepted(null, new SocketEventArgs() { Socket = acceptSocket });
                }
            }

            this.BeginAccept();
        }
    }
}
