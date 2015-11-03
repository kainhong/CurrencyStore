using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CurrencyStore.DataPackage;

namespace CurrencyStore.Client
{
    public class CurrencyTerminal
    {
        private SocketClient LocalSocket { get; set; }
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public bool IsConnected { get { return this.LocalSocket.IsConnected; } }
        public string ConnectMessage { get; private set; }
        public string DeviceNumber { get; set; }
        public byte[] DeviceNumberHex { get; set; }
        public int TargetReconnectCount { get; set; }
        public int RealConnectCount { get; private set; }
        public int SendHeartbeatCount { get; private set; }
        public int SendLoginCount { get; private set; }
        public int TargetDownloadBlacklist { get; private set; }
        public bool IsFinishDownloadBlacklist { get; private set; }
        public int DownloadBlacklistCount { get; private set; }
        public int TargetCurrencyCount { get; set; }
        public int SendCurrencyCount { get; private set; }
        public DateTime LastRecieveDatTime { get; set; }
        public bool IsRecieveNormal
        {
            get
            {
                return DateTime.Now.Subtract(this.LastRecieveDatTime) < new TimeSpan(0, 0, 30);
            }
        }
        public int SendInterval { get; set; }
        public int TimeOut { get; set; }
        public int TimeOutCount { get; private set; }
        public bool IsTimeOut
        {
            get
            {
                return DateTime.Now.Subtract(this.LastRecieveDatTime) > new TimeSpan(0, 0, this.TimeOut);
            }
        }

        public CurrencyTerminal(string serverAddress, int serverPort)
        {
            this.ServerAddress = serverAddress;
            this.ServerPort = serverPort;

            this.LocalSocket = new SocketClient();
            this.LocalSocket.Stock_Connected += new Connected(this.Connected_Handler);
            this.LocalSocket.Stock_DataReceived += new DataReceived(this.DataReceived_Handler);
            this.LocalSocket.Stock_Disconnected += new Disconnected(this.Disconnected_Handler);

            this.TargetCurrencyCount = 0;
            this.RealConnectCount = 0;
            this.IsFinishDownloadBlacklist = true;
        }

        private void Connected_Handler(string message)
        {
            this.ConnectMessage = message;

            if (!this.IsConnected)
            {
                if (this.TargetReconnectCount > 0 && this.RealConnectCount < this.TargetReconnectCount)
                {
                    Thread.Sleep(100);

                    this.Connect();
                }
            }
        }

        private void DataReceived_Handler(byte[] data)
        {
            if (this.IsTimeOut)
            {
                this.TimeOutCount += 1;
            }

            this.LastRecieveDatTime = DateTime.Now;

            Datagram objDatagram = DatagramResolver.ResolveResponse(data);

            if (objDatagram != null)
            {
                if (objDatagram.Type == DatagramTypeEnum.HeartbeatResponse)
                {
                    this.SendHeartbeatCount += 1;

                    DataCounter.AddHeartbeat();
                }

                if (objDatagram.Type == DatagramTypeEnum.LoginResponse)
                {
                    this.SendLoginCount += 1;

                    DataCounter.AddLogin();
                }

                if (objDatagram.Type == DatagramTypeEnum.BlacklistQueryResponse)
                {
                    BlacklistQueryResponse response = objDatagram as BlacklistQueryResponse;

                    this.TargetDownloadBlacklist = response.BlacklistCount.ToInt16();
                    this.DownloadBlacklistCount = 0;

                    DataCounter.AddBlacklistQuery();
                    DataCounter.AddSingleBlacklistDownload(this.TargetDownloadBlacklist);

                    if (this.TargetCurrencyCount > 0)
                    {
                        this.IsFinishDownloadBlacklist = false;

                        this.SendBlacklist();
                    }
                }

                if (objDatagram.Type == DatagramTypeEnum.BlacklistDownloadResponse)
                {
                    this.DownloadBlacklistCount += 1;

                    DataCounter.AddRealBlacklistDownload();

                    if (this.DownloadBlacklistCount >= this.TargetDownloadBlacklist)
                    {
                        this.IsFinishDownloadBlacklist = true;
                    }

                    else
                    {
                        this.SendBlacklist();
                    }
                }

                if (objDatagram.Type == DatagramTypeEnum.CurrencyResponse)
                {
                    this.SendCurrencyCount += 1;

                    DataCounter.AddCurrency();

                    if (this.SendCurrencyCount < this.TargetCurrencyCount)
                    {
                        Thread.Sleep(this.SendInterval);

                        this.SendCurrency();
                    }
                }
            }
        }

        private void Disconnected_Handler()
        {
            this.ConnectMessage = "连接已关闭";
        }

        public void Reset()
        {
            this.RealConnectCount = 0;
        }

        public void Connect()
        {
            if (!this.IsConnected)
            {
                this.RealConnectCount += 1;

                this.LocalSocket.BeginConnectionTo(this.ServerAddress, this.ServerPort);
            }
        }

        public void SendHeartbeat()
        {
            if (this.IsConnected)
            {
                HeartbeatRequest heartbeat = new HeartbeatRequest();

                heartbeat.DeviceNumber = this.DeviceNumberHex;
                heartbeat.Foot = heartbeat.BuildFoot();

                this.LocalSocket.BeginSend(heartbeat.BuildFull());
            }
        }

        public void SendLogin()
        {
            if (this.IsConnected)
            {
                LoginRequest login = new LoginRequest();

                login.DeviceNumber = this.DeviceNumberHex;
                login.Key = new byte[] { 0x00 };
                login.SoftwareVersion = new byte[] { 0x0C, 0x05, 0x10 };
                login.Foot = login.BuildFoot();

                this.LocalSocket.BeginSend(login.BuildFull());
            }
        }

