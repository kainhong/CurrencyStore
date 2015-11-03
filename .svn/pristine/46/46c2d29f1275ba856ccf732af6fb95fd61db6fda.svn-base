using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface IBasicOrganizationRepository
    {
        bool CheckExists(BasicOrganization objBasicOrganization);
        void Save(BasicOrganization objBasicOrganization);
        void Delete(int pkId, string orgFullPath);
        BasicOrganization GetObject(int pkId);
        List<BasicOrganization> GetList(int orgId, string orgNumber, string orgName, int parentId, Pagination paging);
    }
}
