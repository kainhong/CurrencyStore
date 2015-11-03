using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public class DataTask
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public bool Connected { get; private set; }

        public int Count;

        private string ip;
        private int port;
        private Socket socket;
        private bool stoped;
        const string data = "AABB012E3158325900BC614EA00A000C0A1E120815000101010101010101010103120816000100003207D5110045473133363230363334000000020000000000000000000000003F001FFE07FC3F800FF001FE3FFE00000000000000001FFC3FFE300E30073007380E3FFE07F000000000000030003000300030FF37FF3F003C003800000000000000200060006000601F61FF67E07E0078007000000000000000400060006000601F61FF67F87F007800780000000000000000003FFC3FFF7807600360036003780F3FFF0FF80000000000000008380E380F6183618363833FC73EFE007C0000000000000800180038003FFF3FFF000000000000000000000000000000F801F807B83E383FFF3FFF00380000000000000000007801F807981E183FFF3FFF001800000000003B05";
        private int sendCount;
        public DataTask(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            buff = new byte[data.Length / 2];
            for (int i = 0; i < buff.Length; i++)
            {
                var val = "0x" + data[i * 2] + data[i * 2 + 1];
                buff[i] = (byte)Convert.ToInt16(val, 16);
            }
        }

        public void Connect()
        {
            try
            {
                if (socket == null)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.SendTimeout = 50;
                }

                socket.Connect(ip, port);
                Connected = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("{0}\t{1}\tConnect Error:\n{2}", Id, Number, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void Close()
        {
            stoped = true;
            Thread.Sleep(60);
            if (Connected)
                socket.Close();
            Connected = false;
        }

        public void Start()
        {
            if (!Connected)
                Connect();
            sendCount = 0;
            Count = 0;
            var thread = new Thread(new ThreadStart(SendData));
            thread.Start();
        }

        public void Start(int count)
        {
            if (!Connected)
                Connect();
            sendCount = count;
            Count = 0;
            var thread = new Thread(new ThreadStart(SendData));
            thread.Start();
        }

        byte[] buff = new byte[] { };
        private void SendData()
        {
            while (!stoped)
            {
                try
                {
                    socket.Send(buff);
                    Count++;
                    if (Count == sendCount && sendCount > 0)
                        break;
                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError("{0}\t{1}\tSend Data Error:\n{2}", Id, Number, ex.Message);
                    break;
                }

            }
        }

    }
}
