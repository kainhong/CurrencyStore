using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.Query;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CurrencyStore.Repository.Oracle
{
    public class OrganizationStatInfoRepository : IOrganizationStatInfoRepository
    {
        public List<OrganizationStatInfo> GetList(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, count(FaceAmount) as Count, sum(FaceAmount) as Sum from tbl_currency_info Where 1=1 ";

            if (orgId > 0)
            {
                sql += " and OrgId=:OrgId ";

                parameterList.Add(new OracleParameter(":OrgId", orgId));
            }

            if (startTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime>=to_date(:StartTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":StartTime", startTime));
            }

            if (endTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime<=to_date(:EndTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":EndTime", endTime));
            }

            if (currencyKind > 0)
            {
                sql += " and CurrencyKindCode=:CurrencyKindCode ";

                parameterList.Add(new OracleParameter(":CurrencyKindCode", currencyKind));
            }

            if (deviceKind > 0)
            {
                sql += " and DeviceKindCode=:DeviceKindCode ";

                parameterList.Add(new OracleParameter(":DeviceKindCode", deviceKind));
            }

            if (deviceModel > 0)
            {
                sql += " and DeviceModelCode=:DeviceModelCode ";

                parameterList.Add(new OracleParameter(":DeviceModelCode", deviceModel));
            }

            sql += " group by OrgId ";

            sql += " order by OrgId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<OrganizationStatInfo>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<OrganizationStatInfo>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
