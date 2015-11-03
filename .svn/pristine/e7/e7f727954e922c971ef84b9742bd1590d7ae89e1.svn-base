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

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Stat_Org_Detail2 : System.Web.UI.Page
    {
        private int OrgId { get { return this.Request.GetValue("OrgId").ToInt(0); } }
        private string StartTime
        {
            get
            {
                string result = this.Request.GetValue("StartTime");

                if (result.IsNotNullOrEmpty())
                {
                    result = result.ToDateTime().ToShortDateString();
                }

                return result;
            }
        }
        private string EndTime
        {
            get
            {
                string result = this.Request.GetValue("EndTime");

                if (result.IsNotNullOrEmpty())
                {
                    result = result.ToDateTime().ToShortDateString();
                }

                return result;
            }
        }
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

            this.lelReportTitle.Text = this.OrgId.ToString().GetOrgName();
            this.lelOperationTime.Text = "操作时间：" + ((this.StartTime.IsNullOrEmpty() && this.EndTime.IsNullOrEmpty()) ? "全部" : "{0} 至 {1}".FormatWith(this.StartTime, this.EndTime));
            this.lelCurrencyKind.Text = "纸币种类：" + this.CurrencyKind.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyKind, "全部");
            this.lelDeviceKind.Text = "设备类别：" + this.DeviceKind.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind, "全部");
            this.lelDeviceModel.Text = "设备型号：" + this.DeviceModel.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel, "全部");

            List<string> xValueList = new List<string>();
            List<double> yValueList = new List<double>();

            foreach (var item in list)
            {
                xValueList.Add(item.FaceAmount);
                yValueList.Add(item.Sum);
            }

            this.chartDetailt.Series["defaultSeries"].Points.DataBindXY(xValueList.ToArray(), yValueList.ToArray());

            this.gvList.DataSource = list;
            this.gvList.DataBind();
        }
    }
}