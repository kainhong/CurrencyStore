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
    public class UserRolePermissionRepository : IUserRolePermissionRepository
    {
        public void Save(List<UserRolePermission> rolePermissionList)
        {
            if (rolePermissionList.Count > 0)
            {
                string sql = null;
                List<DbParameter> parameterList = new List<DbParameter>();

                for (int i = 0; i < rolePermissionList.Count; i++)
                {
                    sql = " insert into tbl_user_rolepermission(PkId, RoleId, PermCode) " +
                          " values(TURP_PKID.NEXTVAL, {0}, '{1}') ".FormatWith(rolePermissionList[i].RoleId.ToString(), rolePermissionList[i].PermCode);

                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
                }
            }
        }
        public void Delete(int roleId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_rolepermission where RoleId=:RoleId ";

            parameterList.Add(new OracleParameter(":RoleId", roleId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public List<UserRolePermission> GetList(int roleId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleId, PermCode from tbl_user_rolepermission where RoleId=:RoleId ";

            parameterList.Add(new OracleParameter(":RoleId", roleId));

            return DbHelper.ExecuteList<UserRolePermission>(sql, CommandType.Text, parameterList.ToArray());
        }
    }
}
