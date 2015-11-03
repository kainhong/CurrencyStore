using System;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Web;

namespace CurrencyStore.Web.App_Page.Public
{
    public partial class CheckCode : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Captcha objCaptcha = new Captcha();

            this.CheckCode = objCaptcha.VerifyCodeText;

            objCaptcha.Output(this.Response);
        }
    }
}