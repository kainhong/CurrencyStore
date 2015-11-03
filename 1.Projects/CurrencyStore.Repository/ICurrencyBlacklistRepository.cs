using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface ICurrencyBlacklistRepository
    {
        bool CheckExists(CurrencyBlacklist objCurrencyBlacklist);
        void Save(CurrencyBlacklist objCurrencyBlacklist);
        void Delete(int pkId);
        CurrencyBlacklist GetObject(int pkId);
        List<CurrencyBlacklist> GetList(string currencyNumber, Pagination paging);
    }
}
