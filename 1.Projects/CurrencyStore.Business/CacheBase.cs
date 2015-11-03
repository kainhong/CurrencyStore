using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace CurrencyStore.Business
{
    public abstract class CacheBase<T>
    {
        private MemcachedClient _client = new MemcachedClient();
        protected abstract string Prefix { get; }
        protected CacheBase()
        {
        }
        public virtual void Init()
        {
            var state = _client.Get<int>(Prefix + "g");

            if (state == 0)
            {
                ///TODO:
                //var items = LoadItems();

                //foreach (var item in items)
                //{
                //    var key = Prefix + GetItemKey(item);
                //    var result = _client.AddOrReplace(key, item);

                //    if (!result)
                //    {
                //        throw new InvalidOperationException("memecached store failed");
                //    }
                //}

                //_client.Store(StoreMode.Add, Prefix + "g", 1);
            }
        }
        protected abstract IEnumerable<T> LoadItems();
        protected abstract string GetItemKey(T item);
        public virtual T Get(string key)
        {
            return _client.Get<T>(Prefix + key);
        }
        public virtual void Set(T item)
        {
            string key = Prefix + GetItemKey(item);

            _client.AddOrReplace(key, item);
        }
        public virtual void Remove(string key)
        {
            _client.Remove(Prefix + key);
        }
    }
}
