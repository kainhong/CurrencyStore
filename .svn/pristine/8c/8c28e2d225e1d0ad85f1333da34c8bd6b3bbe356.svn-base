using System;
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
    public class UserRolePermissionRepository : IUserRolePermissionRepository
    {
        public void Save(List<UserRolePermission> rolePermissionList)
        {
            if (rolePermissionList.Count > 0)
            {
                string sql = null;
                List<DbParameter> parameterList = new List<DbParameter>();

                sql = " insert into tbl_user_rolepermission(RoleId, PermCode) " +
                      " values ";

                for (int i = 0; i < rolePermissionList.Count; i++)
                {
                    sql += "({0}, '{1}')".FormatWith(rolePermissionList[i].RoleId.ToString(), rolePermissionList[i].PermCode);

                    if (i != rolePermissionList.Count - 1)
                    {
                        sql += ",";
                    }
                }

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int roleId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_rolepermission where RoleId=@RoleId ";

            parameterList.Add(new MySqlParameter("@RoleId", roleId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public List<UserRolePermission> GetList(int roleId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleId, PermCode from tbl_user_rolepermission where RoleId=@RoleId ";

            parameterList.Add(new MySqlParameter("@RoleId", roleId));

            return DbHelper.ExecuteList<UserRolePermission>(sql, CommandType.Text, parameterList.ToArray());
        }
    }
}
