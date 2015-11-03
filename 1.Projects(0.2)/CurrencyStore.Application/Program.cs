using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CurrencyStore.Common;
using CurrencyStore.Communication.Server;
using CurrencyStore.Services;
using CurrencyStore.Services.Interface;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace CurrencyStore.Application
{
    class Program
    {
        static bool exit;
        static SocketServer server;
        static int lastSecondCount;
        static int perSecondMaxCount;
        static int perSecondAvgCount;
        static int totalCurrencySecond;

        static void Main(string[] args)
        {
            //SimplySocket();
            //return;
            byte[] val = new byte[] { 0x58, 0x59, 0x5A, 0x41 };

            var i = val.GetString(0, 4);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            server = new CurrencyStore.Communication.Server.SocketServer();
            server.Start();
            Thread.Sleep(1000);
            var th = new Thread(new ThreadStart(DrawDisplay));
            th.Start();
            Console.ReadLine();
            exit = true;
            server.Stop();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CurrencyStore.Common.ElibExceptionHandler.Handle(e.ExceptionObject as Exception);
        }

        static void T1()
        {
            string str = "!ÇãÐ±/ÎÛÈ¾";
            var buff = new byte[13];
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                var tmp = BitConverter.GetBytes(c);
                buff[i] = tmp[0];
            }
            var val = System.Text.Encoding.Default.GetString(buff, 1, 12);
            var txt = CurrencyStore.Communication.Unity.GetCurrencyNo(buff, 0);
            var s = "倾斜";
            var bs = System.Text.Encoding.Default.GetBytes(s);
        }

        static void SimplySocket()
        {
            var listenerSocket = new Socket(
                        AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8234));
            listenerSocket.Listen(10);
            var socket = listenerSocket.Accept();
            var i = 0;
            while (socket.Connected)
            {

                var buff = new byte[200];
                var data = new byte[] { 0xaa, 0xbb, 0x00, 0xa0, 0x0a, 0x00, 0x02, 0x18 };
                var len = socket.Receive(buff);
                if (len > 0)
                {
                    socket.Send(data);
                }
                Thread.Sleep(20);
                i += 1;
                Console.Clear();
                Console.WriteLine(i);
            }
        }

        static void DrawDisplay()
        {
            while (!exit)
            {
                Console.Clear();
                if (server == null)
                    return;
                var c = server.Connections;
                var m = server.Messages;
                var b = server.Bytes;
                var i = server.Currencies - lastSecondCount;
                lastSecondCount = server.Currencies;

                if (i > 0)
                {
                    totalCurrencySecond += 1;

                    perSecondAvgCount = lastSecondCount / totalCurrencySecond;

                    if (i > perSecondMaxCount)
                    {
                        perSecondMaxCount = i;
                    }
                }               

                Console.WriteLine(String.Format("Server running...\n\n" +
                    "Connected Clients: {0}\n\n" +
                    "Messages Total: {1}\n" +
                    "Bytes this second: {2}\n\n" +
                    "Currencies Total: {3}\n\n" + 
                    "- per second: {4} - per second avg: {5} - per second max: {6}\n\n" +
                    "Press any key to shutdown...", c, m, b, lastSecondCount, i, perSecondAvgCount, perSecondMaxCount));

                server.Reset();
                Thread.Sleep(1000);
            }
        }
    }
}
