using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Device_Info_List : ServiceBasePage
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
        private string RegisterIp
        {
            get { return this.ViewState["RegisterIp"] as string; }
            set { this.ViewState["RegisterIp"] = value; }
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

                if (this.IsUnknowOrg)
                {
                    this.hfOrgId.Value = "0";
                }

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IDeviceService service = ServiceFactory.GetService<IDeviceService>();

            foreach (GridViewRow objGVR in this.gvList.Rows)
            {
                if (objGVR.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbSelect = objGVR.FindControl("cbSelect") as CheckBox;

                    if (cbSelect != null && cbSelect.Checked)
                    {
                        int pkId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        service.Delete_Info(pkId);
                    }
                }
            }

            this.JscriptMsg("数据删除成功", null, "Success");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            IDeviceService service = ServiceFactory.GetService<IDeviceService>();

            var deviceInfoList = service.GetList_Info(this.OrgId.ToInt(0), this.IsUnknowOrg, this.DeviceNumber, this.RegisterIp, this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), null);

            if (deviceInfoList.Count == 0)
            {
                this.JscriptMsg("暂无数据，无法导出", null, "Error");

                return;
            }

            DataTable temp = deviceInfoList.ToDataTable();

            string filePath = FileHelper.ConvertPath("~/App_File/Export/" + FileHelper.GetFileNamebyGuid(".xls"));

            temp.SaveToExcel(filePath);

            FileHelper.DownloadFile(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", "application/ms-excel", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.RegisterIp = this.txtRegisterIp.Text.Trim();

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.aEdit.HRef = "Device_Info_Edit.aspx?UserId={0}".FormatWith(this.UserId);
            this.aEdit.Visible = !this.IsUnknowOrg;
            this.btnExport.Visible = !this.IsUnknowOrg;
            this.spanOrg.Visible = !this.IsUnknowOrg;

            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtDeviceNumber.Text = this.DeviceNumber;
            this.txtRegisterIp.Text = this.RegisterIp;

            this.BindDeviceList();

            this.SetSubmitKey();
        }

        private void BindDeviceList()
        {
            IDeviceService service = ServiceFactory.GetService<IDeviceService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Info(this.OrgId.ToInt(0), this.IsUnknowOrg, this.DeviceNumber, this.RegisterIp, this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount;
        }
    }
}