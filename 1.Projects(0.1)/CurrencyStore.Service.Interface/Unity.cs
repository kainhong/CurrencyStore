using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;

namespace CurrencyStore.Services.Interface
{
    static class Unity
    {
        public static void Store(this MemcachedClient client, string key, object item)
        {
            var result = client.Store(Enyim.Caching.Memcached.StoreMode.Add, key, item);
         
            if (!result)
            {
                client.Store(Enyim.Caching.Memcached.StoreMode.Replace, key, item);
            }
        }
    }
}
