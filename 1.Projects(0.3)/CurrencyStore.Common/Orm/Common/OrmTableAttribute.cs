using System;

namespace CurrencyStore.Common.Orm.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OrmTableAttribute : Attribute
    {
        public string TableName
        {
            get;
            set;
        }
    }
}
