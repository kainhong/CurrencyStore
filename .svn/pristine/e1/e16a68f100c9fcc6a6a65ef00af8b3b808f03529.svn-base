using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Home : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindLogo();
        }

        private void BindLogo()
        {
            if (SystemParameter.SystemLogoPicture.IsNotNullOrEmpty())
            {
                this.imgLogo.ImageUrl = "~/App_File/Upload/{0}".FormatWith(SystemParameter.SystemLogoPicture);
                this.imgLogo.Visible = true;
            }

            else
            {
                this.imgLogo.Visible = false;
            }
        }
    }
}