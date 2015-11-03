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
    public class DeviceConnectionRepository : IDeviceConnectionRepository
    {
        public bool CheckExists(DeviceConnection objDeviceConnection)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_device_connection where DeviceNumber=@DeviceNumber ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceConnection.DeviceNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(DeviceConnection objDeviceConnection)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objDeviceConnection.PkId == 0)
            {
                sql = " insert into tbl_device_connection(DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount) " +
                      " values(@DeviceNumber, @DeviceIp, @OrgId, @CollectorName, @CollectorIp, @ConnectTime, @DisconnectTime, @ConnectionStatus, @UploadCount) ";

                parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceConnection.DeviceNumber));
                parameterList.Add(new MySqlParameter("@DeviceIp", objDeviceConnection.DeviceIp));
                parameterList.Add(new MySqlParameter("@OrgId", objDeviceConnection.OrgId));
                parameterList.Add(new MySqlParameter("@CollectorName", objDeviceConnection.CollectorName));
                parameterList.Add(new MySqlParameter("@CollectorIp", objDeviceConnection.CollectorIp));
                parameterList.Add(new MySqlParameter("@ConnectTime", objDeviceConnection.ConnectTime));
                parameterList.Add(new MySqlParameter("@DisconnectTime", objDeviceConnection.DisconnectTime));
                parameterList.Add(new MySqlParameter("@ConnectionStatus", objDeviceConnection.ConnectionStatus));
                parameterList.Add(new MySqlParameter("@UploadCount", objDeviceConnection.UploadCount));
            }

            else
            {
                sql = " update tbl_device_connection set DeviceIp=@DeviceIp, OrgId=@OrgId, CollectorName=@CollectorName, CollectorIp=@CollectorIp, " +
                      " ConnectTime=@ConnectTime, DisconnectTime=@DisconnectTime, ConnectionStatus=@ConnectionStatus, UploadCount=@UploadCount " +
                      " where DeviceNumber=@DeviceNumber ";

                parameterList.Add(new MySqlParameter("@DeviceNumber", objDeviceConnection.DeviceNumber));
                parameterList.Add(new MySqlParameter("@DeviceIp", objDeviceConnection.DeviceIp));
                parameterList.Add(new MySqlParameter("@OrgId", objDeviceConnection.OrgId));
                parameterList.Add(new MySqlParameter("@CollectorName", objDeviceConnection.CollectorName));
                parameterList.Add(new MySqlParameter("@CollectorIp", objDeviceConnection.CollectorIp));
                parameterList.Add(new MySqlParameter("@ConnectTime", objDeviceConnection.ConnectTime));
                parameterList.Add(new MySqlParameter("@DisconnectTime", objDeviceConnection.DisconnectTime));
                parameterList.Add(new MySqlParameter("@ConnectionStatus", objDeviceConnection.ConnectionStatus));
                parameterList.Add(new MySqlParameter("@UploadCount", objDeviceConnection.UploadCount));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_device_connection where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));
            }

            else
            {
                sql = " truncate table tbl_device_connection ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void DeleteByDeviceNumber(string deviceNumber)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_device_connection where DeviceNumber=@DeviceNumber ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public DeviceConnection GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public DeviceConnection GetObjectByDeviceNumber(string deviceNumber)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where DeviceNumber=@DeviceNumber ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));

            return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<DeviceConnection> GetList(string deviceNumber, int orgId, string collectorName, string deviceIp, int connectionStatus, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where 1=1 ";

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and DeviceNumber like concat(\'%\', {0}, \'%\') ".FormatWith("@DeviceNumber");

                parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));
            }

            if (orgId > 0)
            {
                sql += " and OrgId=@OrgId ";

                parameterList.Add(new MySqlParameter("@OrgId", orgId));
            }

            if (collectorName.IsNotNullOrEmpty())
            {
                sql += " and CollectorName like concat(\'%\', {0}, \'%\') ".FormatWith("@CollectorName");

                parameterList.Add(new MySqlParameter("@CollectorName", collectorName));
            }

            if (deviceIp.IsNotNullOrEmpty())
            {
                sql += " and DeviceIp like concat(\'%\', {0}, \'%\') ".FormatWith("@DeviceIp");

                parameterList.Add(new MySqlParameter("@DeviceIp", deviceIp));
            }

            if (connectionStatus > 0)
            {
                sql += " and ConnectionStatus=@ConnectionStatus ";

                parameterList.Add(new MySqlParameter("@ConnectionStatus", connectionStatus));
            }

            sql += " order by PkId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<DeviceConnection>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public List<DeviceConnection> GetAllList()
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where 1=1 ";

            return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray());
        }
    }
}
