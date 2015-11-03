using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface ICurrencyStatInfoRepository
    {
        List<CurrencyStatInfo> GetList(int orgId, string startTime, string endTime, string deviceNumber, int deviceKind, int deviceModel, Pagination paging);
    }
}
