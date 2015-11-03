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
    public class DeviceInfoRepository : IDeviceInfoRepository
    {
        public bool CheckExists(DeviceInfo objDeviceInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_device_info where DeviceNumber=:DeviceNumber ";

            parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceInfo.DeviceNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(DeviceInfo objDeviceInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objDeviceInfo.PkId == 0)
            {
                sql = "insert into tbl_device_info(PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus) " +
                      " values(TDI_PKID.NEXTVAL, :DeviceNumber, :SoftwareVersion, :RegisterIp, :KindCode, :ModelCode, :OrgId, :OnLineTime, :DeviceStatus) " +
                      " RETURNING PkId INTO :PkId";

                parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceInfo.DeviceNumber));
                parameterList.Add(new OracleParameter(":SoftwareVersion", objDeviceInfo.SoftwareVersion));
                parameterList.Add(new OracleParameter(":RegisterIp", objDeviceInfo.RegisterIp));
                parameterList.Add(new OracleParameter(":KindCode", objDeviceInfo.KindCode));
                parameterList.Add(new OracleParameter(":ModelCode", objDeviceInfo.ModelCode));
                parameterList.Add(new OracleParameter(":OrgId", objDeviceInfo.OrgId));
                parameterList.Add(new OracleParameter(":OnLineTime", objDeviceInfo.OnLineTime));
                parameterList.Add(new OracleParameter(":DeviceStatus", objDeviceInfo.DeviceStatus));
                var p = new OracleParameter(":PkId", OracleDbType.Int32, 0, ParameterDirection.Output);
                parameterList.Add(p);

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());

                objDeviceInfo.PkId = Convert.ToInt32(((OracleDecimal)p.Value).Value);
            }
            else
            {
                sql = " update tbl_device_info set DeviceNumber=:DeviceNumber, SoftwareVersion=:SoftwareVersion, " +
                      " RegisterIp=:RegisterIp, KindCode=:KindCode, ModelCode=:ModelCode, OrgId=:OrgId, " +
                      " OnLineTime=:OnLineTime, DeviceStatus=:DeviceStatus where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceInfo.DeviceNumber));
                parameterList.Add(new OracleParameter(":SoftwareVersion", objDeviceInfo.SoftwareVersion));
                parameterList.Add(new OracleParameter(":RegisterIp", objDeviceInfo.RegisterIp));
                parameterList.Add(new OracleParameter(":KindCode", objDeviceInfo.KindCode));
                parameterList.Add(new OracleParameter(":ModelCode", objDeviceInfo.ModelCode));
                parameterList.Add(new OracleParameter(":OrgId", objDeviceInfo.OrgId));
                parameterList.Add(new OracleParameter(":OnLineTime", objDeviceInfo.OnLineTime));
                parameterList.Add(new OracleParameter(":DeviceStatus", objDeviceInfo.DeviceStatus));
                parameterList.Add(new OracleParameter(":PkId", objDeviceInfo.PkId));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_device_info where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", pkId));
            }

            else
            {
                sql = " truncate table tbl_device_info ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public DeviceInfo GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public DeviceInfo GetObjectByDeviceNumber(string deviceNumber)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where DeviceNumber=:DeviceNumber ";

            parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));

            return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<DeviceInfo> GetList(int orgId, bool isUnknownOrg, string deviceNumber, string registerIp, int deviceKind, int deviceModel, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where 1=1 ";

            if (isUnknownOrg || (!isUnknownOrg && orgId > 0))
            {
                sql += " and OrgId=:OrgId ";

                parameterList.Add(new OracleParameter(":OrgId", orgId));
            }

            if (!isUnknownOrg && orgId == 0)
            {
                sql += " and OrgId>0 ";
            }

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and DeviceNumber like concat(\'%\', {0}, \'%\') ".FormatWith(":DeviceNumber");

                parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));
            }

            if (registerIp.IsNotNullOrEmpty())
            {
                sql += " and RegisterIp like concat(\'%\', {0}, \'%\') ".FormatWith(":RegisterIp");

                parameterList.Add(new OracleParameter(":RegisterIp", registerIp));
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

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<DeviceInfo>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public List<DeviceInfo> GetAllList()
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where 1=1 ";

            return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray());
        }
    }
}
