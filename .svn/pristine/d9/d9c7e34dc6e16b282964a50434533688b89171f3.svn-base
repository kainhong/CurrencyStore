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
    public class DeviceConnectionRepository : IDeviceConnectionRepository
    {
        public bool CheckExists(DeviceConnection objDeviceConnection)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_device_connection where DeviceNumber=:DeviceNumber ";

            parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceConnection.DeviceNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(DeviceConnection objDeviceConnection)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objDeviceConnection.PkId == 0)
            {
                sql = " insert into tbl_device_connection(PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount) " +
                      " values(TDC_PKID.NEXTVAL, :DeviceNumber, :DeviceIp, :OrgId, :CollectorName, :CollectorIp, :ConnectTime, :DisconnectTime, :ConnectionStatus, :UploadCount) ";

                parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceConnection.DeviceNumber));
                parameterList.Add(new OracleParameter(":DeviceIp", objDeviceConnection.DeviceIp));
                parameterList.Add(new OracleParameter(":OrgId", objDeviceConnection.OrgId));
                parameterList.Add(new OracleParameter(":CollectorName", objDeviceConnection.CollectorName));
                parameterList.Add(new OracleParameter(":CollectorIp", objDeviceConnection.CollectorIp));
                parameterList.Add(new OracleParameter(":ConnectTime", objDeviceConnection.ConnectTime));
                parameterList.Add(new OracleParameter(":DisconnectTime", objDeviceConnection.DisconnectTime));
                parameterList.Add(new OracleParameter(":ConnectionStatus", objDeviceConnection.ConnectionStatus));
                parameterList.Add(new OracleParameter(":UploadCount", objDeviceConnection.UploadCount));
            }

            else
            {
                sql = " update tbl_device_connection set DeviceIp=:DeviceIp, OrgId=:OrgId, CollectorName=:CollectorName, CollectorIp=:CollectorIp, " +
                      " ConnectTime=:ConnectTime, DisconnectTime=:DisconnectTime, ConnectionStatus=:ConnectionStatus, UploadCount=:UploadCount " +
                      " where DeviceNumber=:DeviceNumber ";

                parameterList.Add(new OracleParameter(":DeviceIp", objDeviceConnection.DeviceIp));
                parameterList.Add(new OracleParameter(":OrgId", objDeviceConnection.OrgId));
                parameterList.Add(new OracleParameter(":CollectorName", objDeviceConnection.CollectorName));
                parameterList.Add(new OracleParameter(":CollectorIp", objDeviceConnection.CollectorIp));
                parameterList.Add(new OracleParameter(":ConnectTime", objDeviceConnection.ConnectTime));
                parameterList.Add(new OracleParameter(":DisconnectTime", objDeviceConnection.DisconnectTime));
                parameterList.Add(new OracleParameter(":ConnectionStatus", objDeviceConnection.ConnectionStatus));
                parameterList.Add(new OracleParameter(":UploadCount", objDeviceConnection.UploadCount));
                parameterList.Add(new OracleParameter(":DeviceNumber", objDeviceConnection.DeviceNumber));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_device_connection where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", pkId));
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

            sql = " delete from tbl_device_connection where DeviceNumber=:DeviceNumber ";

            parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public DeviceConnection GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public DeviceConnection GetObjectByDeviceNumber(string deviceNumber)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where DeviceNumber=:DeviceNumber ";

            parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));

            return DbHelper.ExecuteList<DeviceConnection>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<DeviceConnection> GetList(string deviceNumber, int orgId, string collectorName, string deviceIp, int connectionStatus, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, DeviceNumber, DeviceIp, OrgId, CollectorName, CollectorIp, ConnectTime, DisconnectTime, ConnectionStatus, UploadCount from tbl_device_connection Where 1=1 ";

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and instr(DeviceNumber, :DeviceNumber) > 0 ";
                
                parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));
            }

            if (orgId > 0)
            {
                sql += " and OrgId=:OrgId ";

                parameterList.Add(new OracleParameter(":OrgId", orgId));
            }

            if (collectorName.IsNotNullOrEmpty())
            {
                sql += " and instr(CollectorName, :CollectorName) > 0 ";
                
                parameterList.Add(new OracleParameter(":CollectorName", collectorName));
            }

            if (deviceIp.IsNotNullOrEmpty())
            {
                sql += " and instr(DeviceIp, :DeviceIp) > 0 ";
                
                parameterList.Add(new OracleParameter(":DeviceIp", deviceIp));
            }

            if (connectionStatus > 0)
            {
                sql += " and ConnectionStatus=:ConnectionStatus ";

                parameterList.Add(new OracleParameter(":ConnectionStatus", connectionStatus));
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
