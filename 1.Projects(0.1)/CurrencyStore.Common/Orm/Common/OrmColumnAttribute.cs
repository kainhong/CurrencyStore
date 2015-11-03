using System;
using System.Reflection;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace CurrencyStore.Common.Orm.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class OrmColumnAttribute : Attribute
    {
        public string ColumName
        {
            get;
            set;
        }
        public MySqlDbType MySqlDataType
        {
            get;
            set;
        }
        public OracleDbType OracleDataType
        {
            get;
            set;
        }
        public bool IsPrimaryKey
        {
            get;
            set;
        }
        public bool IsAutoincrement
        {
            get;
            set;
        }
        public bool IsUpdateIdentity
        {
            get;
            set;
        }
        public bool IsUnique
        {
            get;
            set;
        }
        public bool IsNullable
        {
            get;
            set;
        }
        public bool IsInsert
        {
            get;
            set;
        }
        public bool IsUpdate
        {
            get;
            set;
        }
        public PropertyInfo MappedPropertyInfo
        {
            get;
            set;
        }
    }
}
