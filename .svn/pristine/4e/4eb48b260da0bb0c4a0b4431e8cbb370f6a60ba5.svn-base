using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using CurrencyStore.Business;
using CurrencyStore.Service.Interface;
using CurrencyStore.Task;
using CurrencyStore.Utility;
using CurrencyStore.Web;

namespace CurrencyStore.Web
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            DeviceCache.Current.Init();
            BlackTableHelper.Load();

            SystemParameter.Refresh();

            RequestPageTask.PagePath = ApplicationHelper.GetDomain(true, true) + "App_Page/Public/Default.aspx";
        }

        void Application_End(object sender, EventArgs e)
        {
            RequestPageTask.Execute();
        }

        void Application_Error(object sender, EventArgs e)
        {
            var ex = HttpContext.Current.Error.InnerException ?? HttpContext.Current.Error;

            ElibExceptionHandler.Handle(ex);
        }

        void Session_Start(object sender, EventArgs e)
        {

        }

        void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            TaskFactory.CreateTimer();

            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";

            //Thread.CurrentThread.CurrentUICulture.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
            //Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            //Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";

            var en = new CultureInfo(Thread.CurrentThread.CurrentCulture.LCID);
            en.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
            en.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            en.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = en;
        }
    }
}
