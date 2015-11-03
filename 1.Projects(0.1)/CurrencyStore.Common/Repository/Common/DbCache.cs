using System.Collections.Generic;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.Repository.Common
{
    public class DbCache
    {
        private static Dictionary<string, object> CacheList
        {
            get;
            set;
        }
        static DbCache()
        {
            DbCache.CacheList = new Dictionary<string, object>();
        }
        public static void Set(string key, object value)
        {
            if (!DbCache.CacheList.ContainsKey(key))
            {
                DbCache.CacheList.Add(key, value);
            }

            else
            {
                DbCache.CacheList[key] = value;
            }
        }
        public static object Get(string key)
        {
            object result = null;

            if (DbCache.CacheList.ContainsKey(key))
            {
                result = DbCache.CacheList[key];
            }

            return result;
        }
        public static T Get<T>(string key)
        {
            T result = default(T);

            object temp = DbCache.Get(key);

            if (temp != null)
            {
                result = temp.Convert<T>();
            }

            return result;
        }
        public static void Remove(string key)
        {
            DbCache.CacheList.Remove(key);
        }
        public static void RemoveAll()
        {
            DbCache.CacheList.Clear();
        }
    }
}
