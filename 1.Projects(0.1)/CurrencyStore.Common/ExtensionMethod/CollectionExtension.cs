using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class CollectionExtension
    {
        public static bool IsIn<T>(this T target, IEnumerable<T> c)
        {
            bool result = false;

            if (c != null)
            {
                result = c.Any(i => i.Equals(target));
            }

            return result;
        }
        public static bool AnyIn<T>(this IEnumerable<T> target, IEnumerable<T> c)
        {
            bool result = false;

            foreach (T item in target)
            {
                if (c.Contains(item))
                {
                    result = true;

                    break;
                }
            }

            return result;
        }
        public static void ForEach<T>(this IEnumerable<T> target, Action<T> a)
        {
            foreach (T e in target)
            {
                a(e);
            }
        }
        public static void ForEach<T>(this IEnumerable<T> target, Action<T, int> a)
        {
            int i = 0;

            foreach (T e in target)
            {
                a(e, i++);
            }
        }
    }
}
