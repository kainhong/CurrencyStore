using CurrencyStore.Common.Orm;
using CurrencyStore.Common.Orm.Common;
using CurrencyStore.Common.Repository;
using CurrencyStore.Common.Repository.Common;

namespace CurrencyStore.Common
{
    public class DbAccessHelper
    {
        public static DbHelper CurrentDbHelper
        {
            get
            {
                return DbFactory.GetDbHelper();
            }
        }
        public static OrmHelper CurrentOrmHelper
        {
            get
            {
                return OrmFactory.GetOrmHelper();
            }
        }
    }
}
