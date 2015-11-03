using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Basic_Parameter : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                SystemParameter.DataStorageDays = this.txtDataStorageDays.Text.Trim().ToUInt();
                SystemParameter.DataClearTime = this.txtDataClearTime.Text.Trim();
                SystemParameter.FileStorageCount = this.txtFileStorageCount.Text.Trim().ToUInt();

                SystemParameter.CurrencyInfoColumn = String.Empty;

                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn1.Checked ? "[1]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn2.Checked ? "[2]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn3.Checked ? "[3]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn4.Checked ? "[4]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn5.Checked ? "[5]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn6.Checked ? "[6]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn7.Checked ? "[7]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn8.Checked ? "[8]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn9.Checked ? "[9]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn10.Checked ? "[10]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn11.Checked ? "[11]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn12.Checked ? "[12]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn13.Checked ? "[13]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn14.Checked ? "[14]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn15.Checked ? "[15]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn16.Checked ? "[16]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn17.Checked ? "[17]" : "";
                SystemParameter.CurrencyInfoColumn += this.cbCurrencyInfoColumn18.Checked ? "[18]" : "";

                SystemParameter.Save();

                this.JscriptMsg("数据保存成功", null, "Success");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindParameter();

            this.SetSubmitKey();
        }

        private void BindParameter()
        {
            this.txtDataStorageDays.Text = SystemParameter.DataStorageDays.ToString();
            this.txtDataClearTime.Text = SystemParameter.DataClearTime;
            this.txtFileStorageCount.Text = SystemParameter.FileStorageCount.ToString();

            this.cbCurrencyInfoColumn1.Checked = SystemParameter.CurrencyInfoColumn.Contains("[1]");
            this.cbCurrencyInfoColumn2.Checked = SystemParameter.CurrencyInfoColumn.Contains("[2]");
            this.cbCurrencyInfoColumn3.Checked = SystemParameter.CurrencyInfoColumn.Contains("[3]");
            this.cbCurrencyInfoColumn4.Checked = SystemParameter.CurrencyInfoColumn.Contains("[4]");
            this.cbCurrencyInfoColumn5.Checked = SystemParameter.CurrencyInfoColumn.Contains("[5]");
            this.cbCurrencyInfoColumn6.Checked = SystemParameter.CurrencyInfoColumn.Contains("[6]");
            this.cbCurrencyInfoColumn7.Checked = SystemParameter.CurrencyInfoColumn.Contains("[7]");
            this.cbCurrencyInfoColumn8.Checked = SystemParameter.CurrencyInfoColumn.Contains("[8]");
            this.cbCurrencyInfoColumn9.Checked = SystemParameter.CurrencyInfoColumn.Contains("[9]");
            this.cbCurrencyInfoColumn10.Checked = SystemParameter.CurrencyInfoColumn.Contains("[10]");
            this.cbCurrencyInfoColumn11.Checked = SystemParameter.CurrencyInfoColumn.Contains("[11]");
            this.cbCurrencyInfoColumn12.Checked = SystemParameter.CurrencyInfoColumn.Contains("[12]");
            this.cbCurrencyInfoColumn13.Checked = SystemParameter.CurrencyInfoColumn.Contains("[13]");
            this.cbCurrencyInfoColumn14.Checked = SystemParameter.CurrencyInfoColumn.Contains("[14]");
            this.cbCurrencyInfoColumn15.Checked = SystemParameter.CurrencyInfoColumn.Contains("[15]");
            this.cbCurrencyInfoColumn16.Checked = SystemParameter.CurrencyInfoColumn.Contains("[16]");
            this.cbCurrencyInfoColumn17.Checked = SystemParameter.CurrencyInfoColumn.Contains("[17]");
            this.cbCurrencyInfoColumn18.Checked = SystemParameter.CurrencyInfoColumn.Contains("[18]");
        }
    }
}