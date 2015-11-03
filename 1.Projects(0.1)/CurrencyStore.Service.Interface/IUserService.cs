using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Services.Interface
{
    public interface IUserService
    {
        #region UserPermission
        List<UserPermission> GetList_Permission();
        #endregion

        #region UserRole
        bool CheckExists_Role(UserRole objUserRole);
        void Save_Role(UserRole objUserRole);
        void Delete_Role(int pkId);
        UserRole GetObject_Role(int pkId);
        List<UserRole> GetList_Role(string roleName, Pagination paging);
        #endregion

        #region UserRolePermission
        void Save_RolePermission(List<UserRolePermission> rolePermissionList);
        void Delete_RolePermission(int roleId);
        List<UserRolePermission> GetList_RolePermission(int roleId);
        #endregion

        #region UserInfo
        bool CheckExists_Info(UserInfo objUserInfo);
        void Save_Info(UserInfo objUserInfo);
        void Delete_Info(int pkId);
        UserInfo GetObject_Info(int pkId);
        UserInfo GetObjectByUserAccount_Info(string userAccount);
        List<UserInfo> GetList_Info(string userAccount, string userNickName, int orgId, Pagination paging);
        #endregion

        #region UserLogin
        void Save_Login(UserLogin objUserLogin);
        void Delete_Login(int pkId);
        void Clear_Login(DateTime beforeTime);
        List<UserLogin> GetList_Login(int userId, Pagination paging);
        #endregion
    }
}
