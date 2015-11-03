using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface ICurrencyInfoRepository
    {
        void BatchSave(List<CurrencyInfo> values);
        void BatchRegister(CurrencyInfo objCurrencyInfo);
        void DeleteAll();
        void Clear(DateTime beforeTime);
        List<CurrencyInfo> GetList(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging);
    }
}
