using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class TypeExtension
    {
        public static bool IsNullableType(this Type target)
        {
            return ((target != null) && target.IsGenericType) && (target.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }
    }
}
