using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Currency_Export_List : ServiceBasePage
    {
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
                        int pkId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        var objCurrencyExport = service.GetObject_Export(pkId);

                        if (objCurrencyExport != null)
                        {
                            FileHelper.DeleteFile("~/App_File/Export/" + objCurrencyExport.FileName);

                            service.Delete_Export(objCurrencyExport.PkId);
                        }
                    }
                }
            }

            BasicConvert.ClearCache();

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string exportStatus = this.gvList.DataKeys[e.Row.RowIndex]["ExportStatus"].ToString();

                if (exportStatus != "2")
                {
                    HtmlAnchor aDownload = e.Row.FindControl("aDownload") as HtmlAnchor;

                    aDownload.Visible = false;
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindExportList();

            this.SetSubmitKey();
        }

        private void BindExportList()
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Export(this.CurrentUser.PkId, this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount;
        }
    }
}