using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class ModifyPwd : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IUserService service = ServiceFactory.GetService<IUserService>();

                UserInfo entity = service.GetObject_Info(this.CurrentUser.PkId);

                if (this.txtOldPwd.Text.Trim().DESEncrypt() != entity.UserPwd)
                {
                    this.JscriptMsg("旧密码输入错误", null, "Error");

                    return;
                }

                entity.UserPwd = this.txtNewPwd.Text.Trim().DESEncrypt();

                service.Save_Info(entity);

                this.JscriptMsg("密码修改成功", null, "Success");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }
    }
}