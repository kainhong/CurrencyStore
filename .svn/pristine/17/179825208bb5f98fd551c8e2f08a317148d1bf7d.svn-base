using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Device_Online_List : ServiceBasePage
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
        private string CollectorName
        {
            get { return this.ViewState["CollectorName"] as string; }
            set { this.ViewState["CollectorName"] = value; }
        }
        private string DeviceIp
        {
            get { return this.ViewState["DeviceIp"] as string; }
            set { this.ViewState["DeviceIp"] = value; }
        }
        private string ConnectionStatus
        {
            get { return this.ViewState["ConnectionStatus"] as string; }
            set { this.ViewState["ConnectionStatus"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.SetOrgSearchByPermission(this.txtOrgName, this.hfOrgId);

                this.BindConnectionStatus();

                this.btnSearch_Click(null, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgId = this.hfOrgId.Value.Trim();
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.CollectorName = this.txtCollectorName.Text.Trim();
            this.DeviceIp = this.txtDeviceIp.Text.Trim();
            this.ConnectionStatus = this.ddlConnectionStatus.SelectedValue;
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (this.gvList.DataKeys[e.Row.RowIndex]["ConnectionStatus"].ToString().ToInt() == (int)DeviceConnection.ConnectionStatusEnum.Connect)
                {
                    e.Row.Cells[7].Text = String.Empty;
                    e.Row.Cells[8].Text = ConnectionCounter.Current[this.gvList.DataKeys[e.Row.RowIndex]["DeviceNumber"].ToString()].ToString();
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgName.Text = this.OrgId.GetOrgName(true);
            this.txtDeviceNumber.Text = this.DeviceNumber;
            this.txtCollectorName.Text = this.CollectorName;
            this.txtDeviceIp.Text = this.DeviceIp;
            this.ddlConnectionStatus.SelectedValue = this.ConnectionStatus;

            this.BindConnectionList();

            this.SetSubmitKey();
        }

        private void BindConnectionStatus()
        {
            this.ddlConnectionStatus.Items.Clear();

            this.ddlConnectionStatus.Items.Add(new ListItem("全部", "0"));
            this.ddlConnectionStatus.Items.Add(new ListItem("已连接", "1"));
            this.ddlConnectionStatus.Items.Add(new ListItem("未连接", "2"));
        }

        private void BindConnectionList()
        {
            IDeviceService service = ServiceFactory.GetService<IDeviceService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Connection(this.DeviceNumber, this.OrgId.ToInt(0), this.CollectorName, this.DeviceIp, this.ConnectionStatus.ToInt(0), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }
    }
}