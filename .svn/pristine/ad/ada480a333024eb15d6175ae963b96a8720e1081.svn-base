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
    public class BasicDictionaryRepository : IBasicDictionaryRepository
    {
        public bool CheckExists(BasicDictionary objBasicDictionary)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_basic_dictionary where DictKind=@DictKind and DictKey=@DictKey ";

            parameterList.Add(new MySqlParameter("@DictKind", objBasicDictionary.DictKind));
            parameterList.Add(new MySqlParameter("@DictKey", objBasicDictionary.DictKey));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(BasicDictionary objBasicDictionary)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objBasicDictionary.PkId == 0)
            {
                sql = " insert into tbl_basic_dictionary(DictKind, DictKey, DictValue, IsSystem) " +
                      " values(@DictKind, @DictKey, @DictValue, @IsSystem) ";

                parameterList.Add(new MySqlParameter("@DictKind", objBasicDictionary.DictKind));
                parameterList.Add(new MySqlParameter("@DictKey", objBasicDictionary.DictKey));
                parameterList.Add(new MySqlParameter("@DictValue", objBasicDictionary.DictValue));
                parameterList.Add(new MySqlParameter("@IsSystem", objBasicDictionary.IsSystem));
            }

            else
            {
                sql = " update tbl_basic_dictionary set DictValue=@DictValue where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", objBasicDictionary.PkId));
                parameterList.Add(new MySqlParameter("@DictValue", objBasicDictionary.DictValue));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_basic_dictionary where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));
            }

            else
            {
                sql = " delete from tbl_basic_dictionary ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public BasicDictionary GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DictKind, DictKey, DictValue, IsSystem from tbl_basic_dictionary Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<BasicDictionary>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<BasicDictionary> GetList()
        {
            string sql = " select PkId, DictKind, DictKey, DictValue, IsSystem from tbl_basic_dictionary order by DictKind asc, DictKey asc ";

            return DbHelper.ExecuteList<BasicDictionary>(sql);
        }
    }
}
