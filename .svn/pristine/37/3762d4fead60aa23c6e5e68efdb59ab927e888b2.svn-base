using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CurrencyStore.Common;
using CurrencyStore.Common.Configration;
using CurrencyStore.Entity;

namespace CurrencyStore.Communication
{
    public static class DataPool
    {
        //static ConcurrentQueue<CurrencyStore.Entity.CurrencyInfo> _queue;
        static readonly AutoResetEvent _resetEvent = new AutoResetEvent(false);
        static long _index = 0;
        static int MAX_TIMEOUT = 15000;
        static int MAX_LENGTH = 10;
        static Dictionary<int, StoreProcessor> _pool = new Dictionary<int, StoreProcessor>();
        static int capacity;
        static bool inited;
        static Thread taskThread;
        static bool stop;
        static DataPool()
        {
            //_queue = new ConcurrentQueue<Entity.CurrencyInfo>();
            MAX_TIMEOUT = Math.Max(CurrencyStoreSection.Instance.Task.Timeout, 2000);
            MAX_LENGTH = Math.Max(CurrencyStoreSection.Instance.Task.PoolSize, 10);
            capacity = Math.Max(CurrencyStoreSection.Instance.Task.Capacity, 5);
            taskThread = new Thread(new ThreadStart(TairProcess));
            taskThread.Start();
        }

        public static void Push(Entity.CurrencyInfo value)
        {
            Init();
            var index = Convert.ToInt32(Interlocked.Increment(ref _index) % capacity);
            var store = _pool[index];
            store.Add(value);
        }

        static void Init()
        {
            if (!inited)
            {
                lock (_pool)
                {
                    if (!inited)
                    {
                        for (int i = 0; i < capacity; i++)
                        {
                            var item = new StoreProcessor(i);
                            _pool.Add(i, item);
                        }
                        inited = true;
                    }
                }
            }
        }

        static void TairProcess()
        {
            while (!stop)
            {
                Thread.Sleep(MAX_TIMEOUT);

                for (int i = 0; i < capacity; i++)
                {
                    var store = _pool[i];
                    var items = store.Items;
                    if (items.Count > 0 && (DateTime.Now - store.DateTime).TotalMilliseconds >= MAX_TIMEOUT)
                    {
                        store.Processor(true);
                    }
                }
            }
        }

        public static void Stop()
        {
            stop = true;
            for (int i = 0; i < capacity; i++)
            {
                _pool[i].Processor();
            }
        }

        //    public static bool TryGet(out Entity.CurrencyInfo result)
        //    {
        //        return _queue.TryDequeue(out result);
        //    }

        //    public static IEnumerable<Entity.CurrencyInfo> GetDatas()
        //    {
        //        _resetEvent.WaitOne(MAX_TIMEOUT);
        //        Entity.CurrencyInfo item;
        //        while (TryGet(out item))
        //            yield return item;
        //    }
        //}
    }
}
