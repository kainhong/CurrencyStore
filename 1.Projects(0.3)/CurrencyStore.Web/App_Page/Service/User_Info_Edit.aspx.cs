using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class User_Info_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "User_Info_List.aspx?UserId={0}".FormatWith(this.UserId);

            if (!this.IsPostBack)
            {
                this.SetOrgSearchByPermission(this.txtOrgName, this.hfOrgId);

                this.BindUserRoleList();
                this.BindUser();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IUserService service = ServiceFactory.GetService<IUserService>();

                UserInfo entity = null;

                if (this.IsInsert)
                {
                    entity = new UserInfo()
                    {
                        UserAccount = this.txtUserAccount.Text.Trim(),
                        UserPwd = this.txtUserPwd.Text.DESEncrypt(),
                        UserNickName = this.txtUserNickName.Text.Trim(),
                        UserEmail = this.txtUserEmail.Text.Trim(),
                        UserPhone = this.txtUserPhone.Text.Trim(),
                        UserStatus = this.ddlUserStatus.SelectedValue.ToByte(0),
                        RoleId = this.ddlUserRole.SelectedValue.ToByte(0),
                        OrgId = this.hfOrgId.Value.ToInt(0)
                    };

                    if (service.CheckExists_Info(entity))
                    {
                        this.JscriptMsg("用户帐户已存在", null, "Error");

                        return;
                    }
                }

                else
                {
                    entity = service.GetObject_Info(this.PkId);

                    if (entity != null)
                    {
                        entity.UserPwd = this.txtUserPwd.Text.DESEncrypt();
                        entity.UserNickName = this.txtUserNickName.Text.Trim();
                        entity.UserEmail = this.txtUserEmail.Text.Trim();
                        entity.UserPhone = this.txtUserPhone.Text.Trim();
                        entity.UserStatus = this.ddlUserStatus.SelectedValue.ToByte(0);
                        entity.RoleId = this.ddlUserRole.SelectedValue.ToByte(0);
                        entity.OrgId = this.hfOrgId.Value.ToInt(0);
                    }
                }

                service.Save_Info(entity);

                if (this.IsInsert && (sender as Button).CommandName == "SubmitContinue")
                {
                    this.ReturnUrl = this.Request.Url.PathAndQuery;
                }

                this.JscriptMsg("数据保存成功", this.ReturnUrl, "Success");
            }

            UserConvert.ClearCache();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }

        private void BindUserRoleList()
        {
            IUserService service = ServiceFactory.GetService<IUserService>();

            this.ddlUserRole.DataTextField = "RoleName";
            this.ddlUserRole.DataValueField = "PkId";
            this.ddlUserRole.DataSource = service.GetList_Role(null, null);
            this.ddlUserRole.DataBind();
        }

        private void BindUser()
        {
            if (!this.IsInsert)
            {
                IUserService service = ServiceFactory.GetService<IUserService>();

                UserInfo entity = service.GetObject_Info(this.PkId);

                if (entity != null)
                {
                    this.txtUserAccount.Text = entity.UserAccount;
                    this.txtUserPwd.Attributes["value"] = entity.UserPwd.DESDecrypt();
                    this.txtUserNickName.Text = entity.UserNickName;
                    this.txtUserEmail.Text = entity.UserEmail;
                    this.txtUserPhone.Text = entity.UserPhone;
                    this.ddlUserRole.SelectedValue = entity.RoleId.ToString();
                    this.hfOrgId.Value = entity.OrgId.ToString();
                    this.txtOrgName.Text = entity.OrgId.ToString().GetOrgName();
                    this.ddlUserStatus.SelectedValue = entity.UserStatus.ToString();

                    this.txtUserAccount.ReadOnly = true;
                    this.btnSubmitContinue.Visible = false;
                }

                else
                {
                    this.JscriptMsg("数据不存在", this.ReturnUrl, "Error");
                }
            }
        }
    }
}