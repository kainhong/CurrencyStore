using System;
using System.IO;
using System.Web;
using System.Web.UI;
using CurrencyStore.Common.Web;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class WebExtension
    {
        private static string Key
        {
            get { return "key" + DateTime.Now.ToString("yyyyMMddHHmmmssffff"); }
        }
        public static T GetApplication<T>(this BasePage target, string key)
        {
            T result = default(T);

            if (target.Application[key] != null)
            {
                result = target.Application[key].Convert<T>();
            }

            return result;
        }
        public static void SetApplication(this BasePage target, string key, object value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                target.Application.Lock();

                target.Application[key] = value;

                target.Application.UnLock();
            }
        }
        public static void RemoveApplication(this BasePage target, string key)
        {
            target.Application.Lock();

            target.Application.Remove(key);

            target.Application.UnLock();
        }
        public static T GetSession<T>(this BasePage target, string key)
        {
            T result = default(T);

            if (target.Session[key] != null)
            {
                result = target.Session[key].Convert<T>();
            }

            return result;
        }
        public static void SetSession(this BasePage target, string key, object value)
        {
            if (key.IsNotNullOrEmpty())
            {
                target.Session.Remove(key);
                target.Session.Add(key, value);
            }
        }
        public static void RemoveSession(this BasePage target, string key)
        {
            target.Session.Remove(key);
        }
        public static void RemoveAllSession(this BasePage target)
        {
            target.Session.RemoveAll();
        }
        public static T GetSession<T>(this HttpContext target, string key)
        {
            T result = default(T);

            if (target.Session[key] != null)
            {
                result = target.Session[key].Convert<T>();
            }

            return result;
        }
        public static void SetSession(this HttpContext target, string key, object value)
        {
            if (key.IsNotNullOrEmpty())
            {
                target.Session.Remove(key);
                target.Session.Add(key, value);
            }
        }
        public static void RemoveSession(this HttpContext target, string key)
        {
            target.Session.Remove(key);
        }
        public static void RemoveAllSession(this HttpContext target)
        {
            target.Session.RemoveAll();
        }
        public static bool IsSupportCookie(this BasePage target)
        {
            return target.Request.Browser.Cookies;
        }
        public static T GetCookie<T>(this BasePage target, string key)
        {
            return GetCookie<T>(target, target.Request.Url.Host, key);
        }
        public static T GetCookie<T>(this BasePage target, string cookieName, string key)
        {
            T result = default(T);

            if (target.Request.Cookies != null &&
                target.Request.Cookies[cookieName] != null)
            {
                if (!String.IsNullOrEmpty(HttpContext.Current.Request.Cookies[cookieName][key]))
                {
                    result = target.Request.Cookies[cookieName][key].Convert<T>();
                }
            }

            return result;
        }
        public static void SetCookie(this BasePage target, string key, string value)
        {
            SetCookie(target, target.Request.Url.Host, key, value);
        }
        public static void SetCookie(this BasePage target, string cookieName, string key, string value)
        {
            HttpCookie objHttpCookie = target.Request.Cookies[cookieName];

            if (objHttpCookie == null)
            {
                objHttpCookie = new HttpCookie(cookieName);
            }

            objHttpCookie.Values[key] = value;

            target.Response.AppendCookie(objHttpCookie);
        }
        public static void RemoveCookie(this BasePage target, string cookieName)
        {
            HttpCookie objHttpCookie = target.Request.Cookies[cookieName];

            if (objHttpCookie != null)
            {
                objHttpCookie.Expires = DateTime.Now.AddDays(-1.0);

                target.Response.Cookies.Add(objHttpCookie);
            }
        }
        public static T GetQueryString<T>(this BasePage target, string key)
        {
            T result = default(T);

            if (!String.IsNullOrEmpty(target.Request.QueryString[key]))
            {
                result = target.Request.QueryString[key].Convert<T>();
            }

            return result;
        }
        public static T GetQueryString<T>(this HttpRequest target, string key, T defaultValue)
        {
            T result = default(T);

            if (!String.IsNullOrEmpty(target.QueryString[key]))
            {
                result = target.QueryString[key].Convert<T>();
                return result;
            }
            else
            {
                return (T)(object)defaultValue;
            }
        }
        public static string GetValue(this HttpRequest target, string key)
        {
            string result = null;

            result = target.QueryString[key];

            if (result.IsNullOrEmpty())
            {
                result = target.Form[key];

                if (result.IsNullOrEmpty())
                {
                    result = string.Empty;
                }
            }

            if (result.IsNotNullOrEmpty())
            {
                result = result.Trim();
            }

            return result;
        }
        public static bool IsAjaxPage(this BasePage target)
        {
            return (ScriptManager.GetCurrent(target) != null);
        }
        public static void InsertScript(this BasePage target, string script)
        {
            ScriptManager.RegisterStartupScript(target, target.GetType(), Key, script, true);
        }
        public static void Alert(this BasePage target, string message)
        {
            string script = String.Format(@"alert('{0}');", message);

            InsertScript(target, script);
        }
        public static void AlertAndDo(this BasePage target, string message, string doScript)
        {
            string script = String.Format(@"alert('{0}');{1}", message, doScript);

            InsertScript(target, script);
        }
        public static void Redirect(this BasePage target, string url)
        {
            string script = String.Format(@"window.location.replace('{0}');", url);

            InsertScript(target, script);
        }
        public static void ParentRedirect(this BasePage target, string url)
        {
            string script = String.Format(@"parent.window.location.replace('{0}');", url);

            InsertScript(target, script);
        }
        public static void TopRedirect(this BasePage target, string url)
        {
            string script = String.Format(@"window.top.location.replace('{0}');", url);

            InsertScript(target, script);
        }
        public static void GoHistory(this BasePage target, int value)
        {
            string script = String.Format(@"history.go({0});", value);

            InsertScript(target, script);
        }
        public static void AlertAndRedirect(this BasePage target, string message, string url)
        {
            string script = String.Format(@"alert('{0}');window.location.replace('{1}');", message, url);

            InsertScript(target, script);
        }
        public static void AlertAndParentRedirect(this BasePage target, string message, string url)
        {
            string script = String.Format(@"alert('{0}');parent.window.location.replace('{1}');");

            InsertScript(target, script);
        }
        public static void AlertAndTopRedirect(this BasePage target, string message, string url)
        {
            string script = String.Format(@"alert('{0}');window.top.location.replace('{1}');");

            InsertScript(target, script);
        }
        public static void AlertAndGoHistory(this BasePage target, string message, int value)
        {
            string script = String.Format(@"alert('{0}');history.go({1});", message, value);

            InsertScript(target, script);
        }
        public static void CloseCurrentWindow(this BasePage target)
        {
            string script = @"parent.opener=null;window.close();";

            InsertScript(target, script);
        }
        public static void RefreshOpener(this BasePage target)
        {
            string script = @"opener.location.reload();";

            InsertScript(target, script);
        }
        public static bool SaveFile(this HttpPostedFile target, string uploadFolder, string fileName)
        {
            bool result = false;

            using (FileStream objFileStream = new FileStream(uploadFolder + fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (BinaryWriter objBinaryWriter = new BinaryWriter(objFileStream))
                {
                    byte[] buffer = new byte[1024];
                    int readCount = 0;

                    while ((readCount = target.InputStream.Read(buffer, 0, 1024)) > 0)
                    {
                        objBinaryWriter.Write(buffer, 0, readCount);
                        objBinaryWriter.Flush();
                    }

                    objBinaryWriter.Close();
                    objFileStream.Close();

                    result = true;
                }
            }

            return result;
        }
    }
}
