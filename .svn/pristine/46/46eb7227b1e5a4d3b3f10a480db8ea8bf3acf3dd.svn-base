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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CurrencyStore.Repository.Oracle
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public bool CheckExists(UserRole objUserRole)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_user_role where RoleName=:RoleName ";

            parameterList.Add(new OracleParameter(":RoleName", objUserRole.RoleName));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(UserRole objUserRole)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objUserRole.PkId == 0)
            {
                sql = " insert into tbl_user_role(PkId, RoleName, DataFilter, RoleStatus) " +
                      " values(TUR_PKID.NEXTVAL, :RoleName, :DataFilter, :RoleStatus) " +
                      " RETURNING PkId INTO :PkId ";

                parameterList.Add(new OracleParameter(":RoleName", objUserRole.RoleName));
                parameterList.Add(new OracleParameter(":DataFilter", objUserRole.DataFilter));
                parameterList.Add(new OracleParameter(":RoleStatus", objUserRole.RoleStatus));
                var p = new OracleParameter(":PkId", OracleDbType.Int32, 0, ParameterDirection.Output);
                parameterList.Add(p);

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());

                objUserRole.PkId = Convert.ToInt32(((OracleDecimal)p.Value).Value);
            }

            else
            {
                sql = " update tbl_user_role set RoleName=:RoleName, DataFilter=:DataFilter, RoleStatus=:RoleStatus where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":RoleName", objUserRole.RoleName));
                parameterList.Add(new OracleParameter(":DataFilter", objUserRole.DataFilter));
                parameterList.Add(new OracleParameter(":RoleStatus", objUserRole.RoleStatus));
                parameterList.Add(new OracleParameter(":PkId", objUserRole.PkId));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }           
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_role where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public UserRole GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleName, DataFilter, RoleStatus from tbl_user_role Where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<UserRole>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<UserRole> GetList(string roleName, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, RoleName, DataFilter, RoleStatus from tbl_user_role Where 1=1 ";

            if (roleName.IsNotNullOrEmpty())
            {
                sql += " and instr(RoleName, :RoleName) > 0 ";
                
                parameterList.Add(new OracleParameter(":RoleName", roleName));
            }

            sql += " order by PkId desc ";

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
