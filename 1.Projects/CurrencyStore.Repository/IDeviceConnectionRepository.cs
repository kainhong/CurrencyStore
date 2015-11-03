using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface IDeviceConnectionRepository
    {
        bool CheckExists(DeviceConnection objDeviceConnection);
        void Save(DeviceConnection objDeviceConnection);
        void Delete(int pkId);
        void DeleteByDeviceNumber(string deviceNumber);
        DeviceConnection GetObject(int pkId);
        DeviceConnection GetObjectByDeviceNumber(string deviceNumber);
        List<DeviceConnection> GetList(string deviceNumber, int orgId, string collectorName, string deviceIp, int connectionStatus, Pagination paging);
        List<DeviceConnection> GetAllList();
    }
}
