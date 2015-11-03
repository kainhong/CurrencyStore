using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using CurrencyStore.Common.Query;

namespace CurrencyStore.Repository
{
    public abstract class DbProvider
    {
        protected DbConnection Connection { get; private set; }

        public DbProvider(DbConnection connection)
        {
            this.Connection = connection;
        }

        public abstract string Prefix { get; }

        public abstract void BulkCopy<T>(IEnumerable<T> datasource);

        public abstract string GeneratePagingCountScript(string script);

        public virtual DbCommand WrapPagingCommand(string script, Pagination paging, DbParameter[] @params)
        {
            var cmd = Connection.CreateCommand();
            cmd.CommandText = GeneratePagingListScript(script);
            if (@params != null)
                cmd.Parameters.AddRange(@params);
            cmd.AddParameter(Prefix + "s", (paging.PageSize * (paging.CurrentPageIndex - 1)) + (paging.CurrentPageIndex > 1 ? 1 : 0));
            cmd.AddParameter(Prefix + "e", paging.PageSize * paging.CurrentPageIndex);
            cmd.Connection = Connection;
            return cmd;
        }

        protected abstract string GeneratePagingListScript(string script);

        public abstract string GeneratePagingScript(string script, bool count);
    }
}
