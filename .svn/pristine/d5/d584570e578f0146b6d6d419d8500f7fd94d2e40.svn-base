using System;
using System.Collections.Generic;
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

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Basic_Dict_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "Basic_Dict_List.aspx?UserId={0}&Kind={1}".FormatWith(this.UserId, this.Kind);

            if (!this.IsPostBack)
            {
                this.BindDict();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IBasicService service = ServiceFactory.GetService<IBasicService>();

                BasicDictionary entity = null;

                if (this.IsInsert)
                {
                    entity = new BasicDictionary()
                    {
                        DictKind = this.Kind.ToByte(0),
                        DictKey = this.txtDictKey.Text.Trim().ToByte(0),
                        DictValue = this.txtDictValue.Text.Trim(),
                        IsSystem = 0
                    };

                    if (service.CheckExists_Dictionary(entity))
                    {
                        this.JscriptMsg("字典数据键已存在", null, "Error");

                        return;
                    }
                }

                else
                {
                    entity = service.GetObject_Dictionary(this.PkId);

                    if (entity != null)
                    {
                        entity.DictValue = this.txtDictValue.Text.Trim();
                    }
                }

                service.Save_Dictionary(entity);

                if (this.IsInsert && (sender as Button).CommandName == "SubmitContinue")
                {
                    this.ReturnUrl = this.Request.Url.PathAndQuery;
                }

                this.JscriptMsg("数据保存成功", this.ReturnUrl, "Success");
            }

            BasicConvert.ClearCache();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }

        private void BindDict()
        {
            if (!this.IsInsert)
            {
                IBasicService service = ServiceFactory.GetService<IBasicService>();

                BasicDictionary entity = service.GetObject_Dictionary(this.PkId);

                if (entity != null)
                {
                    this.txtDictKey.Text = entity.DictKey.ToString();
                    this.txtDictValue.Text = entity.DictValue;

                    this.txtDictKey.ReadOnly = true;
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