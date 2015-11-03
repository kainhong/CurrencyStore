using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface IUserInfoRepository
    {
        bool CheckExists(UserInfo objUserInfo);
        void Save(UserInfo objUserInfo);
        void Delete(int pkId);
        UserInfo GetObject(int pkId);
        UserInfo GetObjectByUserAccount(string userAccount);
        List<UserInfo> GetList(string userAccount, string userNickName, int orgId, Pagination paging);
    }
}
