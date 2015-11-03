using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Public
{
    public partial class CurrencyImage : ServiceBasePage
    {
        public string CurrencyNumber { get { return Request.GetValue("CurrencyNumber"); } }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            List<CurrencyInfo> currencyInfoList = this.CurrentCurrencyInfoList;

            if (currencyInfoList != null)
            {
                var currencyInfo = (from item in currencyInfoList where item.CurrencyNumber == this.CurrencyNumber select item).FirstOrDefault();

                /*
                if (currencyInfo == null)
                {
                    ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

                    currencyInfo = service.GetObject_Info(this.PkId);
                }
                */

                if (currencyInfo != null)
                {
                    Response.ClearContent();
                    Response.ContentType = "image/jpeg";
                    Response.BinaryWrite(currencyInfo.CurrencyImage.ToBitmap(currencyInfo.CurrencyImageType));
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}