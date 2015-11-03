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
    public class CurrencyService : ICurrencyService
    {
        #region CurrencyInfo
        public void BatchSave_Info(List<CurrencyInfo> values)
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            repository.BatchSave(values);
        }
        public void BatchRegister_Info(CurrencyInfo objCurrencyInfo)
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            repository.BatchRegister(objCurrencyInfo);
        }
        public void DeleteAll_Info()
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            repository.DeleteAll();
        }
        public void Clear_Info(DateTime beforeTime)
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            repository.Clear(beforeTime);
        }
        public List<CurrencyInfo> GetList_Info(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging)
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            return repository.GetList(orgId, isUnknownOrg, startTime, endTime, deviceNumber, currencyNumber, paging);
        }
        public List<CurrencyInfo> GetList_Info(string startTime, string endTime, string currencyNumberA, string currencyNumberB, string currencyNumberC, string currencyNumberD, Pagination paging)
        {
            var repository = ServiceFactory.GetService<ICurrencyInfoRepository>();

            return repository.GetList(startTime, endTime, currencyNumberA, currencyNumberB, currencyNumberC, currencyNumberD, paging);
        }
        #endregion

        #region CurrencyExport
        public void Save_Export(CurrencyExport objCurrencyExport)
        {
            var repository = ServiceFactory.GetService<ICurrencyExportRepository>();

            repository.Save(objCurrencyExport);
        }
        public void Delete_Export(int pkId)
        {
            var repository = ServiceFactory.GetService<ICurrencyExportRepository>();

            repository.Delete(pkId);
        }
        public CurrencyExport GetObject_Export(int pkId)
        {
            var repository = ServiceFactory.GetService<ICurrencyExportRepository>();

            return repository.GetObject(pkId);
        }
        public CurrencyExport GetObjectForExecute_Export()
        {
            var repository = ServiceFactory.GetService<ICurrencyExportRepository>();

            return repository.GetObjectForExecute();
        }
        public List<CurrencyExport> GetList_Export(int userId, Pagination paging)
        {
            var repository = ServiceFactory.GetService<ICurrencyExportRepository>();

            return repository.GetList(userId, paging);
        }
        #endregion

        #region CurrencyBlacklist
        public bool CheckExists_Blacklist(CurrencyBlacklist objCurrencyBlacklist)
        {
            var repository = ServiceFactory.GetService<ICurrencyBlacklistRepository>();

            return repository.CheckExists(objCurrencyBlacklist);
        }
        public void Save_Blacklist(CurrencyBlacklist objCurrencyBlacklist)
        {
            var repository = ServiceFactory.GetService<ICurrencyBlacklistRepository>();

            repository.Save(objCurrencyBlacklist);
        }
        public void Delete_Blacklist(int pkId)
        {
            var repository = ServiceFactory.GetService<ICurrencyBlacklistRepository>();

            repository.Delete(pkId);
        }
        public List<CurrencyBlacklist> GetList_Blacklist(string currencyNumber, Pagination paging)
        {
            var repository = ServiceFactory.GetService<ICurrencyBlacklistRepository>();

            return repository.GetList(currencyNumber, paging);
        }
        #endregion
    }
}
