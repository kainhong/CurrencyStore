using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface IDeviceInfoRepository
    {
        bool CheckExists(DeviceInfo objDeviceInfo);
        void Save(DeviceInfo objDeviceInfo);
        void Delete(int pkId);
        DeviceInfo GetObject(int pkId);
        DeviceInfo GetObjectByDeviceNumber(string deviceNumber);
        List<DeviceInfo> GetList(int orgId, bool isUnknownOrg, string deviceNumber, string registerIp, int deviceKind, int deviceModel, Pagination paging);
        List<DeviceInfo> GetAllList();
    }
}
