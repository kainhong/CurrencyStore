﻿using System;
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
    public partial class Stat_Currency_List : ServiceBasePage
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
        private string DeviceNumber
        {
            get { return this.ViewState["DeviceNumber"] as string; }
            set { this.ViewState["DeviceNumber"] = value; }
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
                this.BindDeviceKind();
                this.BindDeviceModel();

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            var statCurrencyList = service.GetList_Currency(this.OrgId.ToInt(), this.StartTime, this.EndTime, this.DeviceNumber, this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), null);

            DataTable temp = statCurrencyList.ToDataTable();

            string filePath = FileHelper.ConvertPath("~/App_File/Export/" + FileHelper.GetFileNamebyGuid(".xls"));

            temp.SaveToExcel(filePath);

            FileHelper.DownloadFile(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", "application/ms-excel", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.StartTime = this.txtStartTime.Text.Trim().IsNotNullOrEmpty() ? this.txtStartTime.Text.Trim().ToStartTime().ToString() : "";
            this.EndTime = this.txtEndTime.Text.Trim().IsNotNullOrEmpty() ? this.txtEndTime.Text.Trim().ToEndTime().ToString() : "";
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.DeviceKind = this.ddlDeviceKind.SelectedValue;
            this.DeviceModel = this.ddlDeviceModel.SelectedValue;

            this.objANP.CurrentPageIndex = 1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtStartTime.Text = this.StartTime.IsNotNullOrEmpty() ? this.StartTime.ToDateTime().ToShortDateString() : "";
            this.txtEndTime.Text = this.EndTime.IsNotNullOrEmpty() ? this.EndTime.ToDateTime().ToShortDateString() : "";
            this.txtDeviceNumber.Text = this.DeviceNumber;
            this.ddlDeviceKind.SelectedValue = this.DeviceKind;
            this.ddlDeviceModel.SelectedValue = this.DeviceModel;

            this.BindCurrencyStatList();

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

        private void BindCurrencyStatList()
        {
            IStatService service = ServiceFactory.GetService<IStatService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            if (this.IsPostBack)
            {
                this.gvList.DataSource = service.GetList_Currency(this.OrgId.ToInt(), this.StartTime, this.EndTime, this.DeviceNumber, this.DeviceKind.ToInt(0), this.DeviceModel.ToInt(0), this.Paging);

                this.objANP.RecordCount = this.Paging.RowCount;
            }

            else
            {
                this.gvList.DataSource = new List<CurrencyStatInfo>();

                this.objANP.RecordCount = 0;
            }

            this.gvList.DataBind();
        }
    }
}