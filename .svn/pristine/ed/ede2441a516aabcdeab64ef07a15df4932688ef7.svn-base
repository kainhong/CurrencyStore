using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CurrencyStore.Utility;

namespace CurrencyStore.BatchInsert
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ElibExceptionHandler.Handle(e.ExceptionObject as Exception);
        }
    }
}
