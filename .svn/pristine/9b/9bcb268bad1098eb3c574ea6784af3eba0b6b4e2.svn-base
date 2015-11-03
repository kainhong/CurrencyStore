using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace CurrencyStore.Utility
{
    public class ApplicationHelper
    {
        public static void InitSystem()
        {
        }
        public static void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
        }
        public static string GetDomain(bool withPrefix, bool withSuffix)
        {
            string result = withPrefix ? @"http://" : "";

            if (HttpContext.Current.Request.ApplicationPath.Equals("/"))
            {
                result += HttpContext.Current.Request.Url.Authority;
            }

            else
            {
                result += HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
            }

            result += withSuffix ? @"/" : "";

            return result.ToLower();
        }
        public static string GetClientIp()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //可能有代理    
            if (!string.IsNullOrWhiteSpace(result))
            {
                //没有"." 肯定是非IP格式   
                if (result.IndexOf(".") == -1)
                {
                    result = null;
                }
                else
                {
                    //有","，估计多个代理。取第一个不是内网的IP。   
                    if (result.IndexOf(",") != -1)
                    {
                        result = result.Replace(" ", string.Empty).Replace("\"", string.Empty);

                        string[] temparyip = result.Split(",;".ToCharArray());

                        if (temparyip != null && temparyip.Length > 0)
                        {
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                //找到不是内网的地址   
                                if (IsIpAddress(temparyip[i])
                                    && temparyip[i].Substring(0, 3) != "10."
                                    && temparyip[i].Substring(0, 7) != "192.168"
                                    && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];
                                }
                            }
                        }
                    }
                    //代理即是IP格式   
                    else if (IsIpAddress(result))
                    {
                        return result;
                    }
                    //代理中的内容非IP   
                    else
                    {
                        result = null;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (result.Equals("::1"))
            {
                result = "127.0.0.1";
            }

            return result;

        }
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
        public static bool IsIpAddress(string target)
        {
            if (string.IsNullOrWhiteSpace(target) || target.Length < 7 || target.Length > 15)
            {
                return false;
            }

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}{1}quot;";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(target);
        }
    }
}
