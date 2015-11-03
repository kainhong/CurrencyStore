using System.Collections.Generic;
using System.Data.Common;

namespace CurrencyStore.Common.Repository.Common
{
    public abstract class DbParameterHelper
    {
        public Dictionary<string, DbParameter> Parameters
        {
            get;
            private set;
        }
        public DbParameterHelper()
        {
            this.Parameters = new Dictionary<string, DbParameter>();
        }
        public DbParameter this[string parameterName]
        {
            get { return this.Parameters[parameterName]; }
        }
        public abstract void Add(DbParameter objDbParameter);
        public abstract void SetValue(string parameterName, object parameterValue);
        public abstract object GetValue(string parameterName);
        public abstract T GetValue<T>(string parameterName);
    }
}
