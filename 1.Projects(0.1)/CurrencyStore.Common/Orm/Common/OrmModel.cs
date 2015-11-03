using System.Collections.Generic;

namespace CurrencyStore.Common.Orm.Common
{
    public class OrmModel
    {
        public OrmTableAttribute Table
        {
            get;
            set;
        }
        public Dictionary<string, OrmColumnAttribute> Columns
        {
            get;
            set;
        }
    }
}
