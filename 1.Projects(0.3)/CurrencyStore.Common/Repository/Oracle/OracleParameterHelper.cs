using System;
using System.Data.Common;
using CurrencyStore.Common.Repository.Common;

namespace CurrencyStore.Common.Repository.Oracle
{
    public class OracleParameterHelper : DbParameterHelper
    {
        public override void Add(DbParameter objDbParameter)
        {
            if (objDbParameter != null && !this.Parameters.ContainsKey(objDbParameter.ParameterName))
            {
                this.Parameters.Add(objDbParameter.ParameterName, objDbParameter);
            }
        }
        public override void SetValue(string parameterName, object parameterValue)
        {
            if (this.Parameters.ContainsKey(parameterName))
            {
                this.Parameters[parameterName].Value = parameterValue;
            }
        }
        public override object GetValue(string parameterName)
        {
            return this.Parameters[parameterName].Value;
        }
        public override T GetValue<T>(string parameterName)
        {
            T result = default(T);

            if (this.Parameters.ContainsKey(parameterName))
            {
                result = (T)this.Parameters[parameterName].Value;
            }

            return result;
        }
    }
}
