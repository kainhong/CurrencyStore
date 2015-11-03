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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CurrencyStore.Repository.Oracle
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public bool CheckExists(UserInfo objUserInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_user_info where UserAccount=:UserAccount ";

            parameterList.Add(new OracleParameter(":UserAccount", objUserInfo.UserAccount));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(UserInfo objUserInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objUserInfo.PkId == 0)
            {
                sql = " insert into tbl_user_info(PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId) " +
                      " values(TUI_PKID.NEXTVAL, :UserAccount, :UserPwd, :UserNickName, :UserEmail, :UserPhone, :UserStatus, :RoleId, :OrgId) ";

                parameterList.Add(new OracleParameter(":UserAccount", objUserInfo.UserAccount));
                parameterList.Add(new OracleParameter(":UserPwd", objUserInfo.UserPwd));
                parameterList.Add(new OracleParameter(":UserNickName", objUserInfo.UserNickName));
                parameterList.Add(new OracleParameter(":UserEmail", objUserInfo.UserEmail));
                parameterList.Add(new OracleParameter(":UserPhone", objUserInfo.UserPhone));
                parameterList.Add(new OracleParameter(":UserStatus", objUserInfo.UserStatus));
                parameterList.Add(new OracleParameter(":RoleId", objUserInfo.RoleId));
                parameterList.Add(new OracleParameter(":OrgId", objUserInfo.OrgId));
            }

            else
            {
                sql = " update tbl_user_info set UserAccount=:UserAccount, UserPwd=:UserPwd, UserNickName=:UserNickName, " +
                      " UserEmail=:UserEmail, UserPhone=:UserPhone, UserStatus=:UserStatus, RoleId=:RoleId, " +
                      " OrgId=:OrgId where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":UserAccount", objUserInfo.UserAccount));
                parameterList.Add(new OracleParameter(":UserPwd", objUserInfo.UserPwd));
                parameterList.Add(new OracleParameter(":UserNickName", objUserInfo.UserNickName));
                parameterList.Add(new OracleParameter(":UserEmail", objUserInfo.UserEmail));
                parameterList.Add(new OracleParameter(":UserPhone", objUserInfo.UserPhone));
                parameterList.Add(new OracleParameter(":UserStatus", objUserInfo.UserStatus));
                parameterList.Add(new OracleParameter(":RoleId", objUserInfo.RoleId));
                parameterList.Add(new OracleParameter(":OrgId", objUserInfo.OrgId));
                parameterList.Add(new OracleParameter(":PkId", objUserInfo.PkId));
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Delete(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_user_info where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public UserInfo GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<UserInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public UserInfo GetObjectByUserAccount(string userAccount)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info where UserAccount=:UserAccount ";

            parameterList.Add(new OracleParameter(":UserAccount", userAccount));

            return DbHelper.ExecuteList<UserInfo>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<UserInfo> GetList(string userAccount, string userNickName, int orgId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, UserAccount, UserPwd, UserNickName, UserEmail, UserPhone, UserStatus, RoleId, OrgId from tbl_user_info Where 1=1 ";

            if (userAccount.IsNotNullOrEmpty())
            {
                sql += " and instr(UserAccount, :UserAccount) > 0 ";
                
                parameterList.Add(new OracleParameter(":UserAccount", userAccount));
            }

            if (userNickName.IsNotNullOrEmpty())
            {
                sql += " and instr(UserNickName, :UserNickName) > 0 ";
                
                parameterList.Add(new OracleParameter(":UserNickName", userNickName));
            }

            if (orgId > 0)
            {
                sql += " and OrgId=:OrgId ";

                parameterList.Add(new OracleParameter(":OrgId", orgId));
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
