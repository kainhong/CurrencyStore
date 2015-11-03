using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CurrencyStore.Communication.Server;

namespace CurrencyStore.Application
{
    partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        SocketServer server;
        protected override void OnStart(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            server = new CurrencyStore.Communication.Server.SocketServer();
            server.Start();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CurrencyStore.Common.ElibExceptionHandler.Handle(e.ExceptionObject as Exception);
        }


        protected override void OnStop()
        {
            server.Stop();
        }
    }
}
