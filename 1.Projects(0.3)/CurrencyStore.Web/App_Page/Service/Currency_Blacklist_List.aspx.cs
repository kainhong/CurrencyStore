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
    public partial class Currency_Blacklist_List : ServiceBasePage
    {
        private string CurrencyNumber
        {
            get { return this.ViewState["CurrencyNumber"] as string; }
            set { this.ViewState["CurrencyNumber"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            foreach (GridViewRow objGVR in this.gvList.Rows)
            {
                if (objGVR.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbSelect = objGVR.FindControl("cbSelect") as CheckBox;

                    if (cbSelect != null && cbSelect.Checked)
                    {
                        int orgId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        service.Delete_Blacklist(orgId);
                    }
                }
            }

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.CurrencyNumber = this.txtCurrencyNumber.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void btnUpdateVersion_Click(object sender, EventArgs e)
        {
            SystemParameter.UpdateBlacklistVersion();

            BlackTableHelper.Update();

            this.JscriptMsg("版本更新成功，新版本号：{0}".FormatWith(SystemParameter.BlacklistVersion), null, "Success");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindList();

            this.SetSubmitKey();
        }

        private void BindList()
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Blacklist(this.CurrencyNumber, this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }
    }
}