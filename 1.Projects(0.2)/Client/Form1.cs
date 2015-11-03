using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Client
{
    public partial class Form1 : Form
    {
        const string Content = "AABB012E3158325900007366A00A000C0A1E120815000101010101010101010103120816000100006407D51100574F3737373033313434000000020000000000000000000000003F001FFE07FC3F800FF001FE3FFE00000000000000001FFC3FFE300E30073007380E3FFE07F000000000000030003000300030FF37FF3F003C003800000000000000200060006000601F61FF67E07E0078007000000000000000400060006000601F61FF67F87F007800780000000000000000003FFC3FFF7807600360036003780F3FFF0FF80000000000000008380E380F6183618363833FC73EFE007C0000000000000800180038003FFF3FFF000000000000000000000000000000F801F807B83E383FFF3FFF00380000000000000000007801F807981E183FFF3FFF001800000000003B05";
        byte[] buff;
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                socket.Send(buff);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buff = new byte[Content.Length / 2];
            for (int i = 0; i < buff.Length; i++)
            {
                var val = "0x" + Content[i * 2] + Content[i * 2 + 1];
                buff[i] = (byte)Convert.ToInt16(val, 16);
            }

            socket.Connect("127.0.0.1", 8234);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            socket.Send(new byte[] { buff[0], buff[1], buff[2] });
            var data = new byte[buff.Length - 3];
            System.Threading.Thread.Sleep(200);
            Array.Copy(buff, 3, data, 0, buff.Length - 3);
            //Array.Copy(buff, buff.Length -3, data, buff.Length-3, 10);
            socket.Send(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var data = new byte[buff.Length - 10];
            Array.Copy(buff, 10, data, 0, buff.Length - 10);
            socket.Send(data);
        }

        private byte[] GetDatas(string line)
        {
            var data = new byte[line.Length / 2];
            for (int i = 0; i < data.Length; i++)
            {
                var val = "0x" + line[i * 2] + line[i * 2 + 1];
                data[i] = (byte)Convert.ToInt16(val, 16);
            }
            return data;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var datas = File.ReadAllLines("data.txt");
            //var content = string.Join(string.Empty, datas);
            //var index = 0;
            //while (index < content.Length)
            //{

            //    var len = new Random().Next(50, 60);
            //    len = Math.Min(len, content.Length - index);
            //    var item = content.Substring(index, len);
            //    index += len;
            //    Console.Write(item);
            //    var data = GetDatas(item);
            //    socket.Send(data);
            //}
            //for (int i = 0; i < 50; i++)
            //{
            foreach (var item in datas)
            {
                var data = GetDatas(item);
                socket.Send(data);
                Thread.Sleep(20);
            }
            //}
        }

        private bool stoped;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (btnLoad.Text == "Load")
            {
                var datas = File.ReadAllLines("data.txt").Select(c => GetDatas(c)).ToList();
                var count = (int)numericUpDown1.Value;
                btnLoad.Text = "Stop";
                stoped = false;
                Socket[] sockets = new Socket[count];
                for (int i = 0; i < count; i++)
                {
                    var t = new Thread(new ThreadStart(() => SendData(i, datas)));
                    t.Start();
                    Thread.Sleep(100);
                    //Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //sk.Connect("172.18.12.28", 8234);
                    //sk.Send(datas[0]);
                    //sockets[i] = sk;
                }
            }
            else
            {
                btnLoad.Text = "Load";
                stoped = true;
            }

        }

        private void SendData(int index, List<byte[]> datas)
        {
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sk.SendTimeout = 2000;
            sk.Connect("127.0.0.1", 8234);

            Console.WriteLine(index);
            while (!stoped)
            {
                Thread.Sleep(200);
                foreach (var item in datas)
                {
                    sk.Send(item);
                    Thread.Sleep(200);
                }
            }
        }
    }
}
