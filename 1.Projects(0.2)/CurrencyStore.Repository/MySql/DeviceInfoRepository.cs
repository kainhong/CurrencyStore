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
    public class DeviceInfoRepository : IDeviceInfoRepository
    {
        public bool CheckExists(DeviceInfo objDeviceInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_device_info where DeviceNumber=@DeviceNumber ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceInfo.DeviceNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(DeviceInfo objDeviceInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objDeviceInfo.PkId == 0)
            {
                sql = " insert into tbl_device_info(DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus) " +
                      " values(@DeviceNumber, @SoftwareVersion, @RegisterIp, @KindCode, @ModelCode, @OrgId, @OnLineTime, @DeviceStatus); " +
                      " select LAST_INSERT_ID(); ";

                parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceInfo.DeviceNumber));
                parameterList.Add(new MySqlParameter("@SoftwareVersion", objDeviceInfo.SoftwareVersion));
                parameterList.Add(new MySqlParameter("@RegisterIp", objDeviceInfo.RegisterIp));
                parameterList.Add(new MySqlParameter("@KindCode", objDeviceInfo.KindCode));
                parameterList.Add(new MySqlParameter("@ModelCode", objDeviceInfo.ModelCode));
                parameterList.Add(new MySqlParameter("@OrgId", objDeviceInfo.OrgId));
                parameterList.Add(new MySqlParameter("@OnLineTime", objDeviceInfo.OnLineTime));
                parameterList.Add(new MySqlParameter("@DeviceStatus", objDeviceInfo.DeviceStatus));

                objDeviceInfo.PkId = DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString().ToInt();
            }

            else
            {
                sql = " update tbl_device_info set DeviceNumber=@DeviceNumber, SoftwareVersion=@SoftwareVersion, " +
                      " RegisterIp=@RegisterIp, KindCode=@KindCode, ModelCode=@ModelCode, OrgId=@OrgId, " +
                      " OnLineTime=@OnLineTime, DeviceStatus=@DeviceStatus where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", objDeviceInfo.PkId));
                parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceInfo.DeviceNumber));
                parameterList.Add(new MySqlParameter("@SoftwareVersion", objDeviceInfo.SoftwareVersion));
                parameterList.Add(new MySqlParameter("@RegisterIp", objDeviceInfo.RegisterIp));
                parameterList.Add(new MySqlParameter("@KindCode", objDeviceInfo.KindCode));
                parameterList.Add(new MySqlParameter("@ModelCode", objDeviceInfo.ModelCode));
                parameterList.Add(new MySqlParameter("@OrgId", objDeviceInfo.OrgId));
                parameterList.Add(new MySqlParameter("@OnLineTime", objDeviceInfo.OnLineTime));
                parameterList.Add(new MySqlParameter("@DeviceStatus", objDeviceInfo.DeviceStatus));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_device_info where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));
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

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public DeviceInfo GetObjectByDeviceNumber(string deviceNumber)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where DeviceNumber=@DeviceNumber ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));

            return DbHelper.ExecuteList<DeviceInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<DeviceInfo> GetList(int orgId, bool isUnknownOrg, string deviceNumber, string registerIp, int deviceKind, int deviceModel, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, SoftwareVersion, RegisterIp, KindCode, ModelCode, OrgId, OnLineTime, DeviceStatus from tbl_device_info Where 1=1 ";

            if (isUnknownOrg || (!isUnknownOrg && orgId > 0))
            {
                sql += " and OrgId=@OrgId ";

                parameterList.Add(new MySqlParameter("@OrgId", orgId));
            }

            if (!isUnknownOrg && orgId == 0)
            {
                sql += " and OrgId>0 ";
            }

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and DeviceNumber like concat(\'%\', {0}, \'%\') ".FormatWith("@DeviceNumber");

                parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));
            }

            if (registerIp.IsNotNullOrEmpty())
            {
                sql += " and RegisterIp like concat(\'%\', {0}, \'%\') ".FormatWith("@RegisterIp");

                parameterList.Add(new MySqlParameter("@RegisterIp", registerIp));
            }

            if (deviceKind > 0)
            {
                sql += " and KindCode=@KindCode ";

                parameterList.Add(new MySqlParameter("@KindCode", deviceKind));
            }

            if (deviceModel > 0)
            {
                sql += " and ModelCode=@ModelCode ";

                parameterList.Add(new MySqlParameter("@ModelCode", deviceModel));
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
