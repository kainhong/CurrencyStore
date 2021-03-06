﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using MySql.Data.MySqlClient;

namespace CurrencyStore.Repository.MySql
{
    public class UserPermissionRepository : IUserPermissionRepository
    {
        public List<UserPermission> GetList()
        {
            string sql = " select PkId, PermCode, PermName, PermLevel, PermContent, PermParentId from tbl_user_permission ";

            return DbHelper.ExecuteList<UserPermission>(sql);
        }
    }
}
