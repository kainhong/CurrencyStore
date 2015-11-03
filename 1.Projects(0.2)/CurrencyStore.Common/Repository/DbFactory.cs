using CurrencyStore.Common.Repository.Common;
using CurrencyStore.Common.Repository.MySql;
using CurrencyStore.Common.Repository.Oracle;

namespace CurrencyStore.Common.Repository
{
    public class DbFactory
    {
        private static string DbType
        {
            get;
            set;
        }
        private static string ConnectionString
        {
            get;
            set;
        }
        static DbFactory()
        {
            DbFactory.DbType = "";
            DbFactory.ConnectionString = "";
        }
        public static DbHelper GetDbHelper()
        {
            DbHelper result = null;

            switch (DbFactory.DbType)
            {
                case "mysql":
                    result = new MySqlDbHelper(DbFactory.ConnectionString);
                    break;

                case "oracle":
                    result = new OracleDbHelper(DbFactory.ConnectionString);
                    break;
            }

            return result;
        }
    }
}
