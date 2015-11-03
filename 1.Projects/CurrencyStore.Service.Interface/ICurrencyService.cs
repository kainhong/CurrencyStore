﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Service.Interface
{
    public interface ICurrencyService : ICurrencyStorage
    {
        #region CurrencyInfo
        

        void BatchRegister_Info(CurrencyInfo objCurrencyInfo);

        void DeleteAll_Info();

        void Clear_Info(DateTime beforeTime);
        List<CurrencyInfo> GetList_Info(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging);
        List<CurrencyInfo> GetList_Info(string startTime, string endTime, string currencyNumberA, string currencyNumberB, string currencyNumberC, string currencyNumberD, Pagination paging);
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