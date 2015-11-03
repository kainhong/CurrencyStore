using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Common.Cache;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.DataConvert
{
    public static class DeviceConvert
    {
        public static string GetDeviceStatusText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "0":
                    result = "禁用";
                    break;

                case "1":
                    result = "启用";
                    break;
            }

            return result;
        }
        public static string GetConnectionStatusText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "0":
                    result = "未连接";
                    break;

                case "1":
                    result = "已连接";
                    break;
            }

            return result;
        }
    }
}
