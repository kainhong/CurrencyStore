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
    public class DeviceStatInfoRepository : IDeviceStatInfoRepository
    {
        public List<DeviceStatInfo> GetList(int orgId, string orgFullPath, int deviceKind, int deviceModel, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, KindCode, ModelCode, count(DeviceNumber) as Count from tbl_device_info Where 1=1 ";

            if (orgId > 0)
            {
                //sql += " and OrgId=:OrgId ";

                //parameterList.Add(new OracleParameter(":OrgId", orgId)); 

                if (orgFullPath.IsNotNullOrEmpty())
                {
                    sql += " and OrgId in (select PkId from tbl_basic_organization where OrgFullPath like concat(:OrgFullPath, \'%\')) ";

                    parameterList.Add(new OracleParameter(":OrgFullPath", orgFullPath));
                }
            }

            if (deviceKind > 0)
            {
                sql += " and KindCode=:KindCode ";

                parameterList.Add(new OracleParameter(":KindCode", deviceKind));
            }

            if (deviceModel > 0)
            {
                sql += " and ModelCode=:ModelCode ";

                parameterList.Add(new OracleParameter(":ModelCode", deviceModel));
            }

            sql += " group by OrgId, KindCode, ModelCode ";

            sql += " order by OrgId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<DeviceStatInfo>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<DeviceStatInfo>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
