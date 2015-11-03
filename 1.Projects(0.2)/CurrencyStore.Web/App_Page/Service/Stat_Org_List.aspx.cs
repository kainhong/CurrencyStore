using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Stat_Org_List : ServiceBasePage
    {
        private string OrgId
        {
            get { return this.ViewState["OrgId"] as string; }
            set { this.ViewState["OrgId"] = value; }
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
        private string CurrencyKind
        {
            get { return this.ViewState["CurrencyKind"] as string; }
            set { this.ViewState["CurrencyKind"] = value; }
        }
        private string DeviceKind
        {
            get { return this.ViewState["DeviceKind"] as string; }
            set { this.ViewState["DeviceKind"] = value; }
        }
        private string DeviceModel
        {
            get { return this.ViewState["DeviceModel"] as string; }
            set { this.ViewState["DeviceModel"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.SetOrgSearchByPermission(this.txtOrgName, this.hfOrgId);
                this.SetDateTimeSearch(this.txtStartTime, this.txtEndTime);
                this.BindCurrencyKind();
                this.BindDeviceKind();
                this.BindDeviceModel();

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            var statOrgList = service.GetList_Org(this.OrgId.ToInt(0), null, null, this.CurrencyKind.ToInt(0), this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), null);

            DataTable temp = this.ToDataTable(statOrgList);

            string filePath = FileHelper.ConvertPath("~/App_File/Export/" + FileHelper.GetFileNamebyGuid(".xls"));

            temp.SaveToExcel(filePath);

            FileHelper.DownloadFile(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", "application/ms-excel", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.StartTime = this.txtStartTime.Text.Trim().IsNotNullOrEmpty() ? this.txtStartTime.Text.Trim().ToStartTime().ToString() : "";
            this.EndTime = this.txtEndTime.Text.Trim().IsNotNullOrEmpty() ? this.txtEndTime.Text.Trim().ToEndTime().ToString() : "";
            this.CurrencyKind = this.ddlCurrencyKind.SelectedValue;
            this.DeviceKind = this.ddlDeviceKind.SelectedValue;
            this.DeviceModel = this.ddlDeviceModel.SelectedValue;
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlAnchor aDetail = e.Row.FindControl("aDetail") as HtmlAnchor;

                if (aDetail != null)
                {
                    string orgId = this.gvList.DataKeys[e.Row.RowIndex]["OrgId"].ToString();

                    aDetail.HRef = "javascript:openDialog('网点明细统计详情', 'Stat_Org_Detail2.aspx?OrgId={0}&StartTime={1}&EndTime={2}&CurrencyKind={3}&DeviceKind={4}&DeviceModel={5}', 750, 400)"
                        .FormatWith(orgId, this.StartTime, this.EndTime, this.CurrencyKind, this.DeviceKind, this.DeviceModel);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtStartTime.Text = this.StartTime.IsNotNullOrEmpty() ? this.StartTime.ToDateTime().ToShortDateString() : "";
            this.txtEndTime.Text = this.EndTime.IsNotNullOrEmpty() ? this.EndTime.ToDateTime().ToShortDateString() : "";
            this.ddlCurrencyKind.SelectedValue = this.CurrencyKind;
            this.ddlDeviceKind.SelectedValue = this.DeviceKind;
            this.ddlDeviceModel.SelectedValue = this.DeviceModel;

            this.BindOrgStatList();

            this.SetSubmitKey();
        }

        private void BindCurrencyKind()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlCurrencyKind.DataTextField = "DictValue";
            this.ddlCurrencyKind.DataValueField = "DictKey";
            this.ddlCurrencyKind.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.CurrencyKind select item).ToList();
            this.ddlCurrencyKind.DataBind();
        }

        private void BindDeviceKind()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlDeviceKind.DataTextField = "DictValue";
            this.ddlDeviceKind.DataValueField = "DictKey";
            this.ddlDeviceKind.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.DeviceKind select item).ToList();
            this.ddlDeviceKind.DataBind();

            this.ddlDeviceKind.Items.Insert(0, new ListItem("全部", "0"));
        }

        private void BindDeviceModel()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlDeviceModel.DataTextField = "DictValue";
            this.ddlDeviceModel.DataValueField = "DictKey";
            this.ddlDeviceModel.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.DeviceModel select item).ToList();
            this.ddlDeviceModel.DataBind();

            this.ddlDeviceModel.Items.Insert(0, new ListItem("全部", "0"));
        }

        private void BindOrgStatList()
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Org(this.OrgId.ToInt(0), this.StartTime, this.EndTime, this.CurrencyKind.ToInt(0), this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }

        private DataTable ToDataTable(List<OrganizationStatInfo> statOrgList)
        {
            DataTable result = new DataTable("网点明细统计");

            result.Columns.Add("网点机构_25", typeof(string));
            result.Columns.Add("纸币数量_10", typeof(string));
            result.Columns.Add("纸币总额_10", typeof(string));

            foreach (var item in statOrgList)
            {
                DataRow objDR = result.NewRow();

                objDR[0] = item.OrgId.ToString().GetOrgName();
                objDR[1] = item.Count;
                objDR[2] = item.Sum;

                result.Rows.Add(objDR);
            }

            return result;
        }
    }
}