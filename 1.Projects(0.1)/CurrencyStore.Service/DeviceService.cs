using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Services
{
    public class DeviceService : IDeviceService
    {
        #region DeviceInfo
        public bool CheckExists_Info(DeviceInfo objDeviceInfo)
        {
            var repository = ServiceFactory.GetService<IDeviceInfoRepository>();

            return repository.CheckExists(objDeviceInfo);
        }
        public void Save_Info(DeviceInfo objDeviceInfo)
        {
            var deviceInfoRepository = ServiceFactory.GetService<IDeviceInfoRepository>();
            var deviceConnectionRepository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            if (objDeviceInfo.PkId == 0)
            {
                DeviceInfo diTemp = deviceInfoRepository.GetObjectByDeviceNumber(objDeviceInfo.DeviceNumber);

                if (diTemp != null)
                {
                    objDeviceInfo.PkId = diTemp.PkId;
                }
            }

            deviceInfoRepository.Save(objDeviceInfo);

            var objDeviceConnection = deviceConnectionRepository.GetObjectByDeviceNumber(objDeviceInfo.DeviceNumber);

            if (objDeviceConnection == null)
            {
                objDeviceConnection = new DeviceConnection()
                {
                    DeviceNumber = objDeviceInfo.DeviceNumber,
                    OrgId = objDeviceInfo.OrgId,
                    CollectorName = String.Empty,
                    CollectorIp = String.Empty,
                    ConnectTime = DateTime.MinValue,
                    DisconnectTime = DateTime.MinValue,
                    ConnectionStatus = (int)DeviceConnection.ConnectionStatusEnum.Disconnect,
                    UploadCount = 0
                };
            }

            else
            {
                objDeviceConnection.OrgId = objDeviceInfo.OrgId;
            }

            deviceConnectionRepository.Save(objDeviceConnection);

            DeviceCache.Current.Set(objDeviceInfo);
        }
        public void Delete_Info(int pkId)
        {
            var deviceInfoRepository = ServiceFactory.GetService<IDeviceInfoRepository>();
            var deviceConnectionRepository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            if (pkId > 0)
            {
                var objDeviceInfo = this.GetObject_Info(pkId);

                if (objDeviceInfo != null)
                {
                    DeviceCache.Current.Remove(objDeviceInfo.DeviceNumber);

                    deviceConnectionRepository.DeleteByDeviceNumber(objDeviceInfo.DeviceNumber);
                    deviceInfoRepository.Delete(pkId);
                }
            }

            else
            {
                foreach (var item in deviceInfoRepository.GetAllList())
                {
                    DeviceCache.Current.Remove(item.DeviceNumber);
                }

                deviceConnectionRepository.Delete(pkId);
                deviceInfoRepository.Delete(pkId);
            }
        }
        public DeviceInfo GetObject_Info(int pkId)
        {
            var repository = ServiceFactory.GetService<IDeviceInfoRepository>();

            return repository.GetObject(pkId);
        }
        public DeviceInfo GetObjectByDeviceNumber_Info(string deviceNumber)
        {
            var repository = ServiceFactory.GetService<IDeviceInfoRepository>();

            return repository.GetObjectByDeviceNumber(deviceNumber);
        }
        public List<DeviceInfo> GetList_Info(int orgId, bool isUnknownOrg, string deviceNumber, string registerIp, int deviceKind, int deviceModel, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IDeviceInfoRepository>();

            return repository.GetList(orgId, isUnknownOrg, deviceNumber, registerIp, deviceKind, deviceModel, paging);
        }
        public List<DeviceInfo> GetAllList_Info()
        {
            var repository = ServiceFactory.GetService<IDeviceInfoRepository>();

            return repository.GetAllList();
        }
        #endregion

        #region DeviceConnection
        public bool CheckExists_Connection(DeviceConnection objDeviceConnection)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            return repository.CheckExists(objDeviceConnection);
        }
        public void Save_Connection(DeviceConnection objDeviceConnection)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            repository.Save(objDeviceConnection);
        }
        public void Delete_Connection(int pkId)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            repository.Delete(pkId);
        }
        public void DeleteByDeviceNumber_Connection(string deviceNumber)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            repository.DeleteByDeviceNumber(deviceNumber);
        }
        public DeviceConnection GetObject_Connection(int pkId)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            return repository.GetObject(pkId);
        }
        public DeviceConnection GetObjectByDeviceNumber_Connection(string deviceNumber)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            return repository.GetObjectByDeviceNumber(deviceNumber);
        }
        public List<DeviceConnection> GetList_Connection(string deviceNumber, int orgId, string collectorName, string deviceIp, int connectionStatus, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            return repository.GetList(deviceNumber, orgId, collectorName, deviceIp, connectionStatus, paging);
        }
        public List<DeviceConnection> GetAllList_Connection()
        {
            var repository = ServiceFactory.GetService<IDeviceConnectionRepository>();

            return repository.GetAllList();
        }
        #endregion
    }
}
