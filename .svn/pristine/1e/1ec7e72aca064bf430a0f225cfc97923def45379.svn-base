using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.Common.Query;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Task;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Currency_Info_List : ServiceBasePage
    {
        private string OrgId
        {
            get { return this.ViewState["OrgId"] as string; }
            set { this.ViewState["OrgId"] = value; }
        }
        private string DeviceNumber
        {
            get { return this.ViewState["DeviceNumber"] as string; }
            set { this.ViewState["DeviceNumber"] = value; }
        }
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
        private string CurrencyNumber
        {
            get { return this.ViewState["CurrencyNumber"] as string; }
            set { this.ViewState["CurrencyNumber"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.SetOrgSearchByPermission(this.txtOrgName, this.hfOrgId, false);
                this.SetDateTimeSearch(this.txtOperateTime);

                if (this.IsUnknowOrg)
                {
                    this.hfOrgId.Value = "0";
                }
                
                this.txtOperateTime.Text = this.GetStartTime(1);

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

            var currencyInfoPaging = new Pagination()
            {
                CurrentPageIndex = 1,
                PageSize = 1
            };

            var currencyInfoList = service.GetList_Info(this.OrgId.ToInt(0), false, this.StartTime, this.EndTime, this.DeviceNumber, this.CurrencyNumber, currencyInfoPaging);

            if (currencyInfoPaging.RowCount > 25000)
            {
                this.JscriptMsg("单次导出数据量不能超过25000", null, "Error");

                return;
            }

            if (currencyInfoPaging.RowCount == 0)
            {
                this.JscriptMsg("暂无数据，无法导出", null, "Error");

                return;
            }

            CurrencyExport entity = new CurrencyExport()
            {
                OrgId = this.OrgId.ToInt(0),
                DeviceNumber = this.DeviceNumber,
                OperateStartTime = this.StartTime,
                OperateEndTime = this.EndTime,
                CurrencyNumber = this.CurrencyNumber,
                ExportStatus = 0,
                DataCount = 0,
                FileName = "",
                FileSize = "",
                CreateUserId = this.CurrentUser.PkId,
                CreateTime = DateTime.Now
            };

            service.Save_Export(entity);

            ExportCurrencyTask.AddNext(FileHelper.ConvertPath("~/App_File/Export/"));

            TaskFactory.CreateTimer();

            var currencyExportPaging = new Pagination()
            {
                CurrentPageIndex = 2,
                PageSize = (int)SystemParameter.FileStorageCount
            };

            var currencyExportList = service.GetList_Export(this.CurrentUser.PkId, currencyExportPaging);

            if (currencyExportPaging.CurrentPageIndex == 2 && currencyExportPaging.RowCount > SystemParameter.FileStorageCount)
            {
                foreach (var item in currencyExportList)
                {
                    if (item.ExportStatus == 2)
                    {
                        FileHelper.DeleteFile("~/App_File/Export/" + item.FileName);

                        service.Delete_Export(item.PkId);
                    }
                }
            }

            this.JscriptMsg("数据导出任务已建立，请到数据导出页面下载", null, "Success");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.OperateTime = this.txtOperateTime.Text.Trim();
            this.StartTime = this.OperateTime.IsNotNullOrEmpty() ? this.OperateTime.ToStartTime().ToString() : "";
            this.EndTime = this.OperateTime.IsNotNullOrEmpty() ? this.OperateTime.ToEndTime().ToString() : "";
            this.CurrencyNumber = this.txtCurrencyNumber.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.btnExport.Visible = !this.IsUnknowOrg;
            this.spanOrg.Visible = !this.IsUnknowOrg;

            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtDeviceNumber.Text = this.DeviceNumber;
            this.txtOperateTime.Text = this.OperateTime;
            this.txtCurrencyNumber.Text = this.CurrencyNumber;

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
                this.gvList.DataSource = this.CurrentCurrencyInfoList = service.GetList_Info(this.OrgId.ToInt(0), this.IsUnknowOrg, this.StartTime, this.EndTime, this.DeviceNumber, this.CurrencyNumber, this.Paging);

                this.objANP.RecordCount = this.Paging.RowCount.Value;
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