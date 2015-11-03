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
    public class UserLoginRepository : IUserLoginRepository
    {
        public void Save(UserLogin objUserLogin)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " insert into tbl_user_login(PkId, UserId, LoginTime, LoginIp) values(TUL_PKID.NEXTVAL, :UserId, :LoginTime, :LoginIp) ";

            parameterList.Add(new OracleParameter(":UserId", objUserLogin.UserId));
            parameterList.Add(new OracleParameter(":LoginTime", objUserLogin.LoginTime));
            parameterList.Add(new OracleParameter(":LoginIp", objUserLogin.LoginIp));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_user_login where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", pkId));
            }

            else
            {
                sql = " truncate table tbl_user_login ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Clear(DateTime beforeTime)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_login where LoginTime<:BeforeTime ";

            parameterList.Add(new OracleParameter(":BeforeTime", beforeTime));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public List<UserLogin> GetList(int userId, Pagination paging)
        {
            string sql = " select PkId, UserId, LoginTime, LoginIp from tbl_user_login where 1=1 ";
            List<DbParameter> parameterList = new List<DbParameter>();

            if (userId >= 0)
            {
                sql += " and UserId=:UserId ";

                parameterList.Add(new OracleParameter(":UserId", userId));
            }

            sql += " order by PkId desc ";

            return DbHelper.ExecutePagingList<UserLogin>(sql, paging, parameterList.ToArray());
        }
    }
}
