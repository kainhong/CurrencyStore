using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Device_Change_List : ServiceBasePage
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

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.RegisterIp = this.txtRegisterIp.Text.Trim();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtDeviceNumber.Text = this.DeviceNumber;

            this.BindChangeList();

            this.SetSubmitKey();
        }

        private void BindChangeList()
        {
            IDeviceService service = ServiceFactory.GetService<IDeviceService>();

            var deviceInfoList = service.GetAllList_Info();
            var deviceConnectionList = service.GetAllList_Connection();

            var list = from deviceInfo in deviceInfoList
                       join deviceConnection in deviceConnectionList
                       on deviceInfo.DeviceNumber equals deviceConnection.DeviceNumber
                       where deviceInfo.RegisterIp != deviceConnection.DeviceIp
                       select new
                       {
                           OrgId = deviceInfo.OrgId,
                           DeviceNumber = deviceInfo.DeviceNumber,
                           SoftwareVersion = deviceInfo.SoftwareVersion,
                           RegisterIp = deviceInfo.RegisterIp,
                           DeviceIp = deviceConnection.DeviceIp,
                           KindCode = deviceInfo.KindCode,
                           ModelCode = deviceInfo.ModelCode
                       };

            if (this.OrgId.ToInt(0) > 0)
            {
                list = from item in list where item.OrgId == this.OrgId.ToInt(0) select item;
            }

            if (this.DeviceNumber.IsNotNullOrEmpty())
            {
                list = from item in list where item.DeviceNumber == this.DeviceNumber select item;
            }

            if (this.RegisterIp.IsNotNullOrEmpty())
            {
                list = from item in list where item.RegisterIp == this.RegisterIp select item;
            }

            this.gvList.DataSource = list;
            this.gvList.DataBind();
        }
    }
}