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
    public static class UserConvert
    {
        private static List<UserRole> RoleList
        {
            get;
            set;
        }
        private static List<UserInfo> InfoList
        {
            get;
            set;
        }

        public static string GetRoleName(this string target)
        {
            string result = null;

            if (RoleList == null || RoleList.Count == 0)
            {
                var service = ServiceFactory.GetService<IUserService>();

                RoleList = service.GetList_Role(null, null);
            }

            result = (from item in RoleList where item.PkId == target.ToInt() select item.RoleName).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                result = "?????";
            }

            return result;
        }
        public static string GetDataFilterText(this string target)
        {
            string result = null;

            switch (target)
            {
                case "0":
                    result = "不过滤";
                    break;

                case "1":
                    result = "过滤";
                    break;
            }

            return result;
        }
        public static string GetRoleStatusText(this string target)
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
        public static int GetUserId(this string target)
        {
            int result = -1;

            if (target.IsNullOrEmpty())
            {
                return result;
            }

            if (InfoList == null || InfoList.Count == 0)
            {
                var service = ServiceFactory.GetService<IUserService>();

                InfoList = service.GetList_Info(null, null, 0, null);
            }

            result = (from item in InfoList where item.UserAccount == target select item.PkId).SingleOrDefault();

            return result;
        }
        public static string GetUserAccount(this string target)
        {
            string result = null;

            if (InfoList == null || InfoList.Count == 0)
            {
                var service = ServiceFactory.GetService<IUserService>();

                InfoList = service.GetList_Info(null, null, 0, null);
            }

            result = (from item in InfoList where item.PkId == target.ToInt() select item.UserAccount).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                if (target == "0")
                {
                    result = "系统初始化";
                }

                else
                {
                    result = "?????";
                }
            }

            return result;
        }
        public static string GetUserNickName(this string target)
        {
            string result = null;

            if (InfoList == null || InfoList.Count == 0)
            {
                var service = ServiceFactory.GetService<IUserService>();

                InfoList = service.GetList_Info(null, null, 0, null);
            }

            result = (from item in InfoList where item.PkId == target.ToInt() select item.UserNickName).SingleOrDefault();

            if (result.IsNullOrEmpty())
            {
                if (target == "0")
                {
                    result = "系统初始化";
                }

                else
                {
                    result = "?????";
                }
            }

            return result;
        }
        public static string GetUserStatusText(this string target)
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

        public static void ClearCache()
        {
            RoleList = null;
            InfoList = null;
        }
    }
}
