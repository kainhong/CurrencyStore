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
    public partial class Basic_Org_List : ServiceBasePage
    {
        private string OrgParentId
        {
            get { return this.ViewState["OrgParentId"] as string; }
            set { this.ViewState["OrgParentId"] = value; }
        }
        private string OrgNumber
        {
            get { return this.ViewState["OrgNumber"] as string; }
            set { this.ViewState["OrgNumber"] = value; }
        }
        private string OrgName
        {
            get { return this.ViewState["OrgName"] as string; }
            set { this.ViewState["OrgName"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.txtOrgParentName.AddOrgSelector(this.UserId);

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            foreach (GridViewRow objGVR in this.gvList.Rows)
            {
                if (objGVR.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbSelect = objGVR.FindControl("cbSelect") as CheckBox;

                    if (cbSelect != null && cbSelect.Checked)
                    {
                        int orgId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();
                        string orgFullPath = this.gvList.DataKeys[objGVR.RowIndex]["OrgFullPath"].ToString();

                        service.Delete_Organization(orgId, orgFullPath);
                    }
                }
            }

            BasicConvert.ClearCache();

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgParentId = this.hfOrgParentId.Value.Trim();
            this.OrgNumber = this.txtOrgNumber.Text.Trim();
            this.OrgName = this.txtOrgName.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgParentName.Text = this.OrgParentId.GetOrgName(true);
            this.txtOrgNumber.Text = this.OrgNumber;
            this.txtOrgName.Text = this.OrgName;

            this.BindOrgList();

            this.SetSubmitKey();
        }

        private void BindOrgList()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Organization(0, this.OrgNumber, this.OrgName, this.OrgParentId.ToInt(0), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }
    }
}