using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface IUserLoginRepository
    {
        void Save(UserLogin objUserLogin);
        void Delete(int pkId);
        void Clear(DateTime beforeTime);
        List<UserLogin> GetList(int userId, Pagination paging);
    }
}
