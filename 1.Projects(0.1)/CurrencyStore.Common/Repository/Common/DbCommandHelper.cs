using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CurrencyStore.Common.Repository.Common
{
    public abstract class DbCommandHelper
    {
        public List<DbCommand> Commands
        {
            get;
            private set;
        }
        public DbCommandHelper()
        {
            this.Commands = new List<DbCommand>();
        }
        protected abstract DbCommand GetDbCommand(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract void Add(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract void Add(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
    }
}
