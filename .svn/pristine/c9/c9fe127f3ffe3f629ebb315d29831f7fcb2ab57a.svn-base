using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Service
{
    public class StatService : IStatService
    {
        public List<DeviceStatInfo> GetList_Device(int orgId, string orgFullPath, int deviceKind, int deviceModel, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IDeviceStatInfoRepository>();

            return repository.GetList(orgId, orgFullPath, deviceKind, deviceModel, paging);
        }
        public List<CurrencyStatInfo> GetList_Currency(int orgId, string startTime, string endTime, string deviceNumber, int deviceKind, int deviceModel, Pagination paging)
        {
            var repository = ServiceFactory.GetService<ICurrencyStatInfoRepository>();

            return repository.GetList(orgId, startTime, endTime, deviceNumber, deviceKind, deviceModel, paging);
        }
        public List<OrganizationStatInfo> GetList_Org(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IOrganizationStatInfoRepository>();

            return repository.GetList(orgId, startTime, endTime, currencyKind, deviceKind, deviceModel, paging);
        }
        public List<OrganizationStatDetailInfo> GetList_OrgDetail(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel)
        {
            var repository = ServiceFactory.GetService<IOrganizationStatDetailInfoRepository>();

            return repository.GetList(orgId, startTime, endTime, currencyKind, deviceKind, deviceModel);
        }
    }
}
