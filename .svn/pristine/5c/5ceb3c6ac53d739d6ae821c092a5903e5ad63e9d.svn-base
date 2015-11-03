using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Service.Interface
{
    public interface IStatService
    {
        List<DeviceStatInfo> GetList_Device(int orgId, string orgFullPath, int deviceKind, int deviceModel, Pagination paging);
        List<CurrencyStatInfo> GetList_Currency(int orgId, string startTime, string endTime, string deviceNumber, int deviceKind, int deviceModel, Pagination paging);
        List<OrganizationStatInfo> GetList_Org(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel, Pagination paging);
        List<OrganizationStatDetailInfo> GetList_OrgDetail(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel);
    }
}
