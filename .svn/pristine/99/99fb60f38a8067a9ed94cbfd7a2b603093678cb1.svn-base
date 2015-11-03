using System;
using System.Collections.Generic;
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
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Device_Info_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "Device_Info_List.aspx?UserId={0}&UnknowOrg={1}".FormatWith(this.UserId, this.UnknowOrg);

            if (!this.IsPostBack)
            {
                this.SetOrgSearchByPermission(this.txtOrgName, this.hfOrgId);

                this.BindDeviceKind();
                this.BindDeviceModel();
                this.BindDevice();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IDeviceService service = ServiceFactory.GetService<IDeviceService>();

                bool isRegister = false;
                DeviceInfo entity = null;

                if (this.IsInsert)
                {
                    entity = new DeviceInfo()
                    {
                        DeviceNumber = this.txtDeviceNumber.Text.Trim(),
                        SoftwareVersion = this.txtSoftwareVersion.Text.Trim(),
                        RegisterIp = this.txtRegisterIp.Text.Trim(),
                        KindCode = this.ddlDeviceKind.SelectedValue.ToByte(0),
                        ModelCode = this.ddlDeviceModel.SelectedValue.ToByte(0),
                        OrgId = this.hfOrgId.Value.Trim().ToInt(),
                        OnLineTime = this.txtOnLineTime.Text.Trim().ToDateTime(),
                        DeviceStatus = this.ddlDeviceStatus.SelectedValue.ToByte(0)
                    };

                    if (service.CheckExists_Info(entity))
                    {
                        this.JscriptMsg("设备号码已存在", null, "Error");

                        return;
                    }
                }

                else
                {
                    entity = service.GetObject_Info(this.PkId);

                    if (entity != null)
                    {
                        isRegister = (entity.OrgId == 0 && entity.KindCode == 0 && entity.ModelCode == 0);

                        entity.SoftwareVersion = this.txtSoftwareVersion.Text.Trim();
                        entity.RegisterIp = this.txtRegisterIp.Text.Trim();
                        entity.KindCode = this.ddlDeviceKind.SelectedValue.ToByte(0);
                        entity.ModelCode = this.ddlDeviceModel.SelectedValue.ToByte(0);
                        entity.OrgId = this.hfOrgId.Value.Trim().ToInt();
                        entity.OnLineTime = this.txtOnLineTime.Text.Trim().ToDateTime();
                        entity.DeviceStatus = this.ddlDeviceStatus.SelectedValue.ToByte(0);
                    }
                }

                service.Save_Info(entity);

                if (isRegister)
                {
                    CurrencyInfo objCurrencyInfo = new CurrencyInfo()
                    {
                        OrgId = entity.OrgId,
                        DeviceNumber = entity.DeviceNumber,
                        DeviceKindCode = entity.KindCode,
                        DeviceModelCode = entity.ModelCode
                    };

                    ICurrencyService currencyService = ServiceFactory.GetService<ICurrencyService>();

                    currencyService.BatchRegister_Info(objCurrencyInfo);
                }

                if (this.IsInsert && (sender as Button).CommandName == "SubmitContinue")
                {
                    this.ReturnUrl = this.Request.Url.PathAndQuery;
                }

                this.JscriptMsg("数据保存成功", this.ReturnUrl, "Success");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }

        private void BindDeviceKind()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlDeviceKind.DataTextField = "DictValue";
            this.ddlDeviceKind.DataValueField = "DictKey";
            this.ddlDeviceKind.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.DeviceKind select item).ToList();
            this.ddlDeviceKind.DataBind();
        }

        private void BindDeviceModel()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlDeviceModel.DataTextField = "DictValue";
            this.ddlDeviceModel.DataValueField = "DictKey";
            this.ddlDeviceModel.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.DeviceModel select item).ToList();
            this.ddlDeviceModel.DataBind();
        }

        private void BindDevice()
        {
            if (!this.IsInsert)
            {
                IDeviceService service = ServiceFactory.GetService<IDeviceService>();

                DeviceInfo entity = service.GetObject_Info(this.PkId);

                if (entity != null)
                {
                    this.txtDeviceNumber.Text = entity.DeviceNumber;
                    this.txtSoftwareVersion.Text = entity.SoftwareVersion;
                    this.txtRegisterIp.Text = entity.RegisterIp;
                    this.ddlDeviceKind.SelectedValue = entity.KindCode.ToString();
                    this.ddlDeviceModel.SelectedValue = entity.ModelCode.ToString();
                    this.hfOrgId.Value = entity.OrgId.ToString();
                    this.txtOrgName.Text = entity.OrgId.ToString().GetOrgName();
                    this.txtOnLineTime.Text = entity.OnLineTime.ToString("yyyy-MM-dd");
                    this.ddlDeviceStatus.SelectedValue = entity.DeviceStatus.ToString();

                    this.txtDeviceNumber.ReadOnly = true;
                    this.btnSubmitContinue.Visible = false;
                }

                else
                {
                    this.JscriptMsg("数据不存在", this.ReturnUrl, "Error");
                }
            }
        }
    }
}