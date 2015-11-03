using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Services.Interface
{
    public interface IBasicService
    {
        #region BasicDictionary
        bool CheckExists_Dictionary(BasicDictionary objBasicDictionary);
        void Save_Dictionary(BasicDictionary objBasicDictionary);
        void Delete_Dictionary(int pkId);
        BasicDictionary GetObject_Dictionary(int pkId);
        List<BasicDictionary> GetList_Dictionary();
        #endregion

        #region BasicOrganization
        bool CheckExists_Organization(BasicOrganization objBasicOrganization);
        void Save_Organization(BasicOrganization objBasicOrganization);
        void Delete_Organization(int pkId, string orgFullPath);
        BasicOrganization GetObject_Organization(int pkId);
        List<BasicOrganization> GetList_Organization(int orgId, string orgNumber, string orgName, int parentId, Pagination paging);
        #endregion

        #region BasicParameter
        bool CheckExists_Parameter(BasicParameter objBasicParameter);
        void Save_Parameter(BasicParameter objBasicParameter);
        BasicParameter GetObject_Parameter(int pkId);
        List<BasicParameter> GetList_Parameter();
        #endregion
    }
}
