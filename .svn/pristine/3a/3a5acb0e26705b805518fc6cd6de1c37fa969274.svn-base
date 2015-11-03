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
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Stat_Device_List : ServiceBasePage
    {
        private string OrgId
        {
            get { return this.ViewState["OrgId"] as string; }
            set { this.ViewState["OrgId"] = value; }
        }
        public string DeviceKind
        {
            get { return this.ViewState["DeviceKind"] as string; }
            set { this.ViewState["DeviceKind"] = value; }
        }
        public string DeviceModel
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

                this.BindDeviceKind();
                this.BindDeviceModel();

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            var statDeviceList = service.GetList_Device(this.OrgId.ToInt(0), this.OrgId.ToInt(0).ToString().GetOrgFullPath(), this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), null);

            DataTable temp = statDeviceList.ToDataTable();

            string filePath = FileHelper.ConvertPath("~/App_File/Export/" + FileHelper.GetFileNamebyGuid(".xls"));

            temp.SaveToExcel(filePath);

            FileHelper.DownloadFile(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", "application/ms-excel", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.DeviceKind = this.ddlDeviceKind.SelectedValue;
            this.DeviceModel = this.ddlDeviceModel.SelectedValue;

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.ddlDeviceKind.SelectedValue = this.DeviceKind;
            this.ddlDeviceModel.SelectedValue = this.DeviceModel;

            this.BindDeviceStatList();

            this.SetSubmitKey();
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

        private void BindDeviceStatList()
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            if (this.IsPostBack)
            {
                this.gvList.DataSource = service.GetList_Device(this.OrgId.ToInt(0), this.OrgId.ToInt(0).ToString().GetOrgFullPath(), this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), this.Paging);

                this.objANP.RecordCount = this.Paging.RowCount;
            }

            else
            {
                this.gvList.DataSource = new List<DeviceStatInfo>();

                this.objANP.RecordCount = 0;
            }

            this.gvList.DataBind();
        }

    }
}