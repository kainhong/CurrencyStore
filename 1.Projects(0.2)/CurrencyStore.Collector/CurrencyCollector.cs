using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CurrencyStore.DataPackage;

namespace CurrencyStore.Collector
{
    public class CurrencyCollector
    {
        private SocketServer LocalSocketServer { get; set; }
        private int terminalCount = 0;
        public int TerminalCount { get { return this.terminalCount; } }
        private int heartbeatCount = 0;
        public int HeartbeatCount { get { return this.heartbeatCount; } }
        private int loginCount = 0;
        public int LoginCount { get { return this.loginCount; } }
        private int blacklistQueryCount = 0;
        public int BlacklistQueryCount { get { return this.blacklistQueryCount; } }
        private int blacklistDownloadCount = 0;
        public int BlacklistDownloadCount { get { return this.blacklistDownloadCount; } }
        private int currencyCount = 0;
        public int CurrencyCount { get { return this.currencyCount; } }

        public CurrencyCollector()
        {
            this.LocalSocketServer = new SocketServer();
            this.LocalSocketServer.Socket_Accepted += new EventHandler(this.Accepted_Handler);
            this.LocalSocketServer.Socket_DataReceived += new EventHandler<SocketEventArgs>(this.DataReceived_Handler);
            this.LocalSocketServer.Run(8234, 4000);
        }
        private void Accepted_Handler(object sender, EventArgs e)
        {
            Interlocked.Increment(ref this.terminalCount);
        }
        private void DataReceived_Handler(object sender, SocketEventArgs e)
        {
            if (e.Data.Sum() > 0)
            {
                Datagram requestDatagram = DatagramResolver.ResolveRequest(e.Data);
                Datagram responseDatagram = null;

                if (requestDatagram != null)
                {
                    if (requestDatagram.Type == DatagramTypeEnum.HeartbeatRequest)
                    {
                        this.heartbeatCount = Interlocked.Increment(ref this.heartbeatCount);

                        responseDatagram = this.ProcessHeartbeat(requestDatagram);
                    }

                    if (requestDatagram.Type == DatagramTypeEnum.LoginRequest)
                    {
                        this.loginCount = Interlocked.Increment(ref this.loginCount);

                        responseDatagram = this.ProcessLogin(requestDatagram);
                    }

                    if (requestDatagram.Type == DatagramTypeEnum.BlacklistQueryRequest)
                    {
                        this.blacklistQueryCount = Interlocked.Increment(ref this.blacklistQueryCount);

                        responseDatagram = this.ProcessBlacklistQuery(requestDatagram);
                    }

                    if (requestDatagram.Type == DatagramTypeEnum.BlacklistDownloadRequest)
                    {
                        this.blacklistDownloadCount = Interlocked.Increment(ref this.blacklistDownloadCount);

                        responseDatagram = this.ProcessBlacklistDownload(requestDatagram);
                    }

                    if (requestDatagram.Type == DatagramTypeEnum.CurrencyRequest)
                    {
                        this.currencyCount = Interlocked.Increment(ref this.currencyCount);

                        responseDatagram = this.ProcessCurrency(requestDatagram);
                    }

                    this.LocalSocketServer.BeginSend(e.Socket, responseDatagram.FullDatagram);
                }
            }
        }
        private Datagram ProcessHeartbeat(Datagram requestDatagram)
        {
            Datagram result = Datagram.GetResponse(requestDatagram);

            result.FullDatagram = new byte[] { 0xAA, 0xBB, 0x00, 0x08, 0xA0, 0x01, 0x00, 0x00 };

            return result;
        }
        private Datagram ProcessLogin(Datagram requestDatagram)
        {
            Datagram result = Datagram.GetResponse(requestDatagram);

            result.FullDatagram = new byte[] { 0xAA, 0xBB, 0x00, 0x10, 0xA0, 0x03, 0x00, 0x0C, 0x05, 0x10, 0x08, 0x09, 0x0A, 0x00, 0x00, 0x00 };

            return result;
        }
        private Datagram ProcessBlacklistQuery(Datagram requestDatagram)
        {
            Datagram result = Datagram.GetResponse(requestDatagram);

            result.FullDatagram = new byte[] { 0xAA, 0xBB, 0x00, 0x0D, 0xA0, 0x05, 0x0C, 0x05, 0x02, 0x00, 0x64, 0x00, 0x00 };

            return result;
        }
        private Datagram ProcessBlacklistDownload(Datagram requestDatagram)
        {
            Datagram result = Datagram.GetResponse(requestDatagram);

            result.FullDatagram = new byte[] { 0xAA, 0xBB, 0x00, 0x1A, 0xA0, 0x06, 0x00, 0x00, 0x64, 0x07, 0xD5, (byte)'H', (byte)'D', (byte)'1', (byte)'2', (byte)'3', (byte)'4', (byte)'5', (byte)'6', (byte)'7', (byte)'8', 0x00, 0x00, 0x00 };

            return result;
        }
        private Datagram ProcessCurrency(Datagram requestDatagram)
        {
            Datagram result = Datagram.GetResponse(requestDatagram);

            result.FullDatagram = new byte[] { 0xAA, 0xBB, 0x00, 0x09, 0xA0, 0x0A, 0x00, 0x00, 0x00 };

            return result;
        }
    }
}
