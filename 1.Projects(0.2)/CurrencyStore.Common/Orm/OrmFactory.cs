using CurrencyStore.Common.Orm.Common;
using CurrencyStore.Common.Orm.MySql;
using CurrencyStore.Common.Orm.Oracle;

namespace CurrencyStore.Common.Orm
{
    public class OrmFactory
    {
        private static string DbType
        {
            get;
            set;
        }
        static OrmFactory()
        {
            OrmFactory.DbType = "";
        }
        public static OrmHelper GetOrmHelper()
        {
            OrmHelper result = null;

            switch (OrmFactory.DbType)
            {
                case "mysql":
                    result = new MySqlOrmHelper();
                    break;

                case "oracle":
                    result = new OracleOrmHelper();
                    break;
            }

            return result;
        }
    }
}
