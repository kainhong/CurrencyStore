using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
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