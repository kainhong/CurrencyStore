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
    public class UserService : IUserService
    {
        #region UserPermission
        public List<UserPermission> GetList_Permission()
        {
            var repository = ServiceFactory.GetService<IUserPermissionRepository>();

            return repository.GetList();
        }
        #endregion

        #region UserRole
        public bool CheckExists_Role(UserRole objUserRole)
        {
            var repository = ServiceFactory.GetService<IUserRoleRepository>();

            return repository.CheckExists(objUserRole);
        }
        public void Save_Role(UserRole objUserRole)
        {
            var repository = ServiceFactory.GetService<IUserRoleRepository>();

            repository.Save(objUserRole);
        }
        public void Delete_Role(int pkId)
        {
            var repository = ServiceFactory.GetService<IUserRoleRepository>();

            repository.Delete(pkId);
        }
        public UserRole GetObject_Role(int pkId)
        {
            var repository = ServiceFactory.GetService<IUserRoleRepository>();

            return repository.GetObject(pkId);
        }
        public List<UserRole> GetList_Role(string roleName, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IUserRoleRepository>();

            return repository.GetList(roleName, paging);
        }
        #endregion

        #region UserRolePermission
        public void Save_RolePermission(List<UserRolePermission> rolePermissionList)
        {
            var repository = ServiceFactory.GetService<IUserRolePermissionRepository>();

            repository.Save(rolePermissionList);
        }
        public void Delete_RolePermission(int roleId)
        {
            var repository = ServiceFactory.GetService<IUserRolePermissionRepository>();

            repository.Delete(roleId);
        }
        public List<UserRolePermission> GetList_RolePermission(int roleId)
        {
            var repository = ServiceFactory.GetService<IUserRolePermissionRepository>();

            return repository.GetList(roleId);
        }
        #endregion

        #region UserInfo
        public bool CheckExists_Info(UserInfo objUserInfo)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            return repository.CheckExists(objUserInfo);
        }
        public void Save_Info(UserInfo objUserInfo)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            repository.Save(objUserInfo);
        }
        public void Delete_Info(int pkId)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            repository.Delete(pkId);
        }
        public UserInfo GetObject_Info(int pkId)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            return repository.GetObject(pkId);
        }
        public UserInfo GetObjectByUserAccount_Info(string userAccount)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            return repository.GetObjectByUserAccount(userAccount);
        }
        public List<UserInfo> GetList_Info(string userAccount, string userNickName, int orgId, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IUserInfoRepository>();

            return repository.GetList(userAccount, userNickName, orgId, paging);
        }
        #endregion

        #region UserLogin
        public void Save_Login(UserLogin objUserLogin)
        {
            var repository = ServiceFactory.GetService<IUserLoginRepository>();

            repository.Save(objUserLogin);
        }
        public void Delete_Login(int pkId)
        {
            var repository = ServiceFactory.GetService<IUserLoginRepository>();

            repository.Delete(pkId);
        }
        public void Clear_Login(DateTime beforeTime)
        {
            var repository = ServiceFactory.GetService<IUserLoginRepository>();

            repository.Clear(beforeTime);
        }
        public List<UserLogin> GetList_Login(int userId, Pagination paging)
        {
            var repository = ServiceFactory.GetService<IUserLoginRepository>();

            return repository.GetList(userId, paging);
        }
        #endregion
    }
}
