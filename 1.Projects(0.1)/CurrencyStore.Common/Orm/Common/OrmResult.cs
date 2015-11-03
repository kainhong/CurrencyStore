using System.Collections.Generic;
using System.Data.Common;

namespace CurrencyStore.Common.Orm.Common
{
    public class OrmResult
    {
        public string SqlText
        {
            get;
            set;
        }
        public Dictionary<string, DbParameter> Parameters
        {
            get;
            set;
        }
        public int CurrentPageIndex
        {
            get;
            set;
        }
        public int PageSize
        {
            get;
            set;
        }
        public OrmResult()
        { }
        public OrmResult(string sqlText, Dictionary<string, DbParameter> parameters)
        {
            this.SqlText = sqlText;
            this.Parameters = parameters;
        }
        public OrmResult(string sqlText, Dictionary<string, DbParameter> parameters, int currentPageIndex, int pageSize)
        {
            this.SqlText = sqlText;
            this.Parameters = parameters;
            this.CurrentPageIndex = currentPageIndex;
            this.PageSize = pageSize;
        }
    }
}
