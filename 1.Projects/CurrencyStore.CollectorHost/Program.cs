using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CurrencyStore.Collector;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Entity;
using CurrencyStore.Business.Storage;
using CurrencyStore.Collector.Storage;
using CurrencyStore.Collector.Configration;
using CurrencyStore.Collector.Remoting;

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
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            var type = CurrencyStoreSection.Instance.Task.Storage.Type;
            var enable = CurrencyStoreSection.Instance.Task.Storage.Enable;
            if (enable && type == "remote")
            {
                Console.WriteLine("remote agent is starting...");
                RemoteAgency.Start();
                Thread.Sleep(1000);
                Console.WriteLine("remote agent is started.");
            }

            server = new SocketServer();
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
            ElibExceptionHandler.Handle(e.ExceptionObject as Exception);
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
