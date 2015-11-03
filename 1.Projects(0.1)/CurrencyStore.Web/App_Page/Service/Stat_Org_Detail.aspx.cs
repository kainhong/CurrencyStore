using System;
using System.Collections.Generic;
using System.Data;
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
using CurrencyStore.Web.App_Report;
using Microsoft.Reporting.WebForms;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Stat_Org_Detail : System.Web.UI.Page
    {
        private int OrgId { get { return this.Request.GetValue("OrgId").ToInt(0); } }
        private int CurrencyKind { get { return this.Request.GetValue("CurrencyKind").ToInt(0); } }
        private int DeviceKind { get { return this.Request.GetValue("DeviceKind").ToInt(0); } }
        private int DeviceModel { get { return this.Request.GetValue("DeviceModel").ToInt(0); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindReport();
            }
        }
        private void BindReport()
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            List<OrganizationStatDetailInfo> list = service.GetList_OrgDetail(this.OrgId, null, null, this.CurrencyKind, this.DeviceKind, this.DeviceModel);

            this.rvDetail.LocalReport.ReportPath = Server.MapPath("~/App_Report/Stat_Org_Detail.rdlc");
            this.rvDetail.LocalReport.EnableExternalImages = true;

            this.BindReportParameter(this.rvDetail);
            this.BindReportDataSet(this.rvDetail, list);

            this.rvDetail.LocalReport.Refresh();
        }
        private void BindReportParameter(ReportViewer rv)
        {
            IList<ReportParameter> rpList = new List<ReportParameter>() 
            {
                new ReportParameter("rpReportTitle", this.OrgId.ToString().GetOrgName()),
                new ReportParameter("rpCurrencyKind", "纸币种类：" + this.CurrencyKind.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyKind, "全部")),
                new ReportParameter("rpDeviceKind", "设备类别：" + this.DeviceKind.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind, "全部")),
                new ReportParameter("rpDeviceModel",  "设备型号：" + this.DeviceModel.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel, "全部"))
            };

            rv.LocalReport.SetParameters(rpList.ToArray());
        }
        private void BindReportDataSet(ReportViewer rv, List<OrganizationStatDetailInfo> dataSource)
        {
            ReportData ds = new ReportData();
            DataTable dt = ds.Tables["CurrencyStat"];
            DataRow dr = dt.NewRow();

            foreach (OrganizationStatDetailInfo item in dataSource)
            {
                dr = dt.NewRow();

                dr["FaceAmount"] = item.FaceAmount;
                dr["Count"] = item.Count;
                dr["Sum"] = item.Sum;

                dt.Rows.Add(dr);
            }

            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(new ReportDataSource("dsCurrencyStat", ds.Tables["CurrencyStat"]));
        }
    }
}