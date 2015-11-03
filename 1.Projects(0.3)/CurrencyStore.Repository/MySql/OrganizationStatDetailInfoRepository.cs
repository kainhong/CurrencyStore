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
    public class OrganizationStatDetailInfoRepository : IOrganizationStatDetailInfoRepository
    {
        public List<OrganizationStatDetailInfo> GetList(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, FaceAmount, count(FaceAmount) as Count, sum(FaceAmount) as Sum from tbl_currency_info Where 1=1 ";

            if (orgId > 0)
            {
                sql += " and OrgId=@OrgId ";

                parameterList.Add(new MySqlParameter("@OrgId", orgId));
            }

            if (startTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime>=@StartTime ";

                parameterList.Add(new MySqlParameter("@StartTime", startTime));
            }

            if (endTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime<=@EndTime ";

                parameterList.Add(new MySqlParameter("@EndTime", endTime));
            }

            if (currencyKind > 0)
            {
                sql += " and CurrencyKindCode=@CurrencyKindCode ";

                parameterList.Add(new MySqlParameter("@CurrencyKindCode", currencyKind));
            }

            if (deviceKind > 0)
            {
                sql += " and DeviceKindCode=@DeviceKindCode ";

                parameterList.Add(new MySqlParameter("@DeviceKindCode", deviceKind));
            }

            if (deviceModel > 0)
            {
                sql += " and DeviceModelCode=@DeviceModelCode ";

                parameterList.Add(new MySqlParameter("@DeviceModelCode", deviceModel));
            }

            sql += " group by OrgId, FaceAmount order by FaceAmount ";

            return DbHelper.ExecuteList<OrganizationStatDetailInfo>(sql, CommandType.Text, parameterList.ToArray());
        }
    }
}
