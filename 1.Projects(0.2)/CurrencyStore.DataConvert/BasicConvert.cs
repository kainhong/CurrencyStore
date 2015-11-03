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
    public static class BasicConvert
    {
        public static List<BasicDictionary> DictionaryList
        {
            get;
            private set;
        }
        public static List<BasicOrganization> OrganizationList
        {
            get;
            private set;
        }

        public static string GetDictKindText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "1":
                    result = "设备类别";
                    break;

                case "2":
                    result = "设备型号";
                    break;

                case "3":
                    result = "纸币种类";
                    break;

                case "4":
                    result = "纸币类型";
                    break;

                case "5":
                    result = "业务类型";
                    break;

                case "6":
                    result = "设备端口";
                    break;
            }

            return result;
        }
        public static string GetDictValue(this string target, int dictKind)
        {
            return target.GetDictValue(dictKind, "?????");
        }
        public static string GetDictValue(this string target, int dictKind, string defaultValue)
        {
            string result = null;

            if (DictionaryList == null || DictionaryList.Count == 0)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                DictionaryList = service.GetList_Dictionary();
            }

            result = (from item in DictionaryList where item.DictKind == dictKind && item.DictKey.ToString() == target select item.DictValue).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                result = defaultValue;
            }

            return result;
        }
        public static string GetOrgNumber(this string target)
        {
            return target.GetOrgNumber(false, "?????");
        }
        public static string GetOrgNumber(this string target, bool isZeroDisplayNull)
        {
            return target.GetOrgNumber(isZeroDisplayNull, "?????");
        }
        public static string GetOrgNumber(this string target, bool isZeroDisplayNull, string defaultValue)
        {
            string result = null;

            if (OrganizationList == null || OrganizationList.Count == 0)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                OrganizationList = service.GetList_Organization(0, null, null, 0, null);
            }

            result = (from item in OrganizationList where item.PkId == target.ToInt() select item.OrgNumber).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                result = (target.ToInt() == 0 && isZeroDisplayNull) ? "" : defaultValue;
            }

            return result;
        }
        public static string GetOrgName(this string target)
        {
            return target.GetOrgName(false, "?????");
        }
        public static string GetOrgName(this string target, bool isZeroDisplayNull)
        {
            return target.GetOrgName(isZeroDisplayNull, "?????");
        }
        public static string GetOrgName(this string target, bool isZeroDisplayNull, string defaultValue)
        {
            string result = null;

            if (OrganizationList == null)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                OrganizationList = service.GetList_Organization(0, null, null, 0, null);
            }

            result = (from item in OrganizationList where item.PkId == target.ToInt() select item.OrgName).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                result = (target.ToInt() == 0 && isZeroDisplayNull) ? "" : defaultValue;
            }

            return result;
        }
        public static string GetOrgAddress(this string target)
        {
            return target.GetOrgAddress(false, "?????");
        }
        public static string GetOrgAddress(this string target, bool isZeroDisplayNull)
        {
            return target.GetOrgAddress(isZeroDisplayNull, "?????");
        }
        public static string GetOrgAddress(this string target, bool isZeroDisplayNull, string defaultValue)
        {
            string result = null;

            if (OrganizationList == null)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                OrganizationList = service.GetList_Organization(0, null, null, 0, null);
            }

            result = (from item in OrganizationList where item.PkId == target.ToInt() select item.OrgAddress).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                result = (target.ToInt() == 0 && isZeroDisplayNull) ? "" : defaultValue;
            }

            return result;
        }
        public static string GetOrgFullPath(this string target)
        {
            string result = null;

            if (OrganizationList == null)
            {
                var service = ServiceFactory.GetService<IBasicService>();

                OrganizationList = service.GetList_Organization(0, null, null, 0, null);
            }

            result = (from item in OrganizationList where item.PkId == target.ToInt() select item.OrgFullPath).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                if (target == "0")
                {
                    result = "[0]";
                }
            }

            return result;
        }

        public static void ClearCache()
        {
            DictionaryList = null;
            OrganizationList = null;
        }
    }
}
