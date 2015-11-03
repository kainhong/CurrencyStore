using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace CurrencyStore.Repository.MySql
{
    public class MySqlDbProvider : DbProvider
    {
        public MySqlDbProvider(DbConnection connection):base(connection)
        {

        }

        public override string Prefix
        {
            get { return "@"; }
        }
        public override string GeneratePagingScript(string script, bool count)
        {
            var c = string.Format("Select Count(*) From ({0}) As P2;", script);
            var p = string.Format("Select * From ({0}) As P1 Limit @s,@e;", script);
            if (count)
                return p + Environment.NewLine + c;
            else
                return p;
        }
        public override void BulkCopy<T>(IEnumerable<T> datasource)
        {
            throw new NotImplementedException();
        }
        public override string GeneratePagingCountScript(string script)
        {
            return string.Format("Select Count(*) From ({0}) As P2;", script);
        }
        protected override string GeneratePagingListScript(string script)
        {
            return string.Format("Select * From ({0}) As P1 Limit @s,@e;", script);
        }
    }
}
