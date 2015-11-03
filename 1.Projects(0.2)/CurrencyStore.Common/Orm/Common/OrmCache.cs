using System.Collections.Generic;

namespace CurrencyStore.Common.Orm.Common
{
    public class OrmCache
    {
        private static Dictionary<string, OrmModel> CacheList
        {
            get;
            set;
        }
        static OrmCache()
        {
            OrmCache.CacheList = new Dictionary<string, OrmModel>();
        }
        public static void Set(string key, OrmModel value)
        {
            if (!OrmCache.CacheList.ContainsKey(key))
            {
                OrmCache.CacheList.Add(key, value);
            }
        }
        public static OrmModel Get(string key)
        {
            OrmModel result = null;

            if (OrmCache.CacheList.ContainsKey(key))
            {
                result = OrmCache.CacheList[key];
            }

            return result;
        }
        public static void Remove(string key)
        {
            OrmCache.CacheList.Remove(key);
        }
        public static void RemoveAll()
        {
            OrmCache.CacheList.Clear();
        }
    }
}