        public void SendBlacklist()
        {
            if (this.IsConnected)
            {
                if (this.IsFinishDownloadBlacklist)
                {
                    BlacklistQueryRequest blacklistQuery = new BlacklistQueryRequest();

                    blacklistQuery.DeviceNumber = this.DeviceNumberHex;
                    blacklistQuery.BlacklistVersion = new byte[] { 0x0C, 0x05, 0x10 };
                    blacklistQuery.Foot = blacklistQuery.BuildFoot();

                    this.LocalSocket.BeginSend(blacklistQuery.BuildFull());
                }

                else
                {
                    BlacklistDownloadRequest blacklistDownload = new BlacklistDownloadRequest();

                    blacklistDownload.DeviceNumber = this.DeviceNumberHex;
                    blacklistDownload.BlacklistOrder = ((short)(this.DownloadBlacklistCount + 1)).ToBytes();
                    blacklistDownload.Foot = blacklistDownload.BuildFoot();

                    this.LocalSocket.BeginSend(blacklistDownload.BuildFull());
                }
            }
        }

        public void SendCurrency()
        {
            if (this.IsConnected)
            {
                if (this.TargetCurrencyCount > 0)
                {
                    CurrencyRequest currency = new CurrencyRequest();

                    currency.DeviceNumber = this.DeviceNumberHex;
                    currency.Key = new byte[] { 0x00 };
                    currency.OperateTime = new byte[] { 0x0C, 0x0A, 0x1E, 0x12, 0x08, 0x15 };
                    currency.OperatorNumber = new byte[] { 0x00 };
                    currency.ClientCardNumber = new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 };
                    currency.BusinessType = new byte[] { 0x03 };
                    currency.BatchNumber = new byte[] { 0x12, 0x08, 0x16 };
                    currency.OrderNumber = new byte[] { 0x00, 0x01 };
                    currency.CurrencyType = new byte[] { 0x00 };
                    currency.CurrencyAmount = new byte[] { 0x00, 0x64 };
                    currency.CurrencyVersion = new byte[] { 0x07, 0xD5 };
                    currency.CurrencyFlag = new byte[] { 0x11 };
                    currency.CurrencyReal = new byte[] { 0x00 };
                    currency.CurrencyNumber = new byte[] { 0x57, 0x4F, 0x37, 0x37, 0x37, 0x30, 0x33, 0x31, 0x34, 0x34, 0x00, 0x00, 0x00 };
                    currency.CurrencyNumberImageType = new byte[] { 0x02 };
                    currency.CurrencyNumberImage = new byte[] 
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x3F, 0x00, 0x1F, 0xFE, 0x07, 0xFC, 0x3F, 0x80, 
                        0x0F, 0xF0, 0x01, 0xFE, 0x3F, 0xFE, 0x00, 0x00, 0x00, 0x00, 
                        0x00, 0x00, 0x00, 0x00, 0x1F, 0xFC, 0x3F, 0xFE, 0x30, 0x0E, 
                        0x30, 0x07, 0x30, 0x07, 0x38, 0x0E, 0x3F, 0xFE, 0x07, 0xF0, 
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x30, 0x00, 
                        0x30, 0x00, 0x30, 0xFF, 0x37, 0xFF, 0x3F, 0x00, 0x3C, 0x00, 
                        0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 
                        0x60, 0x00, 0x60, 0x00, 0x60, 0x1F, 0x61, 0xFF, 0x67, 0xE0, 
                        0x7E, 0x00, 0x78, 0x00, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 
                        0x00, 0x00, 0x40, 0x00, 0x60, 0x00, 0x60, 0x00, 0x60, 0x1F, 
                        0x61, 0xFF, 0x67, 0xF8, 0x7F, 0x00, 0x78, 0x00, 0x78, 0x00, 
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0xFC, 
                        0x3F, 0xFF, 0x78, 0x07, 0x60, 0x03, 0x60, 0x03, 0x60, 0x03, 
                        0x78, 0x0F, 0x3F, 0xFF, 0x0F, 0xF8, 0x00, 0x00, 0x00, 0x00, 
                        0x00, 0x00, 0x00, 0x08, 0x38, 0x0E, 0x38, 0x0F, 0x61, 0x83, 
                        0x61, 0x83, 0x63, 0x83, 0x3F, 0xC7, 0x3E, 0xFE, 0x00, 0x7C, 
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x18, 0x00, 
                        0x38, 0x00, 0x3F, 0xFF, 0x3F, 0xFF, 0x00, 0x00, 0x00, 0x00, 
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                        0x00, 0xF8, 0x01, 0xF8, 0x07, 0xB8,0x3E, 0x38, 0x3F, 0xFF, 
                        0x3F, 0xFF, 0x00, 0x38, 0x00, 0x00,0x00, 0x00, 0x00, 0x00, 
                        0x00, 0x00, 0x00, 0x78, 0x01, 0xF8,0x07, 0x98, 0x1E, 0x18, 
                        0x3F, 0xFF, 0x3F, 0xFF, 0x00, 0x18,0x00, 0x00, 0x00, 0x00
                    };
                    currency.Reserve = new byte[] { 0x00 };
                    currency.Foot = currency.BuildFoot();

                    this.LocalSocket.BeginSend(currency.BuildFull());
                }
            }
        }

        public void RestartSendCurrency()
        {
            this.SendCurrencyCount = 0;

            this.SendCurrency();
        }

        public void Close()
        {
            this.LocalSocket.Close();
        }
    }
}
