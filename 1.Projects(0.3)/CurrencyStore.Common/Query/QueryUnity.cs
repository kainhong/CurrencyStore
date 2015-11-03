using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.Query
{
    public static class QueryUnity
    {
        public static QueryParameter Add(this List<QueryParameter> ps, string name, object value)
        {
            var p = new QueryParameter() { Name = name, Value = value };
            ps.Add(p);
            return p;
        }
    }
}
