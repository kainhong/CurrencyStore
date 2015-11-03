using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CurrencyStore.Business;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.DataConvert
{
    public static class ListToDataTable
    {
        public static DataTable ToDataTable(this List<CurrencyInfo> currencyInfoList)
        {
            DataTable result = new DataTable("采集明细");

            if (SystemParameter.CurrencyInfoColumn.Contains("[1]"))
            {
                result.Columns.Add("网点机构_25", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[2]"))
            {
                result.Columns.Add("设备号码_15", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[3]"))
            {
                result.Columns.Add("设备类别_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[4]"))
            {
                result.Columns.Add("设备型号_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[5]"))
            {
                result.Columns.Add("操作员号码_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[6]"))
            {
                result.Columns.Add("操作时间_18", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[7]"))
            {
                result.Columns.Add("业务类型_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[8]"))
            {
                result.Columns.Add("客户卡号_25", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[9]"))
            {
                result.Columns.Add("批次号码_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[10]"))
            {
                result.Columns.Add("纸币顺序号_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[11]"))
            {
                result.Columns.Add("纸币种类_15", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[12]"))
            {
                result.Columns.Add("纸币面额_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[13]"))
            {
                result.Columns.Add("纸币版本_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[14]"))
            {
                result.Columns.Add("纸币类型_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[15]"))
            {
                result.Columns.Add("钞口号码_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[16]"))
            {
                result.Columns.Add("是否可疑_10", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[17]"))
            {
                result.Columns.Add("纸币号码_15", typeof(string));
            }
            if (SystemParameter.CurrencyInfoColumn.Contains("[18]"))
            {
                result.Columns.Add("纸币号码图像_20", typeof(byte[]));
            }

            foreach (var item in currencyInfoList)
            {
                DataRow objDR = result.NewRow();

                if (SystemParameter.CurrencyInfoColumn.Contains("[1]"))
                {
                    objDR["网点机构_25"] = item.OrgId.ToString().GetOrgName();
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[2]"))
                {
                    objDR["设备号码_15"] = item.DeviceNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[3]"))
                {
                    objDR["设备类别_10"] = item.DeviceKindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[4]"))
                {
                    objDR["设备型号_10"] = item.DeviceModelCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[5]"))
                {
                    objDR["操作员号码_10"] = item.OperatorNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[6]"))
                {
                    objDR["操作时间_18"] = item.OperateTime.ToString();
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[7]"))
                {
                    objDR["业务类型_10"] = item.BusinessType.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.BusinessType);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[8]"))
                {
                    objDR["客户卡号_25"] = item.ClientCardNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[9]"))
                {
                    objDR["批次号码_10"] = item.BatchNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[10]"))
                {
                    objDR["纸币顺序号_10"] = item.OrderNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[11]"))
                {
                    objDR["纸币种类_15"] = item.CurrencyKindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyKind);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[12]"))
                {
                    objDR["纸币面额_10"] = item.FaceAmount;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[13]"))
                {
                    objDR["纸币版本_10"] = item.CurrencyVersion;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[14]"))
                {
                    objDR["纸币类型_10"] = item.CurrencyType.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyType);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[15]"))
                {
                    objDR["钞口号码_10"] = item.PortNumber.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.PortNumber);
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[16]"))
                {
                    objDR["是否可疑_10"] = item.IsSuspicious.ToString().GetSuspiciousText();
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[17]"))
                {
                    objDR["纸币号码_15"] = item.CurrencyNumber;
                }
                if (SystemParameter.CurrencyInfoColumn.Contains("[18]"))
                {
                    objDR["纸币号码图像_20"] = item.CurrencyImage.ToBitmap(item.CurrencyImageType);
                }

                result.Rows.Add(objDR);
            }

            return result;
        }

        public static DataTable ToDataTable(this List<DeviceInfo> deviceInfoList)
        {
            DataTable result = new DataTable("设备信息");

            result.Columns.Add("设备号码_10", typeof(string));
            result.Columns.Add("软件版本_10", typeof(string));
            result.Columns.Add("设备类别_10", typeof(string));
            result.Columns.Add("设备型号_10", typeof(string));
            result.Columns.Add("网点机构_25", typeof(string));
            result.Columns.Add("上线时间_12", typeof(string));
            result.Columns.Add("设备状态_10", typeof(string));

            foreach (var item in deviceInfoList)
            {
                DataRow objDR = result.NewRow();

                objDR[0] = item.DeviceNumber;
                objDR[1] = item.SoftwareVersion;
                objDR[2] = item.KindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind);
                objDR[3] = item.ModelCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel);
                objDR[4] = item.OrgId.ToString().GetOrgName();
                objDR[5] = item.OnLineTime.ToString("yyyy-MM-dd");
                objDR[6] = item.DeviceStatus.ToString().GetDeviceStatusText();

                result.Rows.Add(objDR);
            }

            return result;
        }

        public static DataTable ToDataTable(this List<DeviceStatInfo> statDeviceList)
        {
            DataTable result = new DataTable("网点设备统计");

            result.Columns.Add("网点机构_25", typeof(string));
            result.Columns.Add("设备类别_10", typeof(string));
            result.Columns.Add("设备型号_10", typeof(string));
            result.Columns.Add("设备数量_10", typeof(string));

            foreach (var item in statDeviceList)
            {
                DataRow objDR = result.NewRow();

                objDR[0] = item.OrgId.ToString().GetOrgName();
                objDR[1] = item.KindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind);
                objDR[2] = item.ModelCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel);
                objDR[3] = item.Count;

                result.Rows.Add(objDR);
            }

            return result;
        }

        public static DataTable ToDataTable(this List<CurrencyStatInfo> statCurrencyList)
        {
            DataTable result = new DataTable("网点纸币统计");

            result.Columns.Add("网点机构_25", typeof(string));
            result.Columns.Add("设备类别_10", typeof(string));
            result.Columns.Add("设备型号_10", typeof(string));
            result.Columns.Add("纸币种类_10", typeof(string));
            result.Columns.Add("纸币面额_10", typeof(string));
            result.Columns.Add("是否可疑_10", typeof(string));
            result.Columns.Add("纸币数量_10", typeof(string));
            result.Columns.Add("纸币总额_10", typeof(string));

            foreach (var item in statCurrencyList)
            {
                DataRow objDR = result.NewRow();

                objDR[0] = item.OrgId.ToString().GetOrgName();
                objDR[1] = item.DeviceKindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind);
                objDR[2] = item.DeviceModelCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel);
                objDR[3] = item.CurrencyKindCode.ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyKind);
                objDR[4] = item.FaceAmount;
                objDR[5] = item.IsSuspicious.ToString().GetSuspiciousText();
                objDR[6] = item.Count;
                objDR[7] = item.Sum;

                result.Rows.Add(objDR);
            }

            return result;
        }

        public static DataTable ToDataTable(this List<OrganizationStatInfo> statOrgList)
        {
            DataTable result = new DataTable("网点明细统计");

            result.Columns.Add("网点机构_25", typeof(string));
            result.Columns.Add("纸币数量_10", typeof(string));
            result.Columns.Add("纸币总额_10", typeof(string));

            foreach (var item in statOrgList)
            {
                DataRow objDR = result.NewRow();

                objDR[0] = item.OrgId.ToString().GetOrgName();
                objDR[1] = item.Count;
                objDR[2] = item.Sum;

                result.Rows.Add(objDR);
            }

            return result;
        }
    }
}
