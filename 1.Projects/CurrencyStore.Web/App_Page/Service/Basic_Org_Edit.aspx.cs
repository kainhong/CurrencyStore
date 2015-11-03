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
    public partial class Basic_Org_Edit : ServiceBasePage
    {
        private string ReturnUrl
        {
            get;
            set;
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.ReturnUrl = "Basic_Org_List.aspx?UserId={0}".FormatWith(this.UserId);

            if (!this.IsPostBack)
            {
                if (this.IsInsert)
                {
                    this.txtOrgParentName.AddOrgSelector(this.UserId);
                }

                this.BindOrg();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                IBasicService service = ServiceFactory.GetService<IBasicService>();

                BasicOrganization entity = null;

                if (this.IsInsert)
                {
                    entity = new BasicOrganization()
                    {
                        OrgNumber = this.txtOrgNumber.Text.Trim(),
                        OrgName = this.txtOrgName.Text.Trim(),
                        OrgAddress = this.txtOrgAddress.Text.Trim(),
                        OrgParentId = this.hfOrgParentId.Value.Trim().ToInt(0),
                        OrgFullPath = ""
                    };

                    if (service.CheckExists_Organization(entity))
                    {
                        this.JscriptMsg("网点机构号码已存在", null, "Error");

                        return;
                    }
                }

                else
                {
                    entity = service.GetObject_Organization(this.PkId);

                    if (entity != null)
                    {
                        entity.OrgName = this.txtOrgName.Text.Trim();
                        entity.OrgAddress = this.txtOrgAddress.Text.Trim();
                        entity.OrgParentId = this.hfOrgParentId.Value.Trim().ToInt(0);
                    }
                }

                service.Save_Organization(entity);

                if (this.IsInsert)
                {
                    entity.OrgFullPath = entity.OrgParentId.ToString().GetOrgFullPath() + "[" + entity.PkId + "]";

                    service.Save_Organization(entity);
                }

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

        private void BindOrg()
        {
            if (!this.IsInsert)
            {
                IBasicService service = ServiceFactory.GetService<IBasicService>();

                BasicOrganization entity = service.GetObject_Organization(this.PkId);

                if (entity != null)
                {
                    this.txtOrgNumber.Text = entity.OrgNumber;
                    this.txtOrgName.Text = entity.OrgName;
                    this.txtOrgAddress.Text = entity.OrgAddress;
                    this.hfOrgParentId.Value = entity.OrgParentId.ToString();
                    this.txtOrgParentName.Text = entity.OrgParentId.ToString().GetOrgName(true);

                    this.txtOrgNumber.ReadOnly = true;
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