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
    class StoreProcessor
    {
        private ICurrencyService _service;
        private ElibLogging logger;
        private int index;
        private long count;
        private int MAX_LENGTH;
        private bool storaged = true;
        static int MAX_TIMEOUT = 10000;

        public StoreProcessor(int index)
        {
            this.index = index;
            logger = new ElibLogging("trace");
            _service = ServiceFactory.GetService<ICurrencyService>();
            this.DateTime = DateTime.Now;
            Items = new List<CurrencyInfo>();
            MAX_LENGTH = Math.Max(CurrencyStoreSection.Instance.Task.PoolSize, 10);
            MAX_TIMEOUT = Math.Max(CurrencyStoreSection.Instance.Task.Timeout, 15000);
            storaged = CurrencyStoreSection.Instance.Task.Storaged;
        }

        

        public DateTime DateTime { get; private set; }

        public List<CurrencyInfo> Items { get; private set; }

        public void Add(CurrencyInfo item)
        {
            Items.Add(item);
            Update();
            ServerInstrumentation.Current.Produce();
        }

        public void Update(bool forcibly = false)
        {
            if (Items.Count >= MAX_LENGTH || forcibly
               || (Items.Count > 0 && (DateTime.Now - this.DateTime).TotalMilliseconds >= MAX_TIMEOUT))
            {
                Processor();
            }
        }

        void Processor()
        {
            var items = this.Reset();

            var action = new Action(() => Processor(items));
            action.BeginInvoke((ar) =>
            {
                action.EndInvoke(ar);
            }, action);

        }

        List<CurrencyInfo> Reset()
        {
            var items = this.Items;
            this.DateTime = DateTime.Now;
            Items = new List<CurrencyInfo>();
            return items;

        }

        private void Processor(List<CurrencyInfo> items)
        {
            ServerInstrumentation.Current.Queue(1);

            int n = Environment.TickCount;
            count += items.Count;

            if (items.Count != 0)
            {
                try
                {
                    _service.BatchSave_Info(items);
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
            }
            ServerInstrumentation.Current.Queue(-1);
        }

        private void BackUp(List<CurrencyInfo> items)
        {
            var file = @"log\" + Guid.NewGuid() + ".dat";

            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                var fm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                fm.Serialize(fs, items);
            }
        }
    }
}
