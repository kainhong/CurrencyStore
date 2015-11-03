using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.Query;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CurrencyStore.Repository.Oracle
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
