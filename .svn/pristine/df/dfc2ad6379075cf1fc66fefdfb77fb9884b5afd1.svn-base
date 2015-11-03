using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Query;
using CurrencyStore.Common.Web;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;

namespace CurrencyStore.Web.App_Class
{
    public class ServiceBasePage : BasePage
    {
        public int PkId { get { return Request.GetValue("PkId").ToInt(0); } }
        public bool IsInsert { get { return this.PkId == 0; } }
        public string Kind { get { return Request.GetValue("Kind"); } }
        public string UnknowOrg { get { return Request.GetValue("UnknowOrg"); } }
        public bool IsUnknowOrg { get { return this.UnknowOrg == "1"; } }
        public string UserId
        {
            get
            {
                string result = Request.GetValue("UserId");

                if (result.IsNullOrEmpty())
                {
                    result = this.TempUserId;
                }

                return result;
            }
        }
        public string TempUserId
        {
            get { return this.GetSession<string>("Admin_TempUserId"); }
            set { this.SetSession("Admin_TempUserId", value); }
        }
        public UserInfo CurrentUser
        {
            get { return this.GetSession<UserInfo>("Admin_UserInfo_" + this.UserId); }
            set { this.SetSession("Admin_UserInfo_" + this.UserId, value); }
        }
        public UserRole CurrentUserRole
        {
            get { return this.GetSession<UserRole>("Admin_CurrentUserRole_" + this.UserId); }
            set { this.SetSession("Admin_CurrentUserRole_" + this.UserId, value); }
        }
        public List<string> CurrentUserRolePermissionList
        {
            get { return this.GetSession<List<string>>("Admin_CurrentUserRolePermissionList_" + this.UserId); }
            set { this.SetSession("Admin_CurrentUserRolePermissionList_" + this.UserId, value); }
        }
        public List<CurrencyInfo> CurrentCurrencyInfoList
        {
            get { return this.GetSession<List<CurrencyInfo>>("Admin_CurrentCurrencyInfoList_" + this.UserId); }
            set { this.SetSession("Admin_CurrentCurrencyInfoList_" + this.UserId, value); }
        }
        public Pagination Paging { get; set; }
        public string SubmitKeyForSession
        {
            get { return this.GetSession<string>("Admin_SubmitKey_" + this.Request.RawUrl + "_" + this.UserId); }
            set { this.SetSession("Admin_SubmitKey_" + this.Request.RawUrl + "_" + this.UserId, value); }
        }
        public string SubmitKeyForViewState
        {
            get { return this.GetViewState<string>("Admin_SubmitKey_" + this.UserId); }
            set { this.SetViewState("Admin_SubmitKey_" + this.UserId, value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.UserId.IsNullOrEmpty() || this.CurrentUser == null || this.CurrentUserRole == null) && !Request.Path.Contains("Login.aspx"))
            {
                Response.Redirect("Login.aspx");
            }

            if (this.IsPostBack)
            {
                this.CheckSubmitKey();
            }

            //this.CheckPermission();

            this.Paging = new Pagination() { Paging = true };
        }

        /// <summary>
        /// 设置提交密钥
        /// </summary>
        public void SetSubmitKey()
        {
            string submitKey = ApplicationHelper.GetNewGuid().ToUpper();

            this.SubmitKeyForSession = submitKey;
            this.SubmitKeyForViewState = submitKey;
        }

        /// <summary>
        /// 检查提交密钥
        /// </summary>
        /// <returns>true->成功,false->失败</returns>
        public bool CheckSubmitKey()
        {
            bool result = false;

            string vKey = this.SubmitKeyForViewState;
            string sKey = this.SubmitKeyForSession;

            this.SubmitKeyForSession = null;

            result = sKey == vKey;

            if (!result)
            {
                Server.Transfer("DoubleSubmitTip.html");
            }

            return result;
        }

        private void CheckPermission()
        {
            if (this.PermissionID.IsNotNullOrEmpty())
            {
                if (this.CurrentUserRolePermissionList == null || !this.CurrentUserRolePermissionList.Contains(this.PermissionID))
                {
                    Response.Redirect("NoPermission.html");
                }
            }
        }

        #region JS提示
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion

        public string GetStartTime(int type)
        {
            string result = "";

            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now.AddMonths(-1);

            switch (type)
            {
                case 1:
                    result = a.ToShortDateString();
                    break;
                case 2:
                    result = a.AddDays(-1).ToShortDateString();
                    break;
                case 3:
                    result = a.AddDays(1 - a.Day).ToShortDateString();
                    break;
                case 4:
                    result = b.AddDays(1 - b.Day).ToShortDateString();
                    break;
            }

            return result;
        }

        public string GetEndTime(int type)
        {
            string result = "";

            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now.AddMonths(-1);

            switch (type)
            {
                case 1:
                    result = a.ToShortDateString();
                    break;
                case 2:
                    result = a.AddDays(-1).ToShortDateString();
                    break;
                case 3:
                    result = a.AddDays(1 - a.Day).AddMonths(1).AddDays(-1).ToShortDateString();
                    break;
                case 4:
                    result = b.AddDays(1 - b.Day).AddMonths(1).AddDays(-1).ToShortDateString();
                    break;
            }

            return result;

        }

        public void SetOrgSearchByPermission(TextBox txtOrgName, HiddenField hfOrgId, bool defaultEmpty = true)
        {
            txtOrgName.AddOrgSelector(this.UserId, defaultEmpty);

            if (defaultEmpty && (this.CurrentUserRole.DataFilter == (int)UserRole.DataFilterEnum.NoFilter))
            {
                txtOrgName.Text = "";
                hfOrgId.Value = "0";
            }

            else //if (this.CurrentUserRole.DataFilter == (int)UserRole.DataFilterEnum.Filter)
            {
                txtOrgName.Text = this.CurrentUser.OrgId.ToString().GetOrgName();
                hfOrgId.Value = this.CurrentUser.OrgId.ToString();
            }
        }

        public void SetDateTimeSearch(TextBox txtStartTime = null, TextBox txtEndTime = null)
        {
            if (txtStartTime != null)
            {
                txtStartTime.Text = DateTime.Now.ToShortDateString();

                txtStartTime.AddDateTimeSelector();
            }

            if (txtEndTime != null)
            {
                txtEndTime.Text = DateTime.Now.ToShortDateString();

                txtEndTime.AddDateTimeSelector();
            }
        }
    }
}