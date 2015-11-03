using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Data_Clear : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (this.cbCurrencyInfo.Checked)
            {
                var service = ServiceFactory.GetService<ICurrencyService>();

                service.DeleteAll_Info();
            }

            if (this.cbBlackList.Checked)
            {
                var service = ServiceFactory.GetService<ICurrencyService>();

                service.Delete_Blacklist(0);

                SystemParameter.UpdateBlacklistVersion();

                BlackTableHelper.Update();
            }

            if (this.cbDeviceInfo.Checked)
            {
                var service = ServiceFactory.GetService<IDeviceService>();

                service.Delete_Info(0);
            }

            if (this.cbOrg.Checked)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                service.Delete_Organization(0, null);
            }

            if (this.cbUserlogin.Checked)
            {
                var service = ServiceFactory.GetService<IUserService>();

                service.Delete_Login(0);
            }

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }
    }
}