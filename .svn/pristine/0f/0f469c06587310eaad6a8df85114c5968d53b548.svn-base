using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class User_Role_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "User_Role_List.aspx?UserId={0}".FormatWith(this.UserId);

            if (!this.IsPostBack)
            {
                this.BindRole();
                this.BindPermission();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IUserService service = ServiceFactory.GetService<IUserService>();

                UserRole entity = null;
                List<UserRolePermission> rolePermissionList = new List<UserRolePermission>();

                if (this.IsInsert)
                {
                    entity = new UserRole()
                    {
                        RoleName = this.txtRoleName.Text.Trim(),
                        DataFilter = this.ddlDataFilter.SelectedValue.ToByte(0),
                        RoleStatus = this.ddlRoleStatus.SelectedValue.ToByte(0)
                    };

                    if (service.CheckExists_Role(entity))
                    {
                        this.JscriptMsg("角色名称已存在", null, "Error");

                        return;
                    }
                }

                else
                {
                    entity = service.GetObject_Role(this.PkId);

                    if (entity != null)
                    {
                        entity.DataFilter = this.ddlDataFilter.SelectedValue.ToByte(0);
                        entity.RoleStatus = this.ddlRoleStatus.SelectedValue.ToByte(0);
                    }
                }

                service.Save_Role(entity);

                foreach (TreeNode tnOne in this.tvPermission.Nodes)
                {
                    if (tnOne.Checked)
                    {
                        rolePermissionList.Add(new UserRolePermission() { RoleId = entity.PkId, PermCode = tnOne.Value });
                    }

                    foreach (TreeNode tnTwo in tnOne.ChildNodes)
                    {
                        if (tnTwo.Checked)
                        {
                            rolePermissionList.Add(new UserRolePermission() { RoleId = entity.PkId, PermCode = tnTwo.Value });
                        }
                    }
                }

                service.Delete_RolePermission(entity.PkId);
                service.Save_RolePermission(rolePermissionList);

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

        private void BindPermission()
        {
            this.tvPermission.Nodes.Clear();

            IUserService service = ServiceFactory.GetService<IUserService>();

            var allPermissionList = service.GetList_Permission();
            var userPermissionList = service.GetList_RolePermission(this.PkId);

            foreach (var one in from item in allPermissionList where item.PermParentId == 0 && item.PermContent != "-" orderby item.PermCode ascending select item)
            {
                TreeNode tnOne = new TreeNode(one.PermName, one.PermCode.ToString());

                foreach (var two in from item in allPermissionList where item.PermParentId == one.PkId && item.PermContent != "-" orderby item.PermCode ascending select item)
                {
                    TreeNode tnTwo = new TreeNode(two.PermName, two.PermCode.ToString());

                    if (userPermissionList.Where(obj => obj.PermCode == two.PermCode).Count() == 1)
                    {
                        tnTwo.Checked = true;
                    }

                    tnOne.ChildNodes.Add(tnTwo);
                }

                this.tvPermission.Nodes.Add(tnOne);
            }
        }

        private void BindRole()
        {
            if (!this.IsInsert)
            {
                IUserService service = ServiceFactory.GetService<IUserService>();

                UserRole entity = service.GetObject_Role(this.PkId);

                if (entity != null)
                {
                    this.txtRoleName.Text = entity.RoleName;
                    this.ddlDataFilter.SelectedValue = entity.DataFilter.ToString();
                    this.ddlRoleStatus.SelectedValue = entity.RoleStatus.ToString();

                    this.txtRoleName.ReadOnly = true;
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