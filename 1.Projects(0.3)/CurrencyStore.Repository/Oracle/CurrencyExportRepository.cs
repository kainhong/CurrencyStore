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
    public class CurrencyExportRepository : ICurrencyExportRepository
    {
        public void Save(CurrencyExport objCurrencyExport)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objCurrencyExport.PkId == 0)
            {
                sql = " insert into tbl_currency_export(PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime) " +
                      " values(TCE_PKID.NEXTVAL, :OrgId, :DeviceNumber, :OperateStartTime, :OperateEndTime, :CurrencyNumber, :ExportStatus, :DataCount, :FileName, :FileSize, :CreateUserId, :CreateTime) ";

                parameterList.Add(new OracleParameter(":OrgId", objCurrencyExport.OrgId));
                parameterList.Add(new OracleParameter(":DeviceNumber", objCurrencyExport.DeviceNumber));
                parameterList.Add(new OracleParameter(":OperateStartTime", objCurrencyExport.OperateStartTime));
                parameterList.Add(new OracleParameter(":OperateEndTime", objCurrencyExport.OperateEndTime));
                parameterList.Add(new OracleParameter(":CurrencyNumber", objCurrencyExport.CurrencyNumber));
                parameterList.Add(new OracleParameter(":ExportStatus", objCurrencyExport.ExportStatus));
                parameterList.Add(new OracleParameter(":DataCount", objCurrencyExport.DataCount));
                parameterList.Add(new OracleParameter(":FileName", objCurrencyExport.FileName));
                parameterList.Add(new OracleParameter(":FileSize", objCurrencyExport.FileSize));
                parameterList.Add(new OracleParameter(":CreateUserId", objCurrencyExport.CreateUserId));
                parameterList.Add(new OracleParameter(":CreateTime", objCurrencyExport.CreateTime));
            }

            else
            {
                sql = " update tbl_currency_export set ExportStatus=:ExportStatus, DataCount=:DataCount, FileName=:FileName, FileSize=:FileSize where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":ExportStatus", objCurrencyExport.ExportStatus));
                parameterList.Add(new OracleParameter(":DataCount", objCurrencyExport.DataCount));
                parameterList.Add(new OracleParameter(":FileName", objCurrencyExport.FileName));
                parameterList.Add(new OracleParameter(":FileSize", objCurrencyExport.FileSize));
                parameterList.Add(new OracleParameter(":PkId", objCurrencyExport.PkId));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_currency_export where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", pkId));
            }

            else
            {
                sql = " delete from tbl_currency_export ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public CurrencyExport GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<CurrencyExport>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public CurrencyExport GetObjectForExecute()
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where ExportStatus=0 and rownum=1 order by PkId asc ";

            return DbHelper.ExecuteList<CurrencyExport>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<CurrencyExport> GetList(int userId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where 1=1 ";

            if (userId >= 0)
            {
                sql += " and CreateUserId=:UserId ";

                parameterList.Add(new OracleParameter(":UserId", userId));
            }

            sql += " order by PkId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<CurrencyExport>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<CurrencyExport>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
