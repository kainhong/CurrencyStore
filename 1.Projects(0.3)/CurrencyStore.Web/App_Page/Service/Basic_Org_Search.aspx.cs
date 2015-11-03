using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Basic_Org_Search : ServiceBasePage
    {
        public bool DefaultEmpty
        {
            get { return Request.GetValue("DefaultEmpty").ToInt(0).ToBool(); }
        }
        private string DefaultOrgId
        {
            get
            {
                string result = "0";

                if (this.CurrentUserRole.DataFilter == (int)UserRole.DataFilterEnum.Filter)
                {
                    result = this.CurrentUser.OrgId.ToString();
                }

                return result;
            }
        }
        private string OrgParentId
        {
            get
            {
                string result = Request.GetValue("OrgParentId");

                if (result.IsNullOrEmpty())
                {
                    result = this.DefaultOrgId;
                }

                return result;
            }
        }
        private string OrgNumber
        {
            get { return this.ViewState["OrgNumber"] as string; }
            set { this.ViewState["OrgNumber"] = value; }
        }
        private string OrgName
        {
            get { return this.ViewState["OrgName"] as string; }
            set { this.ViewState["OrgName"] = value; }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!this.IsPostBack)
            {
                this.btnSearch_Click(null, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.OrgNumber = this.txtOrgNumber.Text.Trim();
            this.OrgName = this.txtOrgName.Text.Trim();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlAnchor aSelect = e.Row.FindControl("aSelect") as HtmlAnchor;
                HiddenField hfOrgId = e.Row.FindControl("hfOrgId") as HiddenField;
                HiddenField hfOrgName = e.Row.FindControl("hfOrgName") as HiddenField;

                aSelect.Attributes.Add("href", "javascript:parent.setOrgSearchValue($('#{0}').attr('value'), $('#{1}').attr('value'));".FormatWith(hfOrgId.ClientID, hfOrgName.ClientID));
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.txtOrgNumber.Text = this.OrgNumber;
            this.txtOrgName.Text = this.OrgName;

            this.hfDefaultOrgId.Value = this.DefaultOrgId;
            this.hfDefaultOrgName.Value = this.DefaultOrgId.GetOrgName(true);
            this.aDefaultOrg.Attributes.Add("href", "javascript:parent.setOrgSearchValue($('#{0}').attr('value'), $('#{1}').attr('value'));".FormatWith(this.hfDefaultOrgId.ClientID, this.hfDefaultOrgName.ClientID));

            if (!this.DefaultEmpty)
            {
                this.hfDefaultOrgId.Value = this.CurrentUser.OrgId.ToString();
                this.hfDefaultOrgName.Value = this.CurrentUser.OrgId.ToString().GetOrgName(true);
            }

            this.CreateOrgPath();

            this.BindOrgList();
        }

        private void BindOrgList()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            this.Paging.CurrentPageIndex = this.objANP.CurrentPageIndex;
            this.Paging.PageSize = this.objANP.PageSize;

            this.gvList.DataSource = service.GetList_Organization(0, this.OrgNumber, this.OrgName, this.OrgParentId.ToInt(0), this.Paging);
            this.gvList.DataBind();

            this.objANP.RecordCount = this.Paging.RowCount.Value;
        }

        private void CreateOrgPath()
        {
            StringBuilder result = new StringBuilder();

            int defaultOrgId = this.DefaultOrgId.ToInt(0);

            this.CreateOrgPathNode(result, this.OrgParentId.ToInt(0), defaultOrgId);

            if (defaultOrgId > 0)
            {
                result.Insert(0, "所有网点机构");
            }

            else
            {
                result.Insert(0, "<a href=\"Basic_Org_Search.aspx?UserId={0}&DefaultEmpty={1}&OrgParentId=0\">所有网点机构</a>".FormatWith(this.UserId, this.DefaultEmpty.ToInt()));
            }

            this.lelParentPath.Text = result.ToString();
        }

        private void CreateOrgPathNode(StringBuilder result, int orgId, int defaultOrgId)
        {
            BasicOrganization org = (from item in BasicConvert.OrganizationList where item.PkId == orgId select item).SingleOrDefault();

            if (org != null && org.PkId > 0)
            {
                if (org.PkId < defaultOrgId)
                {
                    result.Insert(0, "&nbsp;&gt;&nbsp;{0}".FormatWith(org.OrgName));
                }

                else
                {
                    result.Insert(0, "&nbsp;&gt;&nbsp;<a href=\"Basic_Org_Search.aspx?UserId={0}&DefaultEmpty={1}&OrgParentId={2}\">{3}</a>".FormatWith(this.UserId, this.DefaultEmpty.ToInt(), org.PkId, org.OrgName));
                }

                if (org.OrgParentId > 0)
                {
                    this.CreateOrgPathNode(result, org.OrgParentId, defaultOrgId);
                }
            }
        }
    }
}