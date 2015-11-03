using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Services.Interface;
using CurrencyStore.Task;
using CurrencyStore.Web;

namespace CurrencyStore.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            DeviceCache.Current.Init();
            BlackTableHelper.Load();

            SystemParameter.Refresh();

            RequestPageTask.PagePath = ApplicationHelper.GetDomain(true, true) + "App_Page/Public/Default.aspx";
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

        void Application_End(object sender, EventArgs e)
        {
            RequestPageTask.Execute();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            var ex = HttpContext.Current.Error.InnerException ?? HttpContext.Current.Error;
            CurrencyStore.Common.ElibExceptionHandler.Handle(ex);
        }
    }
}
