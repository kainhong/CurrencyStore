using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Task;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Utility.Query;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Currency_Info_Search : ServiceBasePage
    {
        private string OperateTime
        {
            get { return this.ViewState["OperateTime"] as string; }
            set { this.ViewState["OperateTime"] = value; }
        }
        private string StartTime
        {
            get { return this.ViewState["StartTime"] as string; }
            set { this.ViewState["StartTime"] = value; }
        }
        private string EndTime
        {
            get { return this.ViewState["EndTime"] as string; }
            set { this.ViewState["EndTime"] = value; }
        }
        private string CurrencyNumberA
        {
            get { return this.ViewState["CurrencyNumberA"] as string; }
            set { this.ViewState["CurrencyNumberA"] = value; }
        }
        private string CurrencyNumberB
        {
            get { return this.ViewState["CurrencyNumberB"] as string; }
            set { this.ViewState["CurrencyNumberB"] = value; }
        }
        private string CurrencyNumberC
        {
            get { return this.ViewState["CurrencyNumberC"] as string; }
            set { this.ViewState["CurrencyNumberC"] = value; }
        }
        private string CurrencyNumberD
        {
            get { return this.ViewState["CurrencyNumberD"] as string; }
            set { this.ViewState["CurrencyNumberD"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.SetDateTimeSearch(this.txtOperateTime);

                this.txtOperateTime.Text = this.GetStartTime(1);

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            var currencyInfoList = service.GetList_Info(this.StartTime, this.EndTime, this.CurrencyNumberA, this.CurrencyNumberB, this.CurrencyNumberC, this.CurrencyNumberD, null);

            if (currencyInfoList.Count > 25000)
            {
                this.JscriptMsg("单次导出数据量不能超过25000", null, "Error");

                return;
            }

            if (currencyInfoList.Count == 0)
            {
                this.JscriptMsg("暂无数据，无法导出", null, "Error");

                return;
            }

            DataTable temp = currencyInfoList.ToDataTable();

            string filePath = FileHelper.ConvertPath("~/App_File/Export/" + FileHelper.GetFileNamebyGuid(".xls"));

            temp.SaveToExcel(filePath);

            FileHelper.DownloadFile(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", "application/ms-excel", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OperateTime = this.txtOperateTime.Text.Trim();
            this.StartTime = this.OperateTime.IsNotNullOrEmpty() ? this.OperateTime.ToStartTime().ToString() : "";
            this.EndTime = this.OperateTime.IsNotNullOrEmpty() ? this.OperateTime.ToEndTime().ToString() : "";
            this.CurrencyNumberA = this.txtCurrencyNumberA.Text.Trim();
            this.CurrencyNumberB = this.txtCurrencyNumberB.Text.Trim();
            this.CurrencyNumberC = this.txtCurrencyNumberC.Text.Trim();
            this.CurrencyNumberD = this.txtCurrencyNumberD.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOperateTime.Text = this.OperateTime;
            this.txtCurrencyNumberA.Text = this.CurrencyNumberA;
            this.txtCurrencyNumberB.Text = this.CurrencyNumberB;
            this.txtCurrencyNumberC.Text = this.CurrencyNumberC;
            this.txtCurrencyNumberD.Text = this.CurrencyNumberD;

            this.gvList.Columns[0].Visible = SystemParameter.CurrencyInfoColumn.Contains("[1]");
            this.gvList.Columns[1].Visible = SystemParameter.CurrencyInfoColumn.Contains("[2]");
            this.gvList.Columns[2].Visible = SystemParameter.CurrencyInfoColumn.Contains("[3]");
            this.gvList.Columns[3].Visible = SystemParameter.CurrencyInfoColumn.Contains("[4]");
            this.gvList.Columns[4].Visible = SystemParameter.CurrencyInfoColumn.Contains("[5]");
            this.gvList.Columns[5].Visible = SystemParameter.CurrencyInfoColumn.Contains("[6]");
            this.gvList.Columns[6].Visible = SystemParameter.CurrencyInfoColumn.Contains("[7]");
            this.gvList.Columns[7].Visible = SystemParameter.CurrencyInfoColumn.Contains("[8]");
            this.gvList.Columns[8].Visible = SystemParameter.CurrencyInfoColumn.Contains("[9]");
            this.gvList.Columns[9].Visible = SystemParameter.CurrencyInfoColumn.Contains("[10]");
            this.gvList.Columns[10].Visible = SystemParameter.CurrencyInfoColumn.Contains("[11]");
            this.gvList.Columns[11].Visible = SystemParameter.CurrencyInfoColumn.Contains("[12]");
            this.gvList.Columns[12].Visible = SystemParameter.CurrencyInfoColumn.Contains("[13]");
            this.gvList.Columns[13].Visible = SystemParameter.CurrencyInfoColumn.Contains("[14]");
            this.gvList.Columns[14].Visible = SystemParameter.CurrencyInfoColumn.Contains("[15]");
            this.gvList.Columns[15].Visible = SystemParameter.CurrencyInfoColumn.Contains("[16]");
            this.gvList.Columns[16].Visible = SystemParameter.CurrencyInfoColumn.Contains("[17]");
            this.gvList.Columns[17].Visible = SystemParameter.CurrencyInfoColumn.Contains("[18]");

            this.BindCurrencyList();

            this.SetSubmitKey();
        }

        private void BindCurrencyList()
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            if (this.IsPostBack)
            {
                if (this.CurrencyNumberA.IsNullOrEmpty() && this.CurrencyNumberA.IsNullOrEmpty() && this.CurrencyNumberA.IsNullOrEmpty() && this.CurrencyNumberA.IsNullOrEmpty())
                {
                    this.JscriptMsg("至少输入一张纸币号码", null, "Error");

                    return;
                }

                this.gvList.DataSource = this.CurrentCurrencyInfoList = service.GetList_Info(this.StartTime, this.EndTime, this.CurrencyNumberA, this.CurrencyNumberB, this.CurrencyNumberC, this.CurrencyNumberD, this.Paging);

                this.objANP.RecordCount = this.Paging.RowCount;
            }

            else
            {
                this.gvList.DataSource = new List<CurrencyInfo>();

                this.Paging.RowCount = 0;
            }

            this.gvList.DataBind();
        }
    }
}