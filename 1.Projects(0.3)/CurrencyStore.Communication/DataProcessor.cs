using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CurrencyStore.Common;
using CurrencyStore.Common.Configration;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Communication
{
    public class DataProcessor
    {
        private static int MAX_LENGTH = 10;
        private static int MAX_TIMEOUT = 200;
        ElibLogging logger;
        private Task[] _tasks;
        private ICurrencyService _service;
        private volatile bool _stoped;

        static DataProcessor()
        {
            MAX_LENGTH = Math.Max(CurrencyStoreSection.Instance.Task.PoolSize, 10);
            MAX_TIMEOUT = Math.Max(CurrencyStoreSection.Instance.Task.Interval, 200);
        }
         
        public DataProcessor()
        {
            var len = Math.Max(CurrencyStoreSection.Instance.Task.Capacity, 5);
            _tasks = new Task[len];
            for (int i = 0; i < len; i++)
            {
                var v = i;
                _tasks[i] = new Task(() => Process(v));
            }
            logger = new ElibLogging("trace");
            _service = ServiceFactory.GetService<ICurrencyService>();
        }

        public void Start()
        {
            foreach (var task in _tasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            _stoped = true;
        }

        private void Process(int index)
        {
            var items = new List<CurrencyStore.Entity.CurrencyInfo>();
            long count = 0;
            while (!_stoped)
            {
                items.AddRange(DataPool.GetDatas().Take(MAX_LENGTH));
                ServerInstrumentation.Current.Queue(1);

                int n = Environment.TickCount;
                count += items.Count;

                if (items.Count != 0)
                {
                    try
                    {
                        //_service.BatchSave_Info(items);
                        ServerInstrumentation.Current.Process(items.Count);
                    }
                    catch (Exception ex)
                    {
                        CurrencyStore.Common.ElibExceptionHandler.Handle(ex);
                        ServerInstrumentation.Current.Fault(items.Count);
                        BackUp(items);
                        throw;
                    }

                    logger.Info(string.Format("Task({0}):\tCurrent:{1}\tAll:{2}\tcost:{3}ms",
                        index, items.Count, count, Environment.TickCount - n));

                    items.Clear();
                }
                
                ServerInstrumentation.Current.Queue(-1);
             
                if (MAX_TIMEOUT > 0)
                {
                    Thread.Sleep(MAX_TIMEOUT);
                }
            }
        }

        private void BackUp(List<CurrencyInfo> items)
        {
            var file = @"\fialed\" + Guid.NewGuid() + ".dat";

            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                var fm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                fm.Serialize(fs, items);
            }
        }
    }
}
