using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface IUserRoleRepository
    {
        bool CheckExists(UserRole objUserRole);
        void Save(UserRole objUserRole);
        void Delete(int pkId);
        UserRole GetObject(int pkId);
        List<UserRole> GetList(string roleName, Pagination paging);
    }
}
