using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Dynamic;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public static class DbHelper
    {
        public const string CONNECTION_NAME = "CurrencyStore";

        public static DbConnection GetDbConnection(string name)
        {
            var section = System.Configuration.ConfigurationManager.ConnectionStrings;
            if (section == null || section.Count == 0)
                throw new ArgumentException("configruation information is empty");
            ConnectionStringSettings current = null;

            foreach (ConnectionStringSettings item in section)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    current = item;
                    break;
                }
            }

            if (current == null)
                throw new ArgumentOutOfRangeException("invalide connection string:" + name);

            //var factory = System.Data.Common.DbProviderFactories.GetFactory("MySql.Data.MySqlClient");//current.ProviderName);

            DbProviderFactory factory = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");


            var con = factory.CreateConnection();
            con.ConnectionString = current.ConnectionString;
            return con;
        }

        public static DbParameter CreateParameter(string name, object value)
        {
            var con = GetDbConnection(CONNECTION_NAME);
            var cmd = con.CreateCommand();
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }

        public static bool ExecuteNonQuery(string script, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params)
        {
            using (var con = GetDbConnection(CONNECTION_NAME))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = script;
                cmd.CommandType = cmdType;
                cmd.Connection = con;
                if (@params != null && @params.Count() > 0)
                {
                    foreach (var p in @params)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                con.Open();
#if DEBUG
                DateTime dt1 = DateTime.Now;
#endif
                var result = (cmd.ExecuteNonQuery() > 0);
#if DEBUG
                DateTime dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif
                con.Close();
                return result;
            }
        }

        public static object ExecuteScalar(string script, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params)
        {
            using (var con = GetDbConnection(CONNECTION_NAME))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = script;
                cmd.CommandType = cmdType;
                cmd.Connection = con;
                if (@params != null && @params.Count() > 0)
                {
                    foreach (var p in @params)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                con.Open();
#if DEBUG
                DateTime dt1 = DateTime.Now;
#endif
                var result = cmd.ExecuteScalar();
#if DEBUG
                DateTime dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif
                con.Close();
                return result;
            }
        }

        public static T ExecuteScalar<T>(string script, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params) where T : new()
        {
            return ExecuteScalar<T>(script, null, cmdType, @params);
        }

        public static T ExecuteScalar<T>(string script, Func<T, string, object, bool> predicate, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params) where T : new()
        {
            using (var con = GetDbConnection(CONNECTION_NAME))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = script;
                cmd.CommandType = cmdType;
                cmd.Connection = con;
                if (@params != null && @params.Count() > 0)
                {
                    foreach (var p in @params)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                con.Open();
#if DEBUG
                DateTime dt1 = DateTime.Now;
#endif
                var reader = cmd.ExecuteReader();
#if DEBUG
                DateTime dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif
                con.Close();
                return ExecuteList<T>(reader, predicate).FirstOrDefault();
            }
        }

        public static List<T> ExecuteList<T>(string script, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params) where T : new()
        {
            return ExecuteList<T>(script, null, cmdType, @params);
        }

        public static List<T> ExecuteList<T>(string script, Func<T, string, object, bool> predicate, CommandType cmdType = CommandType.Text,
            params DbParameter[] @params) where T : new()
        {
            using (var con = GetDbConnection(CONNECTION_NAME))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = script;
                cmd.CommandType = cmdType;
                cmd.Connection = con;
                if (@params != null && @params.Count() > 0)
                {
                    foreach (var p in @params)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                con.Open();
#if DEBUG
                DateTime dt1 = DateTime.Now;
#endif
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
#if DEBUG
                DateTime dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif
                return ExecuteList<T>(reader, predicate).ToList();
            }
        }

        public static List<T> ExecutePagingList<T>(string script, Pagination paging, params DbParameter[] @params) where T : new()
        {
            return ExecutePagingList<T>(script, paging, null, @params);
        }

        public static List<T> ExecutePagingList<T>(string script,
             Pagination paging, Func<T, string, object, bool> predicate, params DbParameter[] @params) where T : new()
        {

            using (var con = GetDbConnection(CONNECTION_NAME))
            {
                var cmd = con.CreateCommand();
                var provider = con.GetProvider();

                cmd.CommandText = provider.GeneratePagingCountScript(script);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                if (@params != null && @params.Count() > 0)
                {
                    foreach (var p in @params)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }

                con.Open();
#if DEBUG
                DateTime dt1 = DateTime.Now;
#endif
                paging.RowCount = Convert.ToInt32(cmd.ExecuteScalar().ToString());

#if DEBUG
                DateTime dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif

                cmd = provider.WrapPagingCommand(script, paging, @params);
#if DEBUG
                dt1 = DateTime.Now;
#endif
                var reader = cmd.ExecuteReader();
#if DEBUG
                dt2 = DateTime.Now;

                DbQueryDetailHelper.QueryDetail += DbQueryDetailHelper.GetQueryDetail(cmd.CommandText, dt1, dt2, cmd.Parameters);
#endif
                var result = ExecuteList<T>(reader, predicate).ToList();
                return result;
            }
        }

        public static DbProvider GetProvider(this DbConnection con)
        {
            if (con.GetType().Name == "OracleConnection")
                return new Oracle.OrcaleDbProvider(con);

            else
                return null;
        }

        private static IEnumerable<T> ExecuteList<T>(DbDataReader reader, Func<T, string, object, bool> predicate) where T : new()
        {
            while (reader.Read())
            {
                var item = new T();
                var proxy = new ObjectProxy(item);
                var properties = proxy.GetDynamicMemberNames().ToArray();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var field = reader.GetName(i);
                    var val = reader[i];
                    var p = properties.FirstOrDefault(c => string.Compare(c, field, true) == 0);
                    if (val != DBNull.Value && p != null)
                    {
                        if (predicate == null || !predicate(item, field, val))
                            item.SetValue(p, val);
                    }
                }
                yield return item;
            }
        }

        private static DbParameter[] CreateParameter(DbCommand cmd, KeyValuePair<string, object>[] @params)
        {
            if (@params == null || @params.Length == 0)
                return null;
            return @params.Select(c =>
            {
                var p = cmd.CreateParameter();
                p.ParameterName = c.Key;
                p.Value = c.Value;
                return p;
            }).ToArray();
        }

        public static DbParameter AddParameter(this DbCommand cmd, string name, object value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            cmd.Parameters.Add(p);
            return p;
        }
    }
}
