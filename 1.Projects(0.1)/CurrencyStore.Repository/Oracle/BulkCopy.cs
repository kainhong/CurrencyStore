using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace CurrencyStore.Repository.Oracle
{
    public class BulkCopy
    {
        void CopyTo(DbConnection con)
        {
            using (OracleBulkCopy obc = new OracleBulkCopy(con as OracleConnection))
            {

            }
        }
    }
}
