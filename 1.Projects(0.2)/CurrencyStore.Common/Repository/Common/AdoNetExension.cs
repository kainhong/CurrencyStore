using System;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.Repository.Common
{
    public static class AdoNetExension
    {
        public static T GetModel<T>(this DbDataReader target) where T : class, new()
        {
            string typeFullName = typeof(T).FullName;

            PropertyInfo[] propertyList = DbCache.Get<PropertyInfo[]>(typeFullName);

            if (propertyList == null)
            {
                propertyList = typeof(T).GetProperties();

                DbCache.Set(typeFullName, propertyList);
            }

            return target.GetModel<T>(propertyList);
        }
        public static T GetModel<T>(this DbDataReader target, PropertyInfo[] propertyIntoList) where T : class, new()
        {
            T result = new T();

            foreach (PropertyInfo objPropertyInfo in propertyIntoList)
            {
                if (!IsNullOrDBNull(target[objPropertyInfo.Name]))
                {
                    if (objPropertyInfo.CanWrite)
                    {
                        objPropertyInfo.SetValue
                        (
                            result,
                            HackNullableType(target[objPropertyInfo.Name], objPropertyInfo.PropertyType),
                            null
                        );
                    }
                }
            }

            return result;
        }
        private static bool IsNullOrDBNull(object value)
        {
            //return ((value == null) || (value is DBNull) || value.ToString().IsNullOrEmpty());

            return ((value == null) || (value is DBNull));
        }
        private static object HackNullableType(object value, Type type)
        {
            object result = null;

            if (value != null)
            {
                Type temp = type;

                if (type.IsNullableType())
                {
                    temp = new NullableConverter(type).UnderlyingType;
                }

                result = Convert.ChangeType(value, temp);
            }

            return result;
        }
    }
}
