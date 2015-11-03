using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Web;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Login : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.ClearAllCookie();
                this.ClearAllSession();

                FormsAuthentication.SignOut();

                this.txtCheckCode.Attributes["onfocus"] = "GetCheckCode();";
                this.txtUserAccount.Focus();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserAccount.Text.Trim().IsNullOrEmpty() ||
                this.txtUserPwd.Text.Trim().IsNullOrEmpty() ||
                this.txtCheckCode.Text.Trim().IsNullOrEmpty())
            {
                this.lblMessage.Text = "请输入完整的登录信息";

                return;
            }

            string userAccount = this.txtUserAccount.Text.Trim();
            string userPwd = this.txtUserPwd.Text.Trim();
            string checkCode = this.txtCheckCode.Text.Trim();

            if (!checkCode.Equals(this.CheckCode))
            {
                this.lblMessage.Text = "验证码输入错误";

                return;
            }

            if (this.CheckUser(userAccount, userPwd))
            {             
                FormsAuthentication.SetAuthCookie(userAccount, false);

                Response.Redirect("Index.aspx?UserId={0}".FormatWith(this.CurrentUser.PkId));
            }         
        }
        private bool CheckUser(string userAccount, string userPwd)
        {
            IUserService service = ServiceFactory.GetService<IUserService>();

            UserInfo uiCurrent = service.GetObjectByUserAccount_Info(userAccount);

            if (uiCurrent != null)
            {
                if (uiCurrent.UserPwd == userPwd.DESEncrypt())
                {
                    this.TempUserId = uiCurrent.PkId.ToString();
                    this.CurrentUser = uiCurrent;
                    this.CurrentUserRole = service.GetObject_Role(this.CurrentUser.RoleId);
                    this.CurrentUserRolePermissionList = (from rp in service.GetList_RolePermission(this.CurrentUserRole.PkId) select rp.PermCode).ToList();

                    if (this.CurrentUserRole.RoleStatus == (byte)UserRole.RoleStatusEnum.Disable)
                    {
                        this.lblMessage.Text = "账户所属角色被禁用";

                        return false;
                    }

                    if (this.CurrentUser.UserStatus == (byte)UserInfo.UserStatusEnum.Disable)
                    {
                        this.lblMessage.Text = "账户被禁用";

                        return false;
                    }

                    UserLogin ulCurrent = new UserLogin()
                    {
                        UserId = this.CurrentUser.PkId,
                        LoginIp = ApplicationHelper.GetClientIp(),
                        LoginTime = DateTime.Now
                    };

                    service.Save_Login(ulCurrent);

                    return true;
                }

                else
                {
                    this.lblMessage.Text = "密码输入错误";

                    return false;
                }
            }

            else 
            {
                this.lblMessage.Text = "账户不存在";

                return false;
            }
        }
    }
}