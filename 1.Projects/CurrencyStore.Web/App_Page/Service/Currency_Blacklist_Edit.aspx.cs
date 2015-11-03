using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Currency_Blacklist_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "Currency_Blacklist_List.aspx?UserId={0}".FormatWith(this.UserId);

            if (!this.IsPostBack)
            {
                this.BindCurrencyKind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                ICurrencyService service = ServiceFactory.GetService<ICurrencyService>();

                CurrencyBlacklist entity = null;

                if (this.IsInsert)
                {
                    entity = new CurrencyBlacklist()
                    {
                        CurrencyKindCode = this.ddlCurrencyKind.SelectedValue.ToByte(0),
                        FaceAmount = this.txtFaceAmount.Text.Trim().ToShort(0),
                        CurrencyVersion = this.txtCurrencyVersion.Text.Trim().ToShort(0),
                        CurrencyNumber = this.txtCurrencyNumber.Text.Trim()
                    };

                    if (service.CheckExists_Blacklist(entity))
                    {
                        this.JscriptMsg("纸币号码已存在", null, "Error");

                        return;
                    }
                }

                service.Save_Blacklist(entity);

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

        private void BindCurrencyKind()
        {
            var allDictList = ServiceFactory.GetService<IBasicService>().GetList_Dictionary();

            this.ddlCurrencyKind.DataTextField = "DictValue";
            this.ddlCurrencyKind.DataValueField = "DictKey";
            this.ddlCurrencyKind.DataSource = (from item in allDictList where item.DictKind == (sbyte)BasicDictionary.DictKindEnum.CurrencyKind select item).ToList();
            this.ddlCurrencyKind.DataBind();
        }
    }
}