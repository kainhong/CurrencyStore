using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Services.Interface
{
    public interface IDeviceService
    {
        #region DeviceInfo
        bool CheckExists_Info(DeviceInfo objDeviceInfo);
        void Save_Info(DeviceInfo objDeviceInfo);
        void Delete_Info(int pkId);
        DeviceInfo GetObject_Info(int pkId);
        DeviceInfo GetObjectByDeviceNumber_Info(string deviceNumber);
        List<DeviceInfo> GetList_Info(int orgId, bool isUnknownOrg, string deviceNumber, string registerIp, int deviceKind, int deviceModel, Pagination paging);
        List<DeviceInfo> GetAllList_Info();
        #endregion

        #region DeviceConnection
        bool CheckExists_Connection(DeviceConnection objDeviceConnection);
        void Save_Connection(DeviceConnection objDeviceConnection);
        void Delete_Connection(int pkId);
        void DeleteByDeviceNumber_Connection(string deviceNumber);
        DeviceConnection GetObject_Connection(int pkId);
        DeviceConnection GetObjectByDeviceNumber_Connection(string deviceNumber);
        List<DeviceConnection> GetList_Connection(string deviceNumber, int orgId, string collectorName, string deviceIp, int connectionStatus, Pagination paging);
        List<DeviceConnection> GetAllList_Connection();
        #endregion
    }
}
