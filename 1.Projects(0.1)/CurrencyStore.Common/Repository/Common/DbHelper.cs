using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.Repository.Common
{
    public abstract class DbHelper
    {
        public string ConnectionString
        {
            get;
            set;
        }
        public DbHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        protected abstract DbConnection GetConnection();
        protected abstract DbCommand InitDbCommand(DbCommand objDbCommand, Dictionary<string, DbParameter> parameters);
        protected string GetParameterText(Dictionary<string, DbParameter> parameters)
        {
            StringBuilder result = new StringBuilder();

            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, DbParameter> objKVP in parameters)
                {
                    result.Append("{0}={1}".FormatWith(objKVP.Value.ParameterName, objKVP.Value.Value));
                    result.Append(StringExtension.NewLine1);
                }
            }

            return result.ToString();
        }
        public abstract int Exec_NonQuery(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract int Exec_NonQuery(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract bool Exec_NonQuery(List<DbCommand> commands);
        public abstract object Exec_Scalar(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract object Exec_Scalar(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract T Exec_Scalar<T>(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract T Exec_Scalar<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DbDataReader Exec_DataReader(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DbDataReader Exec_DataReader(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DataTable Exec_DataTable(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DataTable Exec_DataTable(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DataTable Exec_DataTable_Paging(string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize);
        public abstract DataTable Exec_DataTable_Paging(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize);
        public abstract DataSet Exec_DataSet(string commandText, Dictionary<string, DbParameter> parameters);
        public abstract DataSet Exec_DataSet(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters);
        public abstract T Exec_Object<T>(string commandText, Dictionary<string, DbParameter> parameters) where T : class, new();
        public abstract T Exec_Object<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters) where T : class, new();
        public abstract List<T> Exec_ObjectList<T>(string commandText, Dictionary<string, DbParameter> parameters) where T : class, new();
        public abstract List<T> Exec_ObjectList<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters) where T : class, new();
        public abstract List<T> Exec_ObjectList_Paging<T>(string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize) where T : class, new();
        public abstract List<T> Exec_ObjectList_Paging<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize) where T : class, new();
        public abstract bool TestConnection();
        public abstract bool BatchSubmitData(string tableName, string columnName, string dataFilePath);
    }
}
