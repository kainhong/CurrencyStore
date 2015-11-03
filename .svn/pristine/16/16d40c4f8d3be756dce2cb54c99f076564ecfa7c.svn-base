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
    public class BasicService : IBasicService
    {
        #region BasicDictionary
        public bool CheckExists_Dictionary(BasicDictionary objBasicDictionary)
        {
            var repository = ServiceFactory.GetService<IBasicDictionaryRepository>();

            return repository.CheckExists(objBasicDictionary);
        }
        public void Save_Dictionary(BasicDictionary objBasicDictionary)
        {
            var repository = ServiceFactory.GetService<IBasicDictionaryRepository>();

            repository.Save(objBasicDictionary);
        }
        public void Delete_Dictionary(int pkId)
        {
            var repository = ServiceFactory.GetService<IBasicDictionaryRepository>();

            repository.Delete(pkId);
        }
        public BasicDictionary GetObject_Dictionary(int pkId)
        {
            var repository = ServiceFactory.GetService<IBasicDictionaryRepository>();

            return repository.GetObject(pkId);
        }
        public List<BasicDictionary> GetList_Dictionary()
        {
            var repository = ServiceFactory.GetService<IBasicDictionaryRepository>();

            return repository.GetList();
        }
        #endregion

        #region BasicOrganization
        public bool CheckExists_Organization(BasicOrganization objBasicOrganization)
        {
            var repository = ServiceFactory.GetService<IBasicOrganizationRepository>();

            return repository.CheckExists(objBasicOrganization);
        }
        public void Save_Organization(BasicOrganization objBasicOrganization)
        {
            var repository = ServiceFactory.GetService<IBasicOrganizationRepository>();

            repository.Save(objBasicOrganization);
        }
        public void Delete_Organization(int pkId, string orgFullPath)
        {
            var repository = ServiceFactory.GetService<IBasicOrganizationRepository>();

            repository.Delete(pkId, orgFullPath);
        }
        public BasicOrganization GetObject_Organization(int pkId)
        {
            var repository = ServiceFactory.GetService<IBasicOrganizationRepository>();

            return repository.GetObject(pkId);
        }
        public List<BasicOrganization> GetList_Organization(int orgId, string orgNumber, string orgName, int parentId, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IBasicOrganizationRepository>();

            return repository.GetList(orgId, orgNumber, orgName, parentId, paging);
        }
        #endregion

        #region BasicParameter
        public bool CheckExists_Parameter(BasicParameter objBasicParameter)
        {
            var repository = ServiceFactory.GetService<IBasicParameterRepository>();

            return repository.CheckExists(objBasicParameter);
        }
        public void Save_Parameter(BasicParameter objBasicParameter)
        {
            var repository = ServiceFactory.GetService<IBasicParameterRepository>();

            repository.Save(objBasicParameter);
        }
        public BasicParameter GetObject_Parameter(int pkId)
        {
            var repository = ServiceFactory.GetService<IBasicParameterRepository>();

            return repository.GetObject(pkId);
        }
        public List<BasicParameter> GetList_Parameter()
        {
            var repository = ServiceFactory.GetService<IBasicParameterRepository>();

            return repository.GetList();
        }
        #endregion
    }
}
