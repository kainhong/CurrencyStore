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
    public partial class User_Role_List : ServiceBasePage
    {
        private string RoleName
        {
            get { return this.ViewState["RoleName"] as string; }
            set { this.ViewState["RoleName"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.btnSearch_Click(null, null);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IUserService service = ServiceFactory.GetService<IUserService>();

            foreach (GridViewRow objGVR in this.gvList.Rows)
            {
                if (objGVR.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbSelect = objGVR.FindControl("cbSelect") as CheckBox;

                    if (cbSelect != null && cbSelect.Checked)
                    {
                        int roleId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        service.Delete_RolePermission(roleId);
                        service.Delete_Role(roleId);
                    }
                }
            }

            this.JscriptMsg("数据删除成功", null, "Success");

            BasicConvert.ClearCache();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.RoleName = this.txtRoleName.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtRoleName.Text = this.RoleName;

            this.BindRoleList();

            this.SetSubmitKey();
        }

        private void BindRoleList()
        {
            IUserService service = ServiceFactory.GetService<IUserService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Role(this.RoleName, this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount;
        }
    }
}