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
    public class CurrencyInfoRepository : ICurrencyInfoRepository
    {
        ElibLogging logger;
        public CurrencyInfoRepository()
        {
            logger = new ElibLogging("script");
        }
        public void BatchSave(List<CurrencyInfo> values)
        {
            if (values.Count() > 0)
            {
                var script = GetInsertScript(values);
                logger.Info(script);
                DbHelper.ExecuteNonQuery(script);
            }
        }
        private string GetInsertScript(List<CurrencyInfo> values)
        {
            const string insert = (@"INSERT INTO `currencystore`.`tbl_currency_info` (
                            `OrgId`,
                            `BatchNumber`,
                            `DeviceNumber`,
                            `DeviceKindCode`,
                            `DeviceModelCode`,
                            `OperatorNumber`,
                            `OperateTime`,
                            `BusinessType`,
                            `ClientCardNumber`,
                            `OrderNumber`,
                            `CurrencyKindCode`,
                            `FaceAmount`,
                            `CurrencyVersion`,
                            `CurrencyType`,
                            `PortNumber`,
                            `IsSuspicious`,
                            `CurrencyNumber`,
                            `CurrencyImageType`,
                            `CurrencyImage`,
                            `IsDuplicate`,
                            `IsUpload`
                        ) VALUES ");

            var items = values.Select(c => GetItemValueScript(c));
            var tmp = string.Join(",\r\n", items);
            if (string.IsNullOrEmpty(tmp))
                return string.Empty;
            return insert + tmp;
        }
        private string GetItemValueScript(CurrencyInfo item)
        {
            return string.Format("({0},'{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}',{9},'{10}',{11},{12},{13},{14},{15},'{16}',{17},0x{18},{19},{20})",
                item.OrgId,//0
                item.BatchNumber,//1
                item.DeviceNumber,//2
                item.DeviceKindCode,//3
                item.DeviceModelCode,//4
                item.OperatorNumber,//5
                item.OperateTime.ToString("yyyy-MM-dd HH-mm-ss"),//6
                item.BusinessType,//7
                item.ClientCardNumber,//8
                item.OrderNumber,//9
                item.CurrencyKindCode,//10
                item.FaceAmount,//11
                item.CurrencyVersion,//12
                item.CurrencyType,//13
                item.PortNumber,//14
                item.IsSuspicious,//15
                item.CurrencyNumber,//16
                item.CurrencyImageType,//17
                item.CurrencyImage.ToHexString(),//18
                item.IsDuplicate,//19
                item.IsUpload); //20
        }

        public void BatchRegister(CurrencyInfo objCurrencyInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " update tbl_currency_info set OrgId=@OrgId, DeviceKindCode=@DeviceKindCode, DeviceModelCode=@DeviceModelCode " +
                  " where DeviceNumber=@DeviceNumber and OrgId=0 and DeviceKindCode=0 and DeviceModelCode=0 ";

            parameterList.Add(new MySqlParameter("@DeviceNumber", objCurrencyInfo.DeviceNumber));
            parameterList.Add(new MySqlParameter("@OrgId", objCurrencyInfo.OrgId));
            parameterList.Add(new MySqlParameter("@DeviceKindCode", objCurrencyInfo.DeviceKindCode));
            parameterList.Add(new MySqlParameter("@DeviceModelCode", objCurrencyInfo.DeviceModelCode));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void DeleteAll()
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();
            
            sql = " truncate table tbl_currency_info ";

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public void Clear(DateTime beforeTime)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " delete from tbl_currency_info where OperateTime<@BeforeTime ";

            parameterList.Add(new MySqlParameter("@BeforeTime", beforeTime));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public List<CurrencyInfo> GetList(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, BatchNumber, DeviceNumber, DeviceKindCode, DeviceModelCode, OperatorNumber, OperateTime, BusinessType, ClientCardNumber, " +
                  " OrderNumber, CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyType, PortNumber, IsSuspicious, CurrencyNumber, CurrencyImageType, CurrencyImage, " +
                  " IsDuplicate, IsUpload from tbl_currency_info Where 1=1 ";

            if (isUnknownOrg || (!isUnknownOrg && orgId > 0))
            {
                sql += " and OrgId=@OrgId ";

                parameterList.Add(new MySqlParameter("@OrgId", orgId));
            }

            if (!isUnknownOrg && orgId == 0)
            {
                sql += " and OrgId>0 ";
            }

            if (startTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime>=@StartTime ";

                parameterList.Add(new MySqlParameter("@StartTime", startTime));
            }

            if (endTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime<=@EndTime ";

                parameterList.Add(new MySqlParameter("@EndTime", endTime));
            }

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and DeviceNumber=@DeviceNumber ";

                parameterList.Add(new MySqlParameter("@DeviceNumber", deviceNumber));
            }

            if (currencyNumber.IsNotNullOrEmpty())
            {
                sql += " and CurrencyNumber like concat(\'%\', {0}, \'%\') ".FormatWith("@CurrencyNumber");

                parameterList.Add(new MySqlParameter("@CurrencyNumber", currencyNumber));
            }

            sql += " order by OperateTime desc, OrderNumber desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<CurrencyInfo>(sql, paging, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<CurrencyInfo>(sql, CommandType.Text, parameterList.ToArray());
            }
        }
    }
}
