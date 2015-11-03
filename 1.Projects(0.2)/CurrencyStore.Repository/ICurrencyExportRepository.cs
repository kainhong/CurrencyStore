using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface ICurrencyExportRepository
    {
        void Save(CurrencyExport objCurrencyExport);
        void Delete(int pkId);
        CurrencyExport GetObject(int pkId);
        CurrencyExport GetObjectForExecute();
        List<CurrencyExport> GetList(int userId, Pagination paging);
    }
}
