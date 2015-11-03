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
    public class CurrencyExportRepository : ICurrencyExportRepository
    {
        public void Save(CurrencyExport objCurrencyExport)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objCurrencyExport.PkId == 0)
            {
                sql = " insert into tbl_currency_export(OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime) " +
                      " values(@OrgId, @DeviceNumber, @OperateStartTime, @OperateEndTime, @CurrencyNumber, @ExportStatus, @DataCount, @FileName, @FileSize, @CreateUserId, @CreateTime) ";

                parameterList.Add(new MySqlParameter("@OrgId", objCurrencyExport.OrgId));
                parameterList.Add(new MySqlParameter("@DeviceNumber", objCurrencyExport.DeviceNumber));
                parameterList.Add(new MySqlParameter("@OperateStartTime", objCurrencyExport.OperateStartTime));
                parameterList.Add(new MySqlParameter("@OperateEndTime", objCurrencyExport.OperateEndTime));
                parameterList.Add(new MySqlParameter("@CurrencyNumber", objCurrencyExport.CurrencyNumber));
                parameterList.Add(new MySqlParameter("@ExportStatus", objCurrencyExport.ExportStatus));
                parameterList.Add(new MySqlParameter("@DataCount", objCurrencyExport.DataCount));
                parameterList.Add(new MySqlParameter("@FileName", objCurrencyExport.FileName));
                parameterList.Add(new MySqlParameter("@FileSize", objCurrencyExport.FileSize));
                parameterList.Add(new MySqlParameter("@CreateUserId", objCurrencyExport.CreateUserId));
                parameterList.Add(new MySqlParameter("@CreateTime", objCurrencyExport.CreateTime));
            }

            else
            {
                sql = " update tbl_currency_export set ExportStatus=@ExportStatus, DataCount=@DataCount, FileName=@FileName, FileSize=@FileSize where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@ExportStatus", objCurrencyExport.ExportStatus));
                parameterList.Add(new MySqlParameter("@DataCount", objCurrencyExport.DataCount));
                parameterList.Add(new MySqlParameter("@FileName", objCurrencyExport.FileName));
                parameterList.Add(new MySqlParameter("@FileSize", objCurrencyExport.FileSize));
                parameterList.Add(new MySqlParameter("@PkId", objCurrencyExport.PkId));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_currency_export where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));
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

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<CurrencyExport>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public CurrencyExport GetObjectForExecute()
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where ExportStatus=0 order by PkId asc limit 0, 1 ";

            return DbHelper.ExecuteList<CurrencyExport>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<CurrencyExport> GetList(int userId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgId, DeviceNumber, OperateStartTime, OperateEndTime, CurrencyNumber, ExportStatus, DataCount, FileName, FileSize, CreateUserId, CreateTime from tbl_currency_export where 1=1 ";

            if (userId >= 0)
            {
                sql += " and CreateUserId=@UserId ";

                parameterList.Add(new MySqlParameter("@UserId", userId));
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
