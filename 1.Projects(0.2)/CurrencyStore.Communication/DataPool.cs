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
    static class DataPool
    {
        //static ConcurrentQueue<CurrencyStore.Entity.CurrencyInfo> _queue;
        static long _index = 0;
        static int MAX_TIMEOUT = 15000;
        static int MAX_LENGTH = 10;
        static Stack<StoreProcessor> _pool = new Stack<StoreProcessor>();
        static int capacity;
        static bool inited;
        static bool stop;

        static DataPool()
        {
            //_queue = new ConcurrentQueue<Entity.CurrencyInfo>();
            MAX_TIMEOUT = Math.Max(CurrencyStoreSection.Instance.Task.Timeout, 2000);
            MAX_LENGTH = Math.Max(CurrencyStoreSection.Instance.Task.PoolSize, 10);
            capacity = Convert.ToInt32(CurrencyStoreSection.Instance.Server.Backlog * 1.2); 
            //Math.Max(CurrencyStoreSection.Instance.Task.Capacity, 5);
            Init();
        }

        //public static void Push(Entity.CurrencyInfo value)
        //{
        //    Init();
        //    var index = Convert.ToInt32(Interlocked.Increment(ref _index) % capacity);
        //    var store = _pool[index];
        //    store.Add(value);
        //}

        static void Init()
        {
            for (int i = 0; i < capacity; i++)
            {
                var item = new StoreProcessor(i);
                _pool.Push(item);
            }
        }

        public static void Push(StoreProcessor item)
        {
            //lock (_pool)
            //{
                item.Update(true);
                _pool.Push(item);
            //}
        }

        public static StoreProcessor Pop()
        {
            //lock (_pool)
                return _pool.Pop();
        }

        //static void TairProcess()
        //{
        //    while (!stop)
        //    {
        //        Thread.Sleep(MAX_TIMEOUT);

        //        for (int i = 0; i < capacity; i++)
        //        {
        //            var store = _pool[i];
        //            var items = store.Items;
        //            if (items.Count > 0 && (DateTime.Now - store.DateTime).TotalMilliseconds >= MAX_TIMEOUT)
        //            {
        //                store.Processor(true);
        //            }
        //        }
        //    }
        //}

        public static void Stop()
        {
            stop = true;
            lock (_pool)
            {
                foreach (var item in _pool)
                {
                    item.Update(true);
                }
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
