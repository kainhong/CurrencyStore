﻿using System;
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
    public class CurrencyInfoRepository : ICurrencyInfoRepository
    {
        const string insert = " INSERT /*+ APPEND */ INTO TBL_CURRENCY_INFO (ORGID, BATCHNUMBER, DEVICENUMBER, DEVICEKINDCODE, DEVICEMODELCODE, " +
                              " OPERATORNUMBER, OPERATETIME, BUSINESSTYPE, CLIENTCARDNUMBER, ORDERNUMBER, CURRENCYKINDCODE, FACEAMOUNT, CURRENCYVERSION, CURRENCYTYPE,  " +
                              " PORTNUMBER, ISSUSPICIOUS, CURRENCYNUMBER, CURRENCYIMAGETYPE, CURRENCYIMAGE, ISDUPLICATE, ISUPLOAD, HOURCODE) " +
                              " VALUES(:P1, :P2, :P3, :P4, :P5, :P6, :P7, :P8, :P9, :P10, :P11, :P12, :P13, :P14, :P15, :P16, :P17, :P18, :P19, :P20, :P21, :P22) ";

        //const string insert = " INSERT INTO TBL_CURRENCY_INFO (ORGID, BATCHNUMBER, DEVICENUMBER, DEVICEKINDCODE, DEVICEMODELCODE, " +
        //                      " OPERATORNUMBER, OPERATETIME, BUSINESSTYPE, CLIENTCARDNUMBER, ORDERNUMBER, CURRENCYKINDCODE, FACEAMOUNT, CURRENCYVERSION, CURRENCYTYPE,  " +
        //                      " PORTNUMBER, ISSUSPICIOUS, CURRENCYNUMBER, CURRENCYIMAGETYPE, CURRENCYIMAGE, ISDUPLICATE, ISUPLOAD, HOURCODE) " +
        //                      " VALUES(:P1, :P2, :P3, :P4, :P5, :P6, :P7, :P8, :P9, :P10, :P11, :P12, :P13, :P14, :P15, :P16, :P17, :P18, :P19, :P20, :P21, :P22) ";

        public void BatchSave(List<CurrencyInfo> values)
        {
            using (var connection = DbHelper.GetDbConnection(DbHelper.CONNECTION_NAME) as OracleConnection)
            {
                using (var command = connection.CreateCommand() as OracleCommand)
                {
                    command.CommandText = insert;
                    command.Connection = connection;
                    command.ArrayBindCount = values.Count;

                    object[] pv1 = new object[values.Count];
                    object[] pv2 = new object[values.Count];
                    object[] pv3 = new object[values.Count];
                    object[] pv4 = new object[values.Count];
                    object[] pv5 = new object[values.Count];
                    object[] pv6 = new object[values.Count];
                    object[] pv7 = new object[values.Count];
                    object[] pv8 = new object[values.Count];
                    object[] pv9 = new object[values.Count];
                    object[] pv10 = new object[values.Count];
                    object[] pv11 = new object[values.Count];
                    object[] pv12 = new object[values.Count];
                    object[] pv13 = new object[values.Count];
                    object[] pv14 = new object[values.Count];
                    object[] pv15 = new object[values.Count];
                    object[] pv16 = new object[values.Count];
                    object[] pv17 = new object[values.Count];
                    object[] pv18 = new object[values.Count];
                    object[] pv19 = new object[values.Count];
                    object[] pv20 = new object[values.Count];
                    object[] pv21 = new object[values.Count];
                    object[] pv22 = new object[values.Count];

                    for (int i = 0; i < values.Count; i++)
                    {
                        pv1[i] = values[i].OrgId;//1
                        pv2[i] = values[i].BatchNumber;//2
                        pv3[i] = values[i].DeviceNumber;//3
                        pv4[i] = values[i].DeviceKindCode;//4
                        pv5[i] = values[i].DeviceModelCode;//5
                        pv6[i] = values[i].OperatorNumber;//6
                        pv7[i] = values[i].OperateTime;//7
                        pv8[i] = values[i].BusinessType;//8
                        pv9[i] = values[i].ClientCardNumber;//9
                        pv10[i] = values[i].OrderNumber;//10
                        pv11[i] = values[i].CurrencyKindCode;//11
                        pv12[i] = values[i].FaceAmount;//12
                        pv13[i] = values[i].CurrencyVersion;//13
                        pv14[i] = values[i].CurrencyType;//14
                        pv15[i] = values[i].PortNumber;//15
                        pv16[i] = values[i].IsSuspicious;//16
                        pv17[i] = values[i].CurrencyNumber;//17
                        pv18[i] = values[i].CurrencyImageType;//18

                        if (values[i].CurrencyImage != null)
                            pv19[i] = values[i].CurrencyImage.ToHexString();//19
                        else
                            pv19[i] = values[i].CurrencyImageString;//19

                        pv20[i] = values[i].IsDuplicate;//20
                        pv21[i] = values[i].IsUpload;//21
                        pv22[i] = values[i].OperateTime.Hour;//22
                    }

                    OracleParameter p1 = new OracleParameter(":P1", OracleDbType.Int32);
                    p1.Value = pv1;
                    command.Parameters.Add(p1);
                    OracleParameter p2 = new OracleParameter(":P2", OracleDbType.Char);
                    p2.Value = pv2;
                    command.Parameters.Add(p2);
                    OracleParameter p3 = new OracleParameter(":P3", OracleDbType.Varchar2);
                    p3.Value = pv3;
                    command.Parameters.Add(p3);
                    OracleParameter p4 = new OracleParameter(":P4", OracleDbType.Int16);
                    p4.Value = pv4;
                    command.Parameters.Add(p4);
                    OracleParameter p5 = new OracleParameter(":P5", OracleDbType.Int16);
                    p5.Value = pv5;
                    command.Parameters.Add(p5);
                    OracleParameter p6 = new OracleParameter(":P6", OracleDbType.Int16);
                    p6.Value = pv6;
                    command.Parameters.Add(p6);
                    OracleParameter p7 = new OracleParameter(":P7", OracleDbType.Date);
                    p7.Value = pv7;
                    command.Parameters.Add(p7);
                    OracleParameter p8 = new OracleParameter(":P8", OracleDbType.Int16);
                    p8.Value = pv8;
                    command.Parameters.Add(p8);
                    OracleParameter p9 = new OracleParameter(":P9", OracleDbType.Varchar2);
                    p9.Value = pv9;
                    command.Parameters.Add(p9);
                    OracleParameter p10 = new OracleParameter(":P10", OracleDbType.Int32);
                    p10.Value = pv10;
                    command.Parameters.Add(p10);
                    OracleParameter p11 = new OracleParameter(":P11", OracleDbType.Int16);
                    p11.Value = pv11;
                    command.Parameters.Add(p11);
                    OracleParameter p12 = new OracleParameter(":P12", OracleDbType.Int16);
                    p12.Value = pv12;
                    command.Parameters.Add(p12);
                    OracleParameter p13 = new OracleParameter(":P13", OracleDbType.Int16);
                    p13.Value = pv13;
                    command.Parameters.Add(p13);
                    OracleParameter p14 = new OracleParameter(":P14", OracleDbType.Int16);
                    p14.Value = pv14;
                    command.Parameters.Add(p14);
                    OracleParameter p15 = new OracleParameter(":P15", OracleDbType.Int16);
                    p15.Value = pv15;
                    command.Parameters.Add(p15);
                    OracleParameter p16 = new OracleParameter(":P16", OracleDbType.Int16);
                    p16.Value = pv16;
                    command.Parameters.Add(p16);
                    OracleParameter p17 = new OracleParameter(":P17", OracleDbType.Varchar2);
                    p17.Value = pv17;
                    command.Parameters.Add(p17);
                    OracleParameter p18 = new OracleParameter(":P18", OracleDbType.Int16);
                    p18.Value = pv18;
                    command.Parameters.Add(p18);
                    OracleParameter p19 = new OracleParameter(":P19", OracleDbType.Varchar2);
                    p19.Value = pv19;
                    command.Parameters.Add(p19);
                    OracleParameter p20 = new OracleParameter(":P20", OracleDbType.Int16);
                    p20.Value = pv20;
                    command.Parameters.Add(p20);
                    OracleParameter p21 = new OracleParameter(":P21", OracleDbType.Int16);
                    p21.Value = pv21;
                    command.Parameters.Add(p21);
                    OracleParameter p22 = new OracleParameter(":P22", OracleDbType.Int16);
                    p22.Value = pv22;
                    command.Parameters.Add(p22);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void BatchRegister(CurrencyInfo objCurrencyInfo)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " update tbl_currency_info set OrgId=:OrgId, DeviceKindCode=:DeviceKindCode, DeviceModelCode=:DeviceModelCode " +
                  " where OrgId=0 and DeviceNumber=:DeviceNumber and DeviceKindCode=0 and DeviceModelCode=0 ";

            parameterList.Add(new OracleParameter(":OrgId", objCurrencyInfo.OrgId));
            parameterList.Add(new OracleParameter(":DeviceKindCode", objCurrencyInfo.DeviceKindCode));
            parameterList.Add(new OracleParameter(":DeviceModelCode", objCurrencyInfo.DeviceModelCode));
            parameterList.Add(new OracleParameter(":DeviceNumber", objCurrencyInfo.DeviceNumber));

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

            sql = " delete from tbl_currency_info where OperateTime<:BeforeTime ";

            parameterList.Add(new OracleParameter(":BeforeTime", beforeTime));

            DbHelper.ExecuteNonQuery(sql, CommandType.Text, parameterList.ToArray());
        }
        public List<CurrencyInfo> GetList(int orgId, bool isUnknownOrg, string startTime, string endTime, string deviceNumber, string currencyNumber, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, BatchNumber, DeviceNumber, DeviceKindCode, DeviceModelCode, OperatorNumber, OperateTime, BusinessType, ClientCardNumber, " +
                  " OrderNumber, CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyType, PortNumber, IsSuspicious, CurrencyNumber, CurrencyImageType, CurrencyImage, " +
                  " IsDuplicate, IsUpload from tbl_currency_info Where 1=1 ";

            if (isUnknownOrg)
            {
                sql += " and OrgId=0 ";
            }

            if (!isUnknownOrg)
            {
                sql += " and OrgId=:OrgId ";

                parameterList.Add(new OracleParameter(":OrgId", orgId));
            }

            if (startTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime>=to_date(:StartTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":StartTime", startTime));
            }

            if (endTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime<=to_date(:EndTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":EndTime", endTime));
            }

            if (deviceNumber.IsNotNullOrEmpty())
            {
                sql += " and DeviceNumber=:DeviceNumber ";

                parameterList.Add(new OracleParameter(":DeviceNumber", deviceNumber));
            }

            if (currencyNumber.IsNotNullOrEmpty())
            {
                sql += " and instr(CurrencyNumber, :CurrencyNumber) > 0 ";

                parameterList.Add(new OracleParameter(":CurrencyNumber", currencyNumber));
            }

            sql += " order by OperateTime desc, OrderNumber desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<CurrencyInfo>(sql, paging, Convert, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<CurrencyInfo>(sql, Convert, CommandType.Text, parameterList.ToArray());
            }
        }
        public List<CurrencyInfo> GetList(string startTime, string endTime, string currencyNumberA, string currencyNumberB, string currencyNumberC, string currencyNumberD, Pagination paging)
        {
            string sql = null;
            List<DbParameter> parameterList = new List<DbParameter>();

            sql = " select OrgId, BatchNumber, DeviceNumber, DeviceKindCode, DeviceModelCode, OperatorNumber, OperateTime, BusinessType, ClientCardNumber, " +
                  " OrderNumber, CurrencyKindCode, FaceAmount, CurrencyVersion, CurrencyType, PortNumber, IsSuspicious, CurrencyNumber, CurrencyImageType, CurrencyImage, " +
                  " IsDuplicate, IsUpload from tbl_currency_info Where 1=1 ";

            if (startTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime>=to_date(:StartTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":StartTime", startTime));
            }

            if (endTime.IsNotNullOrEmpty())
            {
                sql += " and OperateTime<=to_date(:EndTime,'yyyy-MM-dd HH24:mi:ss') ";

                parameterList.Add(new OracleParameter(":EndTime", endTime));
            }

            if (currencyNumberA.IsNotNullOrEmpty() || currencyNumberB.IsNotNullOrEmpty() || currencyNumberC.IsNotNullOrEmpty() || currencyNumberD.IsNotNullOrEmpty())
            {
                sql += " and ( 1=0 ";

                if (currencyNumberA.IsNotNullOrEmpty())
                {

                    sql += " or instr(CurrencyNumber, :CurrencyNumberA) > 0 ";

                    parameterList.Add(new OracleParameter(":CurrencyNumberA", currencyNumberA));
                }

                if (currencyNumberB.IsNotNullOrEmpty())
                {

                    sql += " or instr(CurrencyNumber, :CurrencyNumberB) > 0 ";

                    parameterList.Add(new OracleParameter(":CurrencyNumberB", currencyNumberB));
                }

                if (currencyNumberC.IsNotNullOrEmpty())
                {

                    sql += " or instr(CurrencyNumber, :CurrencyNumberC) > 0 ";

                    parameterList.Add(new OracleParameter(":CurrencyNumberC", currencyNumberC));
                }

                if (currencyNumberD.IsNotNullOrEmpty())
                {

                    sql += " or instr(CurrencyNumber, :CurrencyNumberD) > 0 ";

                    parameterList.Add(new OracleParameter(":CurrencyNumberD", currencyNumberD));
                }

                sql += " ) ";
            }

            sql += " order by OperateTime desc, OrderNumber desc ";

            if (paging != null)
            {
                return DbHelper.ExecutePagingList<CurrencyInfo>(sql, paging, Convert, parameterList.ToArray());
            }

            else
            {
                return DbHelper.ExecuteList<CurrencyInfo>(sql, Convert, CommandType.Text, parameterList.ToArray());
            }
        }
        private bool Convert(CurrencyInfo item, string field, object value)
        {
            if (string.Compare(field, "CurrencyImage", true) != 0)
                return false;
            item.CurrencyImage = CurrencyStore.Utility.Helper.ToBytes(value.ToString());
            return true;
        }
    }
}