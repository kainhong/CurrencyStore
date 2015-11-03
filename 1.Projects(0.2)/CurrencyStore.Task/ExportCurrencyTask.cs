using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Task
{
    public static class ExportCurrencyTask
    {
        #region Datetime
        private static readonly int ESecond = 2;
        #endregion

        private static Task<bool> CurrentTask
        {
            get;
            set;
        }
        private static Queue<Task<bool>> TaskList
        {
            get;
            set;
        }

        static ExportCurrencyTask()
        {
            ExportCurrencyTask.TaskList = new Queue<Task<bool>>();
        }
        private static Task<bool> GetOrSetTask(Task<bool> objTask)
        {
            Task<bool> result = null;

            if (ExportCurrencyTask.TaskList == null)
            {
                ExportCurrencyTask.TaskList = new Queue<Task<bool>>();
            }

            lock (ExportCurrencyTask.TaskList)
            {
                if (objTask != null)
                {
                    ExportCurrencyTask.TaskList.Enqueue(objTask);
                }

                else
                {
                    if (ExportCurrencyTask.TaskList.Count > 0)
                    {
                        result = ExportCurrencyTask.TaskList.Dequeue();
                    }
                }
            }

            return result;
        }
        public static void AddNext(string exportFilePath)
        {
            Task<bool> newTask = new Task<bool>(() =>
            {
                var service = ServiceFactory.GetService<ICurrencyService>();

                var objCurrencyExport = service.GetObjectForExecute_Export();

                if (objCurrencyExport != null)
                {
                    objCurrencyExport.ExportStatus = 1;

                    service.Save_Export(objCurrencyExport);

                    /**/

                    string startTime = objCurrencyExport.OperateStartTime.IsNotNullOrEmpty() ? objCurrencyExport.OperateStartTime : "";
                    string endTime = objCurrencyExport.OperateEndTime.IsNotNullOrEmpty() ? objCurrencyExport.OperateEndTime : "";

                    var currencyInfoList = service.GetList_Info(objCurrencyExport.OrgId, false, startTime, endTime, objCurrencyExport.DeviceNumber, objCurrencyExport.CurrencyNumber, null);

                    DataTable temp = ExportCurrencyTask.ToDataTable(currencyInfoList);

                    objCurrencyExport.DataCount = currencyInfoList.Count;
                    objCurrencyExport.FileName = FileHelper.GetFileNamebyGuid(".xls");

                    string filePath = FileHelper.ConvertPath(exportFilePath + objCurrencyExport.FileName);

                    temp.SaveToExcel(filePath);

                    objCurrencyExport.FileSize = FileHelper.GetFileSize(filePath);
                    objCurrencyExport.ExportStatus = 2;

                    if (service.GetObject_Export(objCurrencyExport.PkId) != null)
                    {
                        service.Save_Export(objCurrencyExport);
                    }

                    else
                    {
                        FileHelper.DeleteFile(filePath);
                    }
                }

                return true;
            });

            ExportCurrencyTask.GetOrSetTask(newTask);

        }
        public static void Execute()
        {
            if (ExportCurrencyTask.CurrentTask == null || ExportCurrencyTask.CurrentTask.Status == TaskStatus.RanToCompletion)
            {
                ExportCurrencyTask.CurrentTask = ExportCurrencyTask.GetOrSetTask(null);

                if (ExportCurrencyTask.CurrentTask != null)
                {
                    ExportCurrencyTask.CurrentTask.Start();
                }
            }
        }
        public static void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            int cSecond = e.SignalTime.Second;

            if (cSecond % ExportCurrencyTask.ESecond == 0)
            {
                ExportCurrencyTask.Execute();
            }
        }
        private static DataTable ToDataTable(List<CurrencyInfo> currencyInfoList)
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
    }
}
