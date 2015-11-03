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
    public class UserRoleRepository : IUserRoleRepository
    {
        public bool CheckExists(UserRole objUserRole)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_user_role where RoleName=@RoleName ";

            parameterList.Add(new MySqlParameter("@RoleName", objUserRole.RoleName));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(UserRole objUserRole)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objUserRole.PkId == 0)
            {
                sql = " insert into tbl_user_role(RoleName, DataFilter, RoleStatus) " +
                      " values(@RoleName, @DataFilter, @RoleStatus); " +
                      " select LAST_INSERT_ID(); ";

                parameterList.Add(new MySqlParameter("@RoleName", objUserRole.RoleName));
                parameterList.Add(new MySqlParameter("@DataFilter", objUserRole.DataFilter));
                parameterList.Add(new MySqlParameter("@RoleStatus", objUserRole.RoleStatus));

                objUserRole.PkId = DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString().ToInt();
            }

            else
            {
                sql = " update tbl_user_role set RoleName=@RoleName, DataFilter=@DataFilter, RoleStatus=@RoleStatus where PkId=@PkId ";
                                
                parameterList.Add(new MySqlParameter("@RoleName", objUserRole.RoleName));
                parameterList.Add(new MySqlParameter("@DataFilter", objUserRole.DataFilter));
                parameterList.Add(new MySqlParameter("@RoleStatus", objUserRole.RoleStatus));
                parameterList.Add(new MySqlParameter("@PkId", objUserRole.PkId));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_role where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public UserRole GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleName, DataFilter, RoleStatus from tbl_user_role Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<UserRole>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<UserRole> GetList(string roleName, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleName, DataFilter, RoleStatus from tbl_user_role Where 1=1 ";

            if (roleName.IsNotNullOrEmpty())
            {
                sql += " and RoleName like concat(\'%\', {0}, \'%\') ".FormatWith("@RoleName");

                parameterList.Add(new MySqlParameter("@RoleName", roleName));
            }

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<UserRole>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<UserRole>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
