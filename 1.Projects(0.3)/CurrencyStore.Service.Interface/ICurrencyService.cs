using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Services.Interface
{
    public interface ICurrencyService
    {
        #region CurrencyInfo
        void BatchSave_Info(List<CurrencyInfo> values);
        void BatchRegister_Info(CurrencyInfo objCurrencyInfo);
        void DeleteAll_Info();
        void Clear_Info(DateTime beforeTime);
        List<CurrencyInfo> GetList_Info(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging);
        #endregion

        #region CurrencyExport
        void Save_Export(CurrencyExport objCurrencyExport);
        void Delete_Export(int pkId);
        CurrencyExport GetObject_Export(int pkId);
        CurrencyExport GetObjectForExecute_Export();
        List<CurrencyExport> GetList_Export(int userId, Pagination paging);
        #endregion

        #region CurrencyBlacklist
        bool CheckExists_Blacklist(CurrencyBlacklist objCurrencyBlacklist);
        void Save_Blacklist(CurrencyBlacklist objCurrencyBlacklist);
        void Delete_Blacklist(int pkId);
        List<CurrencyBlacklist> GetList_Blacklist(string currencyNumber, Pagination paging);
        #endregion
    }
}
