using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class StringExtension
    {
        public static string T1 = "    ";
        public static string T2 = "        ";
        public static string T3 = "            ";
        public static string T4 = "                ";
        public static string NewLine1 = Environment.NewLine;
        public static string NewLine2 = Environment.NewLine + Environment.NewLine;
        public static bool IsInt(this string target)
        {
            int temp = default(int);

            return int.TryParse(target, out temp);
        }
        public static int ToInt(this string target)
        {
            int result = default(int);

            int.TryParse(target, out result);

            return result;
        }
        public static int ToInt(this string target, int defaultValue)
        {
            int result = default(int);

            if (!int.TryParse(target, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static uint ToUInt(this string target)
        {
            uint result = default(uint);

            uint.TryParse(target, out result);

            return result;
        }
        public static uint ToUInt(this string target, uint defaultValue)
        {
            uint result = default(uint);

            if (!uint.TryParse(target, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static byte ToByte(this string target, byte defaultValue)
        {
            byte result = default(byte);

            if (!byte.TryParse(target, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static short ToShort(this string target, short defaultValue)
        {
            short result = default(short);

            if (!short.TryParse(target, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static bool IsDecimal(this string target)
        {
            decimal temp = default(decimal);

            return decimal.TryParse(target, out temp);
        }
        public static decimal ToDecimal(this string target)
        {
            decimal result = default(decimal);

            decimal.TryParse(target, out result);

            return result;
        }
        public static bool IsBool(this string target)
        {
            bool temp = default(bool);

            return bool.TryParse(target, out temp);
        }
        public static bool ToBool(this string target)
        {
            bool result = default(bool);

            bool.TryParse(target, out result);

            return result;
        }
        public static bool IsDateTime(this string target)
        {
            DateTime temp = default(DateTime);

            return DateTime.TryParse(target, out temp);
        }
        public static DateTime ToDateTime(this string target)
        {
            DateTime result = default(DateTime);

            DateTime.TryParse(target, out result);

            return result;
        }
        public static DateTime ToDateTime(this string target, DateTime defaultValue)
        {
            DateTime result = default(DateTime);

            if (!DateTime.TryParse(target, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static DateTime ToStartTime(this string target)
        {
            DateTime temp = target.ToDateTime();

            return new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 0);
        }
        public static DateTime ToEndTime(this string target)
        {
            DateTime temp = target.ToDateTime();

            return new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59);
        }
        public static bool IsNullOrEmpty(this string target)
        {
            return String.IsNullOrEmpty(target);
        }
        public static bool IsNotNullOrEmpty(this string target)
        {
            return !String.IsNullOrEmpty(target);
        }
        public static bool IsMatch(this string target, string pattern)
        {
            bool result = false;

            if (target != null)
            {
                result = Regex.IsMatch(target, pattern);
            }

            return result;
        }
        public static string GetMatch(this string target, string pattern)
        {
            string result = null;

            if (target != null)
            {
                result = Regex.Match(target, pattern).Value;
            }

            return result;
        }
        public static string ToSBC(this string target)
        {
            char[] c = target.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;

                    continue;
                }

                if (c[i] < 127)
                {
                    c[i] = (char)(c[i] + 65248);
                }
            }

            return new string(c);
        }
        public static string ToDBC(this string target)
        {
            char[] c = target.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;

                    continue;
                }

                if (c[i] > 65280 && c[i] < 65375)
                {
                    c[i] = (char)(c[i] - 65248);
                }
            }

            return new string(c);
        }
        public static string FormatWith(this string target, object arg0)
        {
            return String.Format(target, arg0);
        }
        public static string FormatWith(this string target, object arg0, object arg1)
        {
            return String.Format(target, arg0, arg1);
        }
        public static string FormatWith(this string target, object arg0, object arg1, object arg2)
        {
            return String.Format(target, arg0, arg1, arg2);
        }
        public static string FormatWith(this string target, params object[] args)
        {
            return String.Format(target, args);
        }
        public static string SurroundWith(this string target, string formatter)
        {
            return string.Format(formatter, target);
        }
        public static String SubFullString(this string target, int length)
        {
            string result = null;

            if (!String.IsNullOrEmpty(target))
            {
                byte[] bytes = Encoding.Unicode.GetBytes(target);

                int n = 0;
                int i = 0;

                for (; i < bytes.GetLength(0) && n < length; i++)
                {
                    if (i % 2 == 0)
                    {
                        n++;
                    }

                    else
                    {
                        if (bytes[i] > 0)
                        {
                            n++;
                        }
                    }
                }

                if (i % 2 == 1)
                {
                    if (bytes[i] > 0)
                    {
                        i = i - 1;
                    }

                    else
                    {
                        i = i + 1;
                    }
                }

                result = Encoding.Unicode.GetString(bytes, 0, i);
            }

            return result;
        }
        public static String SubFullString(this string target, int length, string suffix)
        {
            string result = SubFullString(target, length);

            if (result.IsNotNullOrEmpty() && result.Length < target.Length)
            {
                result += suffix;
            }

            return result;
        }
        public static string DESEncrypt(this string target)
        {
            return DESEncrypt(target, "password");
        }
        public static string DESEncrypt(this string target, string key)
        {
            string result = null;

            if (target.IsNotNullOrEmpty())
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputBytes = Encoding.UTF8.GetBytes(target);

                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    using (DESCryptoServiceProvider objDESCSP = new DESCryptoServiceProvider())
                    {
                        using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDESCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                        {
                            objCryptoStream.Write(inputBytes, 0, inputBytes.Length);

                            objCryptoStream.FlushFinalBlock();

                            result = Convert.ToBase64String(objMemoryStream.ToArray());
                        }
                    }
                }
            }

            return result;
        }
        public static string DESDecrypt(this string target)
        {
            return DESDecrypt(target, "password");
        }
        public static string DESDecrypt(this string target, string key)
        {
            string result = null;

            if (target.IsNotNullOrEmpty())
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputBytes = Convert.FromBase64String(target);

                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    using (DESCryptoServiceProvider objDESCSP = new DESCryptoServiceProvider())
                    {
                        using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDESCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                        {
                            objCryptoStream.Write(inputBytes, 0, inputBytes.Length);

                            objCryptoStream.FlushFinalBlock();

                            result = Encoding.UTF8.GetString(objMemoryStream.ToArray());
                        }
                    }
                }
            }

            return result;
        }
        public static string MD5Encrpty(this string target)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(target, FormsAuthPasswordFormat.MD5.ToString());
        }
        public static string SHA1Encrpty(this string target)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(target, FormsAuthPasswordFormat.SHA1.ToString());
        }
        public static string Base64Encode(this string target)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(target));
        }
        public static string Base64Encode(this string target, Encoding objEncoding)
        {
            return Convert.ToBase64String(objEncoding.GetBytes(target));
        }
        public static string Base64Decode(this string target)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(target.Replace(" ", "+")));
        }
        public static string Base64Decode(this string target, Encoding objEncoding)
        {
            return objEncoding.GetString(Convert.FromBase64String(target.Replace(" ", "+")));
        }
        public static string HtmlEncode(this string target)
        {
            return HttpContext.Current.Server.HtmlEncode(target);
        }
        public static string HtmlDecode(this string target)
        {
            return HttpContext.Current.Server.HtmlDecode(target);
        }
        public static string UrlEncode(this string target)
        {
            return HttpContext.Current.Server.UrlEncode(target);
        }
        public static string UrlDecode(this string target)
        {
            return HttpContext.Current.Server.UrlDecode(target);
        }
        public static string UrlRandom(this string target)
        {
            return target += "?";
        }
        public static string FilterJavaScirpt(this string target)
        {
            Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@"<script[^>]*?>.*?</script>", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@"<script.*>[\s\S]*?</script>", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex(@" on[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex6 = new Regex(@"<iframe[^>]*?>.*?</iframe>", RegexOptions.IgnoreCase);
            Regex regex7 = new Regex(@"<frameset[^>]*?>.*?</frameset>", RegexOptions.IgnoreCase);

            target = regex1.Replace(target, "");
            target = regex2.Replace(target, "");
            target = regex3.Replace(target, "");
            target = regex4.Replace(target, "");
            target = regex5.Replace(target, "");
            target = regex6.Replace(target, "");
            target = regex7.Replace(target, "");

            return target;
        }
        public static string FilterHtml(this string target)
        {
            //另一种方法
            //return new Regex("<[^>]+>").Replace(temp, "");
            Regex regex = new Regex(@"<\/*[^<>]*>", RegexOptions.IgnoreCase);

            return regex.Replace(target, "");
        }
        public static string TxtToHtml(this string target)
        {
            target = target.Replace("&", "&amp;");
            target = target.Replace("'", "''");
            target = target.Replace("\"", "&quot;");
            target = target.Replace(" ", "&nbsp;");
            target = target.Replace("<", "&lt;");
            target = target.Replace(">", "&gt;");
            target = target.Replace("\n", "<br/>");

            return target;
        }
        public static string HtmlToText(this string target)
        {
            target = target.Replace("&amp;", "&");
            target = target.Replace("''", "'");
            target = target.Replace("&quot;", "\"");
            target = target.Replace("&nbsp;", " ");
            target = target.Replace("&lt;", "<");
            target = target.Replace("&gt;", ">");
            target = target.Replace("<br/>", "\n");

            return target;
        }
        public static string ListToString(this List<string> target, string separator, string beforeContainer, string afterContainer)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < target.Count; i++)
            {
                if (beforeContainer != null)
                {
                    result.Append(beforeContainer);
                }

                result.Append(target[i]);

                if (afterContainer != null)
                {
                    result.Append(afterContainer);
                }

                if (i != target.Count - 1)
                {
                    result.Append(separator);
                }
            }

            return result.ToString();
        }
        public static List<string> StringToList(this string target, string separator)
        {
            List<string> result = new List<string>();

            {
                string[] temp = target.Split(separator.ToCharArray(0, separator.Length));

                result.AddRange(temp);
            }

            return result;
        }
        public static bool IsChinese(this char target)
        {
            return (int)target > 0x4E00 && (int)target < 0x9FA5;
        }
        public static string FirstLetterToUpper(this string target)
        {
            return target.Substring(0, 1).ToUpper() + target.Remove(0, 1);
        }
        public static string FirstLetterToUpper(this string target, string prefix)
        {
            return prefix + target.Substring(0, 1).ToUpper() + target.Remove(0, 1);
        }
        public static string AddMarks(this string target)
        {
            string result = null;

            string[] temp = target.Replace("\r\n", "|").Split('|');

            /**/

            for (int i = 0; i < temp.Length; i++)
            {
                if (i < temp.Length - 1)
                {
                    result += "\"" + temp[i] + "\"" + " +" + "\r\n";
                }

                else
                {
                    result += "\"" + temp[i] + "\"";
                }
            }

            /**/

            return result;
        }
        public static bool CheckHtmlIsEmpty(this string target)
        {
            bool result = false;

            {
                if (!String.IsNullOrEmpty(target))
                {
                    StringBuilder temp = new StringBuilder(target.ToLower());

                    temp.Replace("&nbsp;", String.Empty);
                    temp.Replace("<br>", String.Empty);
                    temp.Replace("<br/>", String.Empty);
                    temp.Replace("<br />", String.Empty);
                    temp.Replace("<p>", String.Empty);
                    temp.Replace("<p/>", String.Empty);
                    temp.Replace("<p />", String.Empty);

                    result = String.IsNullOrEmpty(temp.ToString().Trim());
                }
            }

            return result;
        }
        public static string Escape(this string target, string[] escapeChars)
        {
            StringBuilder result = new StringBuilder(target);

            foreach (string escapeChar in escapeChars)
            {
                result.Replace(escapeChar, @"\" + escapeChar);
            }

            return result.ToString();
        }
        public static string DeleteLastChar(this string target, string lastChar)
        {
            return target.Substring(0, target.LastIndexOf(lastChar));
        }
    }
}
