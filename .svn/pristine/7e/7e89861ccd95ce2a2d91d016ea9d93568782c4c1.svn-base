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
    public class BasicParameterRepository : IBasicParameterRepository
    {
        public bool CheckExists(BasicParameter objBasicParameter)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_basic_parameter where ParamKey=:ParamKey ";

            parameterList.Add(new OracleParameter(":ParamKey", objBasicParameter.ParamKey));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(BasicParameter objBasicParameter)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objBasicParameter.PkId == 0)
            {
                sql = " insert into tbl_basic_parameter(PkId, ParamKey, ParamName, ParamValue) " +
                      " values(TBP_PKID.NEXTVAL, :ParamKey, :ParamName, :ParamValue) ";

                parameterList.Add(new OracleParameter(":ParamKey", objBasicParameter.ParamKey));
                parameterList.Add(new OracleParameter(":ParamName", objBasicParameter.ParamName));
                parameterList.Add(new OracleParameter(":ParamValue", objBasicParameter.ParamValue));
            }

            else
            {
                sql = " update tbl_basic_parameter set ParamValue=:ParamValue where ParamKey=:ParamKey ";

                parameterList.Add(new OracleParameter(":ParamValue", objBasicParameter.ParamValue));
                parameterList.Add(new OracleParameter(":ParamKey", objBasicParameter.ParamKey));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public BasicParameter GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, ParamKey, ParamName, ParamValue from tbl_basic_parameter Where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<BasicParameter>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<BasicParameter> GetList()
        {
            string sql = "select PkId, ParamKey, ParamName, ParamValue from tbl_basic_parameter ";

            return DbHelper.ExecuteList<BasicParameter>(sql);
        }
    }
}
