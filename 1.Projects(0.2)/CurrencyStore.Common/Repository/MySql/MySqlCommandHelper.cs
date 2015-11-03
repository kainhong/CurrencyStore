using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CurrencyStore.Common.Repository.Common;
using MySql.Data.MySqlClient;

namespace CurrencyStore.Common.Repository.MySql
{
    public class MySqlCommandHelper : DbCommandHelper
    {
        protected override DbCommand GetDbCommand(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            DbCommand result = new MySqlCommand(commandText);

            result.CommandType = commandType;

            if (parameters != null && parameters.Count > 0)
            {
                foreach (DbParameter parameter in parameters.Values)
                {
                    result.Parameters.Add(parameter);
                }
            }

            return result;
        }
        public override void Add(string commandText, Dictionary<string, DbParameter> parameters)
        {
            this.Add(CommandType.Text, commandText, parameters);
        }
        public override void Add(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            DbCommand objSqlCommand = this.GetDbCommand(commandType, commandText, parameters);

            if (!this.Commands.Contains(objSqlCommand))
            {
                this.Commands.Add(objSqlCommand);
            }
        }
    }
}
