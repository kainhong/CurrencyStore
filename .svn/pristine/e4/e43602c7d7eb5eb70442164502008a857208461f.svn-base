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
    public class CurrencyBlacklistRepository : ICurrencyBlacklistRepository
    {
        public bool CheckExists(CurrencyBlacklist objCurrencyBlacklist)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_currency_blacklist where CurrencyNumber=@CurrencyNumber ";

            parameterList.Add(new MySqlParameter("@CurrencyNumber", objCurrencyBlacklist.CurrencyNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(CurrencyBlacklist objCurrencyBlacklist)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objCurrencyBlacklist.PkId == 0)
            {
                sql = " insert into tbl_currency_blacklist(CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyNumber) " +
                      " values(@CurrencyKindCode, @FaceAmount, @CurrencyVersion, @CurrencyNumber) ";

                parameterList.Add(new MySqlParameter("@CurrencyKindCode", objCurrencyBlacklist.CurrencyKindCode));
                parameterList.Add(new MySqlParameter("@FaceAmount", objCurrencyBlacklist.FaceAmount));
                parameterList.Add(new MySqlParameter("@CurrencyVersion", objCurrencyBlacklist.CurrencyVersion));
                parameterList.Add(new MySqlParameter("@CurrencyNumber", objCurrencyBlacklist.CurrencyNumber));
            }
            else
            {
                sql = " update tbl_currency_blacklist set CurrencyKindCode=@CurrencyKindCode, FaceAmount=@FaceAmount, " +
                      " CurrencyVersion=@CurrencyVersion, CurrencyNumber=@CurrencyNumber where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@CurrencyKindCode", objCurrencyBlacklist.CurrencyKindCode));
                parameterList.Add(new MySqlParameter("@FaceAmount", objCurrencyBlacklist.FaceAmount));
                parameterList.Add(new MySqlParameter("@CurrencyVersion", objCurrencyBlacklist.CurrencyVersion));
                parameterList.Add(new MySqlParameter("@CurrencyNumber", objCurrencyBlacklist.CurrencyNumber));
                parameterList.Add(new MySqlParameter("@PkId", objCurrencyBlacklist.PkId));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_currency_blacklist where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));
            }

            else
            {
                sql = " truncate table tbl_currency_blacklist ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public CurrencyBlacklist GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyNumber from tbl_currency_blacklist where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<CurrencyBlacklist>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<CurrencyBlacklist> GetList(string currencyNumber, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyNumber from tbl_currency_blacklist where 1=1 ";

            if (currencyNumber.IsNotNullOrEmpty())
            {
                sql += " and CurrencyNumber like concat(\'%\', {0}, \'%\') ".FormatWith("@CurrencyNumber");

                parameterList.Add(new MySqlParameter("@CurrencyNumber", currencyNumber));
            }

            sql += " order by PkId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<CurrencyBlacklist>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<CurrencyBlacklist>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
