using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Repository;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.Query;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CurrencyStore.Repository.Oracle
{
    public class BasicOrganizationRepository : IBasicOrganizationRepository
    {
        public bool CheckExists(BasicOrganization objBasicOrganization)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select count(1) from tbl_basic_organization where OrgNumber=:OrgNumber ";

            parameterList.Add(new OracleParameter(":OrgNumber", objBasicOrganization.OrgNumber));

            return int.Parse(DbHelper.ExecuteScalar(sql, CommandType.Text, parameterList.ToArray()).ToString()) > 0;
        }
        public void Save(BasicOrganization objBasicOrganization)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (objBasicOrganization.PkId == 0)
            {
                sql = " insert into tbl_basic_organization(PkId, OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath) " +
                      " values(TBO_PKID.NEXTVAL, :OrgNumber, :OrgName, :OrgAddress, :OrgParentId, :OrgFullPath) " +
                      " RETURNING PkId INTO :PkId ";

                parameterList.Add(new OracleParameter(":OrgNumber", objBasicOrganization.OrgNumber));
                parameterList.Add(new OracleParameter(":OrgName", objBasicOrganization.OrgName));
                parameterList.Add(new OracleParameter(":OrgAddress", objBasicOrganization.OrgAddress));
                parameterList.Add(new OracleParameter(":OrgParentId", objBasicOrganization.OrgParentId));
                parameterList.Add(new OracleParameter(":OrgFullPath", objBasicOrganization.OrgFullPath));
                var p = new OracleParameter(":PkId", OracleDbType.Int32, 0, ParameterDirection.Output);
                parameterList.Add(p);

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());

                objBasicOrganization.PkId = Convert.ToInt32(((OracleDecimal)p.Value).Value);
            }

            else
            {
                sql = " update tbl_basic_organization set OrgName=:OrgName, OrgAddress=:OrgAddress, OrgFullPath=:OrgFullPath where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":OrgName", objBasicOrganization.OrgName));
                parameterList.Add(new OracleParameter(":OrgAddress", objBasicOrganization.OrgAddress));
                parameterList.Add(new OracleParameter(":OrgFullPath", objBasicOrganization.OrgFullPath));
                parameterList.Add(new OracleParameter(":PkId", objBasicOrganization.PkId));

                DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
            }
        }
        public void Delete(int pkId, string orgFullPath)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            if (pkId > 0)
            {
                sql = " delete from tbl_basic_organization where PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", pkId));

                if (orgFullPath.IsNotNullOrEmpty())
                {
                    sql += " or OrgFullPath like concat(:OrgFullPath, \'%\') ";

                    parameterList.Add(new OracleParameter(":OrgFullPath", orgFullPath));
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

            sql = " select PkId, OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath from tbl_basic_organization Where PkId=:PkId ";

            parameterList.Add(new OracleParameter(":PkId", pkId));

            return DbHelper.ExecuteList<BasicOrganization>(sql, CommandType.Text, parameterList.ToArray()).FirstOrDefault();
        }
        public List<BasicOrganization> GetList(int orgId, string orgNumber, string orgName, int parentId, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select PkId, OrgNumber, OrgName, OrgAddress, OrgParentId, OrgFullPath from tbl_basic_organization Where 1=1 ";

            if (orgId > 0)
            {
                sql += " and PkId=:PkId ";

                parameterList.Add(new OracleParameter(":PkId", orgId));
            }

            if (orgNumber.IsNotNullOrEmpty())
            {
                sql += " and instr(OrgNumber, :OrgNumber) > 0 ";

                parameterList.Add(new OracleParameter(":OrgNumber", orgNumber));
            }

            if (orgName.IsNotNullOrEmpty())
            {
                sql += " and instr(OrgName, :OrgName) > 0 ";

                parameterList.Add(new OracleParameter(":OrgName", orgName));
            }

            if (parentId > 0)
            {
                sql += " and OrgParentId=:OrgParentId ";

                parameterList.Add(new OracleParameter(":OrgParentId", parentId));
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
