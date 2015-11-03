using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using MySql.Data.MySqlClient;

namespace CurrencyStore.Repository.MySql
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public bool CheckExists(UserInfo objUserInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(*) from tbl_user_info where UserAccount=@UserAccount ";

            parameterList.Add(new MySqlParameter("@UserAccount", objUserInfo.UserAccount));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(UserInfo objUserInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objUserInfo.PkId == 0)
            {
                sql = " insert into tbl_user_info(UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId) " +
                      " values(@UserAccount, @UserPwd, @UserNickName, @UserEmail, @UserPhone, @UserStatus, @RoleId, @OrgId) ";

                parameterList.Add(new MySqlParameter("@UserAccount", objUserInfo.UserAccount));
                parameterList.Add(new MySqlParameter("@UserPwd", objUserInfo.UserPwd));
                parameterList.Add(new MySqlParameter("@UserNickName", objUserInfo.UserNickName));
                parameterList.Add(new MySqlParameter("@UserEmail", objUserInfo.UserEmail));
                parameterList.Add(new MySqlParameter("@UserPhone", objUserInfo.UserPhone));
                parameterList.Add(new MySqlParameter("@UserStatus", objUserInfo.UserStatus));
                parameterList.Add(new MySqlParameter("@RoleId", objUserInfo.RoleId));
                parameterList.Add(new MySqlParameter("@OrgId", objUserInfo.OrgId));
            }

            else
            {
                sql = " update tbl_user_info set UserAccount=@UserAccount, UserPwd=@UserPwd, UserNickName=@UserNickName, " +
                      " UserEmail=@UserEmail, UserPhone=@UserPhone, UserStatus=@UserStatus, RoleId=@RoleId, " +
                      " OrgId=@OrgId where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", objUserInfo.PkId));
                parameterList.Add(new MySqlParameter("@UserAccount", objUserInfo.UserAccount));
                parameterList.Add(new MySqlParameter("@UserPwd", objUserInfo.UserPwd));
                parameterList.Add(new MySqlParameter("@UserNickName", objUserInfo.UserNickName));
                parameterList.Add(new MySqlParameter("@UserEmail", objUserInfo.UserEmail));
                parameterList.Add(new MySqlParameter("@UserPhone", objUserInfo.UserPhone));
                parameterList.Add(new MySqlParameter("@UserStatus", objUserInfo.UserStatus));
                parameterList.Add(new MySqlParameter("@RoleId", objUserInfo.RoleId));
                parameterList.Add(new MySqlParameter("@OrgId", objUserInfo.OrgId));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_info where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public UserInfo GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<UserInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public UserInfo GetObjectByUserAccount(string userAccount)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info where UserAccount=@UserAccount ";

            parameterList.Add(new MySqlParameter("@UserAccount", userAccount));

            return DbHelper.ExecuteList<UserInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<UserInfo> GetList(string userAccount, string userNickName, int orgId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info Where 1=1 ";

            if (userAccount.IsNotNullOrEmpty())
            {
                sql += " and UserAccount like concat(\'%\', {0}, \'%\') ".FormatWith("@UserAccount");

                parameterList.Add(new MySqlParameter("@UserAccount", userAccount));
            }

            if (userNickName.IsNotNullOrEmpty())
            {
                sql += " and UserNickName like concat(\'%\', {0}, \'%\') ".FormatWith("@UserNickName");

                parameterList.Add(new MySqlParameter("@UserNickName", userNickName));
            }

            if (orgId > 0)
            {
                sql += " and OrgId=@OrgId ";

                parameterList.Add(new MySqlParameter("@OrgId", orgId));
            }

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<UserInfo>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<UserInfo>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
