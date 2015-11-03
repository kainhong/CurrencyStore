using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;

namespace CurrencyStore.DuplicateDataClear
{
    public class DataConverter
    {
        public class ConvertResult
        {
            public string DeviceNumber { get; set; }
            public string CollectDate { get; set; }
            public int BeforeCount { get; set; }
            public int AfterCount { get; set; }
            public string TargetFile { get; set; }
        }

        public string DataFilePath { get; set; }
        public string SaveFileFullPath { get; set; }
        public string SourceFile { get; set; }
        public string ExportDate { get; set; }
        public string BankCode { get; set; }
        public string RecordNumber { get; set; }
        public string BusinessType { get; set; }
        public string FormatVersion { get; set; }
        public string FilePostfix { get; set; }
        public string DeviceNumber { get; set; }
        public bool FilterDuplicateData { get; set; }

        public ConvertResult Convert()
        {
            ConvertResult result = new ConvertResult();

            List<CurrencyInfo> sourceDataList = this.GetData();
            CurrencyInfo firstData = sourceDataList.First();
            List<CurrencyInfo> newDataList = this.Filter(sourceDataList);

            result.DeviceNumber = firstData.DeviceNumber;
            result.CollectDate = firstData.OperateTime.ToString("yyyyMMdd");
            result.BeforeCount = sourceDataList.Count;
            result.AfterCount = newDataList.Count;
            result.TargetFile = "{0}_{1}_{2}_{3}_{4}_{5}.{6}".FormatWith(result.CollectDate,
                this.BankCode,
                this.RecordNumber,
                this.BusinessType,
                result.AfterCount.ToString().PadLeft(10, '0'),
                this.FormatVersion,
                this.FilePostfix);

            this.Save(newDataList, this.SaveFileFullPath + @"\" + result.TargetFile);

            return result;
        }

        private List<CurrencyInfo> GetData()
        {
            string fileName = this.DataFilePath + @"\" + SourceFile;

            using (CurrencyFileReader fileReader = new CurrencyFileReader(fileName))
            {
                FileHeader fileHeader = fileReader.FileHeader;

                return fileReader.Read(false).ToList();
            }
        }

        private List<CurrencyInfo> Filter(List<CurrencyInfo> dataList)
        {
            List<CurrencyInfo> result = dataList;

            if (this.FilterDuplicateData)
            {
                result = new List<CurrencyInfo>();

                var q = from item in dataList group item by item.CurrencyNumber into g select g;

                foreach (var gp in q)
                {
                    if ((gp.Count() > 1 && (gp.Key == "!倾斜/污染" || gp.Key.Trim().IsNullOrEmpty())) || gp.Count() == 1)
                    {
                        result.AddRange(gp);
                    }

                    else if (gp.Count() > 1)
                    {
                        result.Add((from item in gp orderby item.OperateTime descending select item).First());
                    }
                }

            }

            return (from item in result orderby item.OperateTime ascending select item).ToList();
        }

        private void Save(List<CurrencyInfo> dataList, string fileFullPath)
        {
            StringBuilder content = new StringBuilder();

            foreach (CurrencyInfo item in dataList)
            {
                content.Append("{0},{1},{2},{3},{4},{5},{6},{7}{8}".FormatWith(this.DeviceNumber + item.DeviceNumber,
                    item.OperateTime.ToString("yyyyMMddHHmmss"),
                    item.CurrencyNumber.Replace("!倾斜/污染", "__________").PadLeft(10, '_'),
                    "CNY",
                    item.FaceAmount.ToString().PadLeft(3, '0'),
                    item.CurrencyVersion == 0 ? 9999 : item.CurrencyVersion,
                    item.IsSuspicious == 0 ? 1 : 0,
                    "00",
                    Environment.NewLine));
            }

            FileHelper.WriteFile(fileFullPath, content.ToString());
        }
    }
}
