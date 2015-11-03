using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.Common;
namespace CurrencyStore.Repository.Oracle
{
    public class OrcaleDbProvider : DbProvider
    {
        public override string Prefix
        {
            get { return ":"; }
        }

        public OrcaleDbProvider(DbConnection connection)
            : base(connection)
        {
        }

        public override string GeneratePagingScript(string script, bool count)
        {
            string f = @"select * from ( select a.*, ROWNUM row_num from ( {0} ) a ) b where b.row_num between :s and :e";
            return string.Format(f, script);
        }

        public override void BulkCopy<T>(IEnumerable<T> datasource)
        {
            throw new NotImplementedException();
        }

        public override string GeneratePagingCountScript(string script)
        {
            const string f = "select count(*) from ( {0} )";
            return string.Format(f, script);
        }

        protected override string GeneratePagingListScript(string script)
        {
            string f = @"select * from ( select a.*,ROWNUM row_num From ( {0} ) a ) b where b.row_num between :s and :e";
            return string.Format(f, script);
        }
    }
}
