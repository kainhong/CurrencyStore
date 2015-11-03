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
    public class BasicParameterRepository : IBasicParameterRepository
    {
        public bool CheckExists(BasicParameter objBasicParameter)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_basic_parameter where ParamKey=@ParamKey ";

            parameterList.Add(new MySqlParameter("@ParamKey", objBasicParameter.ParamKey));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(BasicParameter objBasicParameter)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objBasicParameter.PkId == 0)
            {
                sql = " insert into tbl_basic_parameter(ParamKey, ParamName, ParamValue) " +
                      " values(@ParamKey, @ParamName, @ParamValue) ";

                parameterList.Add(new MySqlParameter("@ParamKey", objBasicParameter.ParamKey));
                parameterList.Add(new MySqlParameter("@ParamName", objBasicParameter.ParamName));
                parameterList.Add(new MySqlParameter("@ParamValue", objBasicParameter.ParamValue));
            }

            else
            {
                sql = " update tbl_basic_parameter set ParamValue=@ParamValue where ParamKey=@ParamKey ";

                parameterList.Add(new MySqlParameter("@ParamKey", objBasicParameter.ParamKey));
                parameterList.Add(new MySqlParameter("@ParamValue", objBasicParameter.ParamValue));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public BasicParameter GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, ParamKey, ParamName, ParamValue from tbl_basic_parameter Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<BasicParameter>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<BasicParameter> GetList()
        {
            string sql = "select PkId, ParamKey, ParamName, ParamValue from tbl_basic_parameter ";

            return DbHelper.ExecuteList<BasicParameter>(sql);
        }
    }
}
