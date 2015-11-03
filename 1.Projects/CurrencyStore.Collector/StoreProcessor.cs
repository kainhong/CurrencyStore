using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CurrencyStore.Collector.Configration;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Collector.Storage;
using CurrencyStore.Collector.Remoting;

namespace CurrencyStore.Collector
{
    class StoreProcessor : IDisposable
    {
        private ICurrencyStorage _service;
        private ElibLogging logger;
        private int index;
        private long count;
        private int MAX_LENGTH;
        private bool storaged = true;

        private ICurrencyStorage GetService()
        {
            if (!storaged)
                return new EmptyStorage();
            var type = CurrencyStoreSection.Instance.Task.Storage.Type;
            if (type == "file")
                return new FileStorage();
            else if (type == "empty")
                return new EmptyStorage();
            else if (type == "remote")
                return RemoteAgency.Instance.GetRandmonAgent(index);
            else
                return ServiceFactory.GetService<ICurrencyService>();
        }

        public StoreProcessor(int index)
        {
            this.index = index;
            logger = new ElibLogging("trace");
            _service = GetService();
            this.DateTime = DateTime.Now;
            Items = new List<CurrencyInfo>();
            MAX_LENGTH = Math.Max(CurrencyStoreSection.Instance.Task.PoolSize, 10);
            storaged = CurrencyStoreSection.Instance.Task.Storage.Enable;
        }

        List<CurrencyInfo> Reset()
        {
            lock (this)
            {
                var items = this.Items;
                this.DateTime = DateTime.Now;
                Items = new List<CurrencyInfo>();
                return items;
            }
        }

        public DateTime DateTime { get; private set; }

        public List<CurrencyInfo> Items { get; private set; }

        public void Add(CurrencyInfo item)
        {

            if (Items.Count >= MAX_LENGTH)
            {
                Processor();
            }

            lock (this)
            {
                Items.Add(item);
                ServerInstrumentation.Current.Produce();
            }

        }

        public void Processor(bool async = false)
        {
            var items = this.Reset();
            if (async)
            {
                Processor(items);
            }
            else
            {
                /*
                var action = new Action(() => { Processor(items); ServerInstrumentation.Current.Queue(-1); });

                Task.Factory.StartNew(action);
                */

                var action = new Action(() => Processor(items));
                action.BeginInvoke((ar) =>
                {
                    action.EndInvoke(ar);
                    ServerInstrumentation.Current.Queue(-1);
                }, action);
            }
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
                    ElibExceptionHandler.Handle(ex);
                    ServerInstrumentation.Current.Fault(items.Count);
                    BackUp(items);
                    throw;
                }

                logger.Info(string.Format("Task({0}):\tCurrent:{1}\tAll:{2}\tcost:{3}ms",
                    index, items.Count, count, Environment.TickCount - n));
            }



            //if (MAX_TIMEOUT > 0)
            //{
            //    Thread.Sleep(MAX_TIMEOUT);
            //}
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
