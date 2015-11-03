using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Cache;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.DataConvert
{
    public static class CurrencyConvert
    {
        public static string GetSuspiciousText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "0":
                    result = "真币";
                    break;

                default:
                    result = "可疑币";
                    break;
            }

            return result;
        }
        public static string GetExportStatusText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "0":
                    result = "未开始";
                    break;

                case "1":
                    result = "进行中";
                    break;

                case "2":
                    result = "已完成";
                    break;
            }

            return result;
        }
    }
}
