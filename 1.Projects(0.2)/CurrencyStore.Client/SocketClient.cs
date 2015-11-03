using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CurrencyStore.Client
{
    public delegate void Connected(string message);
    public delegate void DataReceived(byte[] data);
    public delegate void Disconnected();

    public sealed class SocketClient
    {
        private Socket TcpSocket { get; set; }
        public bool IsConnected { get { return this.TcpSocket.Connected; } }
        private int BufferSize { get; set; }
        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private BufferPool LocalBufferPool { get; set; }
        private bool IsFinishSend { get; set; }
        private SocketAsyncEventArgs SaeaReceive { get; set; }
        private SocketAsyncEventArgs SaeaSend { get; set; }
        public event Connected Stock_Connected;
        public event DataReceived Stock_DataReceived;
        public event Disconnected Stock_Disconnected;

        public SocketClient()
        {
            this.TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.BufferSize = 512;
            this.ReceiveBuffer = new byte[this.BufferSize];
            this.SendBuffer = new byte[this.BufferSize];
            this.LocalBufferPool = new BufferPool();
            this.IsFinishSend = true;

            this.SaeaReceive = new SocketAsyncEventArgs();
            this.SaeaReceive.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
            this.SaeaSend = new SocketAsyncEventArgs();
            this.SaeaSend.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);

            this.SaeaReceive.SetBuffer(this.ReceiveBuffer, 0, this.BufferSize);
            this.SaeaSend.SetBuffer(this.SendBuffer, 0, this.BufferSize);
        }
        public void BeginConnectionTo(string host, int port)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(host), port);

            this.SaeaReceive.RemoteEndPoint = serverEndPoint;
            this.SaeaSend.RemoteEndPoint = serverEndPoint;

            if (!this.IsConnected)
            {
                if (!this.TcpSocket.ConnectAsync(this.SaeaReceive))
                {
                    eCompleted(this.SaeaReceive);
                }
            }
        }
        public void BeginSend(byte[] data)
        {
            if (this.IsConnected && this.IsFinishSend)
            {
                this.IsFinishSend = false;

                Buffer.BlockCopy(data, 0, this.SendBuffer, 0, data.Length);

                this.SaeaSend.SetBuffer(0, data.Length);

                if (!this.TcpSocket.SendAsync(this.SaeaSend))
                {
                    eCompleted(this.SaeaSend);
                }
            }

            else
            {
                this.LocalBufferPool.Set(data);
            }
        }
        public void Close()
        {
            try
            {
                if (this.IsConnected)
                {
                    if (this.Stock_Disconnected != null)
                    {
                        this.Stock_Disconnected();
                    }

                    this.TcpSocket.Shutdown(SocketShutdown.Both);
                    this.TcpSocket.Disconnect(false);
                    this.TcpSocket.Close();
                }
            }

            catch
            {

            }
        }
        void e_Completed(object sender, SocketAsyncEventArgs e)
        {
            eCompleted(e);
        }
        void eCompleted(SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:

                    if (e.SocketError == SocketError.Success)
                    {
                        e.SetBuffer(0, this.BufferSize);

                        if (this.IsConnected)
                        {
                            if (!this.TcpSocket.ReceiveAsync(e))
                            {
                                this.eCompleted(e);
                            }
                        }
                    }

                    if (this.Stock_Connected != null)
                    {
                        this.Stock_Connected(this.GetConnectMessage(e.SocketError));
                    }

                    break;

                case SocketAsyncOperation.Receive:

                    if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
                    {
                        byte[] data = new byte[e.BytesTransferred];

                        Buffer.BlockCopy(e.Buffer, 0, data, 0, data.Length);

                        if (this.Stock_DataReceived != null)
                        {
                            this.Stock_DataReceived(data);
                        }

                        e.SetBuffer(0, this.BufferSize);

                        if (this.IsConnected)
                        {
                            if (!this.TcpSocket.ReceiveAsync(e))
                            {
                                eCompleted(e);
                            }
                        }
                    }

                    break;

                case SocketAsyncOperation.Send:

                    if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
                    {
                        byte[] data = this.LocalBufferPool.Get();

                        if (data != null)
                        {
                            Buffer.BlockCopy(data, 0, this.SendBuffer, 0, data.Length);

                            e.SetBuffer(0, data.Length);

                            if (!this.TcpSocket.SendAsync(e))
                            {
                                eCompleted(e);
                            }
                        }

                        else
                        {
                            this.IsFinishSend = true;
                        }
                    }

                    break;
            }
        }
        private string GetConnectMessage(SocketError se)
        {
            string result = null;

            switch (se)
            {
                case SocketError.AccessDenied:
                    result = "SocketError.AccessDenied;已试图通过被其访问权限禁止的方式访问Socket";
                    break;

                case SocketError.AddressAlreadyInUse:
                    result = "SocketError.AddressAlreadyInUse;通常，只允许使用地址一次";
                    break;

                case SocketError.AddressFamilyNotSupported:
                    result = "SocketError.AddressFamilyNotSupported;地址与请求的协议不兼容";
                    break;

                case SocketError.AddressNotAvailable:
                    result = "SocketError.AddressNotAvailable;选定的地址在此上下文中有效";
                    break;

                case SocketError.AlreadyInProgress:
                    result = "SocketError.AlreadyInProgress;非阻止性Socket已有一个操作正在进行中";
                    break;

                case SocketError.ConnectionAborted:
                    result = "SocketError.ConnectionAborted;此连接由.NET Framework或基础套接字提供程序中止";
                    break;

                case SocketError.ConnectionRefused:
                    result = "SocketError.ConnectionRefused;远程主机正在主动拒绝连接";
                    break;

                case SocketError.ConnectionReset:
                    result = "SocketError.ConnectionReset;此连接由远程对等计算机重置";
                    break;

                case SocketError.DestinationAddressRequired:
                    result = "SocketError.DestinationAddressRequired;在对Socket的操作中省略了必需的地址";
                    break;

                case SocketError.Disconnecting:
                    result = "SocketError.Disconnecting;正常关机正在进行中";
                    break;

                case SocketError.Fault:
                    result = "SocketError.Fault;基础套接字提供程序检测到无效的指针地址";
                    break;

                case SocketError.HostDown:
                    result = "SocketError.HostDown;由于远程主机被关闭，操作失败";
                    break;

                case SocketError.HostNotFound:
                    result = "SocketError.HostNotFound;无法识别这种主机，该名称不是正式的主机名或别名";
                    break;

                case SocketError.HostUnreachable:
                    result = "SocketError.HostUnreachable;没有到指定主机的网络路由";
                    break;

                case SocketError.InProgress:
                    result = "SocketError.InProgress;阻止操作正在进行中";
                    break;

                case SocketError.Interrupted:
                    result = "SocketError.Interrupted;已取消阻止Socket调用的操作";
                    break;

                case SocketError.InvalidArgument:
                    result = "SocketError.InvalidArgument;给Socket成员提供了一个无效参数";
                    break;

                case SocketError.IOPending:
                    result = "SocketError.IOPending;应用程序已启动一个无法立即完成的重叠操作";
                    break;

                case SocketError.IsConnected:
                    result = "SocketError.IsConnected;Socket已连接";
                    break;

                case SocketError.MessageSize:
                    result = "SocketError.MessageSize;数据报太长";
                    break;

                case SocketError.NetworkDown:
                    result = "SocketError.NetworkDown;网络不可用";
                    break;

                case SocketError.NetworkReset:
                    result = "SocketError.NetworkReset;应用程序试图在已超时的连接上设置KeepAlive";
                    break;

                case SocketError.NetworkUnreachable:
                    result = "SocketError.NetworkUnreachable;不存在到远程主机的路由";
                    break;

                case SocketError.NoBufferSpaceAvailable:
                    result = "SocketError.NoBufferSpaceAvailable;没有可用于Socket操作的可用缓冲区空间";
                    break;

                case SocketError.NoData:
                    result = "SocketError.NoData;在名称服务器上找不到请求的名称或IP地址";
                    break;

                case SocketError.NoRecovery:
                    result = "SocketError.NoRecovery;错误不可恢复或找不到请求的数据库";
                    break;

                case SocketError.NotConnected:
                    result = "SocketError.NotConnected;应用程序试图发送或接收数据，但是Socket未连接";
                    break;

                case SocketError.NotInitialized:
                    result = "SocketError.NotInitialized;尚未初始化基础套接字提供程序";
                    break;

                case SocketError.NotSocket:
                    result = "SocketError.NotSocket;对非套接字尝试Socket操作";
                    break;

                case SocketError.OperationAborted:
                    result = "SocketError.OperationAborted;由于Socket已关闭，重叠的操作被中止";
                    break;

                case SocketError.OperationNotSupported:
                    result = "SocketError.OperationNotSupported;协议族不支持地址族";
                    break;

                case SocketError.ProcessLimit:
                    result = "SocketError.ProcessLimit;正在使用基础套接字提供程序的进程过多";
                    break;

                case SocketError.ProtocolFamilyNotSupported:
                    result = "SocketError.ProtocolFamilyNotSupported;未实现或未配置协议族";
                    break;

                case SocketError.ProtocolNotSupported:
                    result = "SocketError.ProtocolNotSupported;未实现或未配置协议";
                    break;

                case SocketError.ProtocolOption:
                    result = "SocketError.ProtocolOption;对Socket使用了未知、无效或不受支持的选项或级别";
                    break;

                case SocketError.ProtocolType:
                    result = "SocketError.ProtocolType;此Socket的协议类型不正确";
                    break;

                case SocketError.Shutdown:
                    result = "SocketError.Shutdown;发送或接收数据的请求未得到允许，因为Socket已被关闭";
                    break;

                case SocketError.SocketError:
                    result = "SocketError.SocketError;发生了未指定的Socket错误";
                    break;

                case SocketError.SocketNotSupported:
                    result = "SocketError.SocketNotSupported;在此地址族中不存在对指定的套接字类型的支持";
                    break;

                case SocketError.Success:
                    result = "SocketError.Success;Socket操作成功";
                    break;

                case SocketError.SystemNotReady:
                    result = "SocketError.SystemNotReady;网络子系统不可用";
                    break;

                case SocketError.TimedOut:
                    result = "SocketError.TimedOut;连接尝试超时，或者连接的主机没有响应";
                    break;

                case SocketError.TooManyOpenSockets:
                    result = "SocketError.TooManyOpenSockets;基础套接字提供程序中打开的套接字太多";
                    break;

                case SocketError.TryAgain:
                    result = "SocketError.TryAgain;无法解析主机名，请稍后重试";
                    break;

                case SocketError.TypeNotFound:
                    result = "SocketError.TypeNotFound;未找到指定的类";
                    break;

                case SocketError.VersionNotSupported:
                    result = "SocketError.VersionNotSupported;基础套接字提供程序的版本超出范围";
                    break;

                case SocketError.WouldBlock:
                    result = "SocketError.WouldBlock;对非阻止性套接字的操作不能立即完成";
                    break;
            }

            return result;
        }
    }
}
