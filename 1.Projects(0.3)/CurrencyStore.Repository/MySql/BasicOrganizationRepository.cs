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
    public class BasicOrganizationRepository : IBasicOrganizationRepository
    {
        public bool CheckExists(BasicOrganization objBasicOrganization)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_basic_organization where OrgNumber=@OrgNumber ";

            parameterList.Add(new MySqlParameter("@OrgNumber", objBasicOrganization.OrgNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(BasicOrganization objBasicOrganization)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objBasicOrganization.PkId == 0)
            {
                sql = " insert into tbl_basic_organization(OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath) " +
                      " values(@OrgNumber, @OrgName, @OrgAddress, @OrgParentId, @OrgFullPath); " +
                      " select LAST_INSERT_ID(); ";

                parameterList.Add(new MySqlParameter("@OrgNumber", objBasicOrganization.OrgNumber));
                parameterList.Add(new MySqlParameter("@OrgName", objBasicOrganization.OrgName));
                parameterList.Add(new MySqlParameter("@OrgAddress", objBasicOrganization.OrgAddress));
                parameterList.Add(new MySqlParameter("@OrgParentId", objBasicOrganization.OrgParentId));
                parameterList.Add(new MySqlParameter("@OrgFullPath", objBasicOrganization.OrgFullPath));

                objBasicOrganization.PkId = DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString().ToInt();
            }

            else
            {
                sql = " update tbl_basic_organization set OrgName=@OrgName, OrgAddress=@OrgAddress, OrgFullPath=@OrgFullPath where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", objBasicOrganization.PkId));
                parameterList.Add(new MySqlParameter("@OrgName", objBasicOrganization.OrgName));
                parameterList.Add(new MySqlParameter("@OrgAddress", objBasicOrganization.OrgAddress));
                parameterList.Add(new MySqlParameter("@OrgFullPath", objBasicOrganization.OrgFullPath));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int pkId, string orgFullPath)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_basic_organization where PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", pkId));

                if (orgFullPath.IsNotNullOrEmpty())
                {
                    sql += " or OrgFullPath like concat(@OrgFullPath, \'%\') ";

                    parameterList.Add(new MySqlParameter("@OrgFullPath", orgFullPath));
                }
            }

            else
            {
                sql = " truncate table tbl_basic_organization ";
            }

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public BasicOrganization GetObject(int pkId)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath from tbl_basic_organization Where PkId=@PkId ";

            parameterList.Add(new MySqlParameter("@PkId", pkId));

            return DbHelper.ExecuteList<BasicOrganization>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<BasicOrganization> GetList(int orgId, string orgNumber, string orgName, int parentId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath from tbl_basic_organization Where 1=1 ";

            if (orgId > 0)
            {
                sql += " and PkId=@PkId ";

                parameterList.Add(new MySqlParameter("@PkId", orgId));
            }

            if (orgNumber.IsNotNullOrEmpty())
            {
                sql += " and OrgNumber like concat(\'%\', {0}, \'%\') ".FormatWith("@OrgNumber");

                parameterList.Add(new MySqlParameter("@OrgNumber", orgNumber));
            }

            if (orgName.IsNotNullOrEmpty())
            {
                sql += " and OrgName like concat(\'%\', {0}, \'%\') ".FormatWith("@OrgName");

                parameterList.Add(new MySqlParameter("@OrgName", orgName));
            }

            if (parentId > 0)
            {
                sql += " and OrgParentId=@OrgParentId ";

                parameterList.Add(new MySqlParameter("@OrgParentId", parentId));
            }

            sql += " order by PkId desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<BasicOrganization>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<BasicOrganization>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
