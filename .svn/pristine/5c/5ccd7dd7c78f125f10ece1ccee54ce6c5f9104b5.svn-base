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
    public partial class User_Login_List : ServiceBasePage
    {
        private string UserAccount
        {
            get { return this.ViewState["UserAccount"] as string; }
            set { this.ViewState["UserAccount"] = value; }
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
                        int pkId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        service.Delete_Login(pkId);
                    }
                }
            }

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.UserAccount = this.txtUserAccount.Text.Trim();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtUserAccount.Text = this.UserAccount;

            this.BindLoginList();

            this.SetSubmitKey();
        }

        private void BindLoginList()
        {
            IUserService service = ServiceFactory.GetService<IUserService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Login(this.UserAccount.GetUserId(), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }
    }
}