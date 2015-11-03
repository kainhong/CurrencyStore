using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace CurrencyStore.Business
{
    static class Unity
    {
        public static bool AddOrReplace(this MemcachedClient client, string key, object item)
        {
            var result = client.Store(StoreMode.Add, key, item);

            if (!result)
            {
                result = client.Store(StoreMode.Replace, key, item);
            }

            return result;
        }
    }
}
