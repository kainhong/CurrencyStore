using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Service.Interface;
using System.IO;
using CurrencyStore.Collector.Configration;
using CurrencyStore.Entity;
using CurrencyStore.Utility;
namespace CurrencyStore.Collector.Storage
{
    public class FileStorage : ICurrencyStorage
    {
        DirectoryInfo root;
        string file;
        public FileStorage()
        {
            var path = CurrencyStoreSection.Instance.Task.Storage.Value;
            if (string.IsNullOrEmpty(path))
                path = "datas";
            path = Path.Combine(path, DateTime.Now.ToString("yyyyMMddHH"));
            file = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString().PadRight(5, '0')
                       + "_" + this.GetHashCode().ToString().PadRight(10, '0').TrimStart('-') + ".dat";

            root = new DirectoryInfo(path);
            if (!root.Exists)
                root.Create();

            file = Path.Combine(path, file);

        }

        public void BatchSave_Info(List<Entity.CurrencyInfo> values)
        {
            lock (file)
            {
                using (var stream = File.AppendText(file))
                {
                    foreach (var item in values)
                    {
                        var line = GetItemValueScript(item);
                        stream.WriteLine(line);
                    }
                }
            }
        }

        private string GetItemValueScript(CurrencyInfo item)
        {
            return string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15},'{16}','{17}','{18}','{19}','{20}')",
                item.OrgId,//0
                item.BatchNumber,//1
                item.DeviceNumber,//2
                item.DeviceKindCode,//3
                item.DeviceModelCode,//4
                item.OperatorNumber,//5
                item.OperateTime.ToString("yyyy-MM-dd HH:mm:ss"),//6
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
    }
}
