using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.Repository.Common;
using MySql.Data.MySqlClient;

namespace CurrencyStore.Common.Repository.MySql
{
    public class MySqlDbHelper : DbHelper
    {
        public MySqlDbHelper(string connectionString)
            : base(connectionString)
        {
        }
        protected override DbConnection GetConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
        protected override DbCommand InitDbCommand(DbCommand objDbCommand, Dictionary<string, DbParameter> parameters)
        {
            objDbCommand.CommandTimeout = 60;

            /**/

            objDbCommand.Parameters.Clear();

            if (parameters != null && parameters.Count > 0)
            {
                foreach (DbParameter parameter in parameters.Values)
                {
                    objDbCommand.Parameters.Add(parameter);
                }
            }

            /**/

            return objDbCommand;
        }
        public override int Exec_NonQuery(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_NonQuery(CommandType.Text, commandText, parameters);
        }
        public override int Exec_NonQuery(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            int result = 0;

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, objDbConnection as MySqlConnection), parameters))
                    {
                        objDbCommand.CommandType = commandType;

                        objDbConnection.Open();

                        result = objDbCommand.ExecuteNonQuery();

                        objDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        public override bool Exec_NonQuery(List<DbCommand> commands)
        {
            bool result = false;

            using (DbConnection objDbConnection = this.GetConnection())
            {
                objDbConnection.Open();

                using (DbTransaction objDbTransaction = objDbConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (DbCommand objDbCommand in commands)
                        {
                            objDbCommand.Connection = objDbConnection;
                            objDbCommand.Transaction = objDbTransaction;

                            objDbCommand.ExecuteNonQuery();
                        }

                        objDbTransaction.Commit();

                        result = true;
                    }

                    catch
                    {
                        objDbTransaction.Rollback();

                        throw;
                    }

                    finally
                    {
                        if (objDbConnection.State != ConnectionState.Closed)
                        {
                            objDbConnection.Close();
                            objDbConnection.Dispose();
                        }
                    }
                }
            }

            return result;
        }
        public override object Exec_Scalar(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_Scalar(CommandType.Text, commandText, parameters);
        }
        public override object Exec_Scalar(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            object result = null;

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, objDbConnection as MySqlConnection), parameters))
                    {
                        objDbCommand.CommandType = commandType;

                        objDbConnection.Open();

                        result = objDbCommand.ExecuteScalar();

                        objDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        public override T Exec_Scalar<T>(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_Scalar<T>(CommandType.Text, commandText, parameters);
        }
        public override T Exec_Scalar<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            T result = default(T);

            object temp = null;

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, objDbConnection as MySqlConnection), parameters))
                    {
                        objDbCommand.CommandType = commandType;

                        objDbConnection.Open();

                        temp = objDbCommand.ExecuteScalar();

                        objDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }

                if (temp != null &&
                    (temp != DBNull.Value ||
                     typeof(T).IsAssignableFrom(typeof(DBNull))))
                {
                    switch (typeof(T).FullName)
                    {
                        case "System.Int32":
                            result = (T)(object)int.Parse(temp.ToString());
                            break;

                        case "System.Int64":
                            result = (T)(object)long.Parse(temp.ToString());
                            break;

                        case "System.String":
                            result = (T)(object)temp.ToString();
                            break;

                        default:
                            result = (T)temp;
                            break;
                    }
                }
            }

            return result;
        }
        public override DbDataReader Exec_DataReader(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_DataReader(CommandType.Text, commandText, parameters);
        }
        public override DbDataReader Exec_DataReader(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            DbDataReader result = null;

            try
            {
                using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, this.GetConnection() as MySqlConnection), parameters))
                {
                    objDbCommand.CommandType = commandType;

                    objDbCommand.Connection.Open();

                    result = objDbCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    objDbCommand.Parameters.Clear();
                }
            }

            finally
            {

            }

            return result;
        }
        public override DataTable Exec_DataTable(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_DataTable(CommandType.Text, commandText, parameters);
        }
        public override DataTable Exec_DataTable(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            DataTable result = new DataTable();

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, objDbConnection as MySqlConnection), parameters))
                    {
                        objDbCommand.CommandType = commandType;

                        using (DbDataAdapter objDbDataAdapter = new MySqlDataAdapter(objDbCommand as MySqlCommand))
                        {
                            objDbDataAdapter.Fill(result);

                            objDbCommand.Parameters.Clear();
                        }
                    }
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        public override DataTable Exec_DataTable_Paging(string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize)
        {
            return this.Exec_DataTable_Paging(CommandType.Text, commandText, parameters, currentPageIndex, pageSize);
        }
        public override DataTable Exec_DataTable_Paging(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize)
        {
            DataTable result = new DataTable();

            using (DbDataReader reader = this.Exec_DataReader(commandType, commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Columns.Add(new DataColumn(reader.GetName(i), reader.GetFieldType(i)));

                            //result.Columns.Add(new DataColumn(reader.GetName(i), typeof(string)));
                        }

                        int rowIndex = 0;
                        int start = pageSize * (currentPageIndex - 1);
                        int end = pageSize * currentPageIndex;

                        object[] currentRow = new object[reader.FieldCount];

                        while (reader.Read())
                        {
                            if (rowIndex >= start && rowIndex < end)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    currentRow[i] = reader.GetValue(i);
                                }

                                result.Rows.Add(currentRow);
                            }

                            else if (rowIndex > end)
                            {
                                break;
                            }

                            rowIndex++;
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        public override DataSet Exec_DataSet(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_DataSet(CommandType.Text, commandText, parameters);
        }
        public override DataSet Exec_DataSet(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            DataSet result = new DataSet();

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    using (DbCommand objDbCommand = this.InitDbCommand(new MySqlCommand(commandText, objDbConnection as MySqlConnection), parameters))
                    {
                        objDbCommand.CommandType = commandType;

                        using (DbDataAdapter objDbDataAdapter = new MySqlDataAdapter(objDbCommand as MySqlCommand))
                        {
                            objDbDataAdapter.Fill(result);

                            objDbCommand.Parameters.Clear();
                        }
                    }
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        public override T Exec_Object<T>(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_Object<T>(CommandType.Text, commandText, parameters);
        }
        public override T Exec_Object<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            T result = null;

            using (DbDataReader reader = this.Exec_DataReader(commandType, commandText, parameters))
            {
                try
                {
                    if (reader.HasRows && reader.Read())
                    {
                        result = reader.GetModel<T>();
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        public override List<T> Exec_ObjectList<T>(string commandText, Dictionary<string, DbParameter> parameters)
        {
            return this.Exec_ObjectList<T>(CommandType.Text, commandText, parameters);
        }
        public override List<T> Exec_ObjectList<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters)
        {
            List<T> result = new List<T>();

            using (DbDataReader reader = this.Exec_DataReader(commandType, commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        T objT = null;

                        while (reader.Read())
                        {
                            objT = reader.GetModel<T>();

                            result.Add(objT);
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        public override List<T> Exec_ObjectList_Paging<T>(string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize)
        {
            return this.Exec_ObjectList_Paging<T>(CommandType.Text, commandText, parameters, currentPageIndex, pageSize);
        }
        public override List<T> Exec_ObjectList_Paging<T>(CommandType commandType, string commandText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize)
        {
            List<T> result = new List<T>();

            using (DbDataReader reader = this.Exec_DataReader(commandType, commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        T objT = null;

                        int rowIndex = 0;
                        int start = pageSize * (currentPageIndex - 1);
                        int end = pageSize * currentPageIndex;

                        while (reader.Read())
                        {
                            if (rowIndex >= start && rowIndex < end)
                            {
                                objT = reader.GetModel<T>();

                                result.Add(objT);
                            }

                            else if (rowIndex > end)
                            {
                                break;
                            }

                            rowIndex++;
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        public override bool TestConnection()
        {
            bool result = false;

            using (DbConnection objDbConnection = this.GetConnection())
            {
                try
                {
                    objDbConnection.Open();

                    result = true;
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        public override bool BatchSubmitData(string tableName, string columnName, string dataFilePath)
        {
            bool result = false;

            using (MySqlConnection objDbConnection = this.GetConnection() as MySqlConnection)
            {
                try
                {
                    MySqlBulkLoader objMySqlBulkLoader = new MySqlBulkLoader(objDbConnection);

                    objMySqlBulkLoader.TableName = tableName;
                    objMySqlBulkLoader.Timeout = 60;
                    objMySqlBulkLoader.LineTerminator = ",";
                    objMySqlBulkLoader.FileName = dataFilePath;
                    objMySqlBulkLoader.NumberOfLinesToSkip = 0;

                    foreach (string column in columnName.Split(','))
                    {
                        objMySqlBulkLoader.Columns.Add(column);
                    }

                    objDbConnection.Open();

                    objMySqlBulkLoader.Load();

                    result = true;
                }

                finally
                {
                    if (objDbConnection.State != ConnectionState.Closed)
                    {
                        objDbConnection.Close();
                        objDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
    }
}
