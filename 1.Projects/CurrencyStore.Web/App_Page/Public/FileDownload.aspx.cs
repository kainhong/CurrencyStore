using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Public
{
    public partial class FileDownload : BasePage
    {
        private string RealFilePath
        {
            get { return this.GetQueryString<string>("RealFilePath").UrlDecode(); }
        }
        private string Rename
        {
            get { return this.GetQueryString<string>("Rename").UrlDecode(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FileHelper.DownloadFile(this.RealFilePath, this.Rename, null, false);
        }
    }
}