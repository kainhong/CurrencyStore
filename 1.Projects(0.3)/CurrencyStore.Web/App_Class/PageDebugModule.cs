using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CurrencyStore.Repository;

namespace CurrencyStore.Web.App_Class
{
    public class PageDebugModule : IHttpModule
    {
        private DateTime StartTime { get; set; }

        public void Init(HttpApplication context)
        {
#if DEBUG
            context.BeginRequest += new EventHandler(Application_BeginRequest);
            context.EndRequest += new EventHandler(Application_EndRequest);
#endif
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;

            if (app.Request.RawUrl.Contains(@"/App_Page/Service/") && app.Request.RawUrl.Contains(".aspx"))
            {
                app.Response.Filter = new ResponseFilter(app.Response.Filter);
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            DbQueryDetailHelper.QueryDetail = "";
        }

        public void Dispose()
        {

        }
    }
}