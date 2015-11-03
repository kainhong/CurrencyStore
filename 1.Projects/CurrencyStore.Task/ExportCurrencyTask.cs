using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CurrencyStore.Business;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;

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

                    DataTable temp = currencyInfoList.ToDataTable();

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
    }
}
