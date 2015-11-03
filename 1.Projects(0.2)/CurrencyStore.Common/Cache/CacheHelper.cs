using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.Cache
{
    public class CacheHelper
    {
        public static int Count
        {
            get { return HttpRuntime.Cache.Count; }
        }
        public static T Get<T>(string key)
        {
            T result = default(T);

            if (HttpRuntime.Cache[key] != null)
            {
                result = HttpRuntime.Cache[key].Convert<T>();
            }

            return result;
        }
        public static void Set(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }
        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
        public static void RemoveByKeyword(string keyword)
        {
            IDictionaryEnumerator objEnumerators = HttpRuntime.Cache.GetEnumerator();

            while (objEnumerators.MoveNext())
            {
                if (objEnumerators.Key.ToString().ToLower().Contains(keyword.ToLower()))
                {
                    HttpRuntime.Cache.Remove(objEnumerators.Key.ToString());
                }
            }
        }
        public static void RemoveAll()
        {
            IDictionaryEnumerator objEnumerators = HttpRuntime.Cache.GetEnumerator();

            while (objEnumerators.MoveNext())
            {
                HttpRuntime.Cache.Remove(objEnumerators.Key.ToString());
            }
        }
    }
}
