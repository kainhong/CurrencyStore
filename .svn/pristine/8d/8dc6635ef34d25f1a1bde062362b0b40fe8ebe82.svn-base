using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface ICurrencyInfoRepository
    {
        void BatchSave(List<CurrencyInfo> values);
        void BatchRegister(CurrencyInfo objCurrencyInfo);
        void DeleteAll();
        void Clear(DateTime beforeTime);
        List<CurrencyInfo> GetList(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging);
        List<CurrencyInfo> GetList(string startTime, string endTime, string currencyNumberA, string currencyNumberB, string currencyNumberC, string currencyNumberD, Pagination paging);
    }
}
