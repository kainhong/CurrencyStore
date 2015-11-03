using System;
using System.Web;
using System.Web.UI;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Web.App_Class
{
    public class BasePage : Page
    {
        public string PermissionID
        {
            get { return this.GetViewState<string>("PermissionID"); }
            set { this.SetViewState("PermissionID", value); }
        }
        public string CheckCode
        {
            get { return this.GetSession<string>("Common_CheckCode"); }
            set { this.SetSession("Common_CheckCode", value); }
        }
        public void CloseFormAutoComplete()
        {
            if (this.Form != null)
            {
                this.Form.Attributes["autocomplete"] = "off";
            }
        }
        public void ClearAllCookie()
        {
            int limit = Request.Cookies.Count;

            for (int i = 0; i < limit; i++)
            {
                Response.Cookies.Add
                (
                    new HttpCookie(Request.Cookies[i].Name) { Expires = DateTime.Now.AddDays(-1) }
                );
            }
        }
        public void ClearAllSession()
        {
            this.Session.Clear();
        }
        public T GetViewState<T>(string key)
        {
            T result = default(T);

            if (this.ViewState[key] != null)
            {
                result = this.ViewState[key].Convert<T>();
            }

            return result;
        }
        public void SetViewState(string key, object value)
        {
            if (key.IsNotNullOrEmpty())
            {
                this.ViewState[key] = value;
            }
        }
        public void RemoveViewState(string key)
        {
            this.ViewState.Remove(key);
        }
        public bool IsAjaxPage()
        {
            return (ScriptManager.GetCurrent(this) != null);
        }
    }
}