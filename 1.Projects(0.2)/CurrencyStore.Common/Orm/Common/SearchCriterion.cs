using System.Collections.Generic;

namespace CurrencyStore.Common.Orm.Common
{
    public class SearchCriterion
    { 
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
        public List<WhereRule> WhereRules
        {
            get;
            set;
        }
        public OrderRule OrderRules
        {
            get;
            set;
        }
        public SearchCriterion()
        {
            this.CurrentPageIndex = 0;
            this.PageSize = 0;
            this.WhereRules = new List<WhereRule>();
            this.OrderRules = new OrderRule();
        }
        public SearchCriterion(int currentPageIndex, int pageSize)
        {
            this.CurrentPageIndex = currentPageIndex;
            this.PageSize = pageSize;
            this.WhereRules = new List<WhereRule>();
            this.OrderRules = new OrderRule();
        }
        public void AddWhereRule(WherePriority priority, MatchType match, string text)
        {
            this.WhereRules.Add(new WhereRule(priority, match, text));
        }
        public void AddWhereRule(WherePriority priority, string columnName, MatchType match, object[] values)
        {
            this.WhereRules.Add(new WhereRule(priority, columnName, match, values));
        }
        public void AddWhereRule(WherePriority priority, string columnName, string parameterName, MatchType match, object[] values)
        {
            this.WhereRules.Add(new WhereRule(priority, columnName, parameterName, match, values));
        }
        public void AddOrderRule(string columnName, OrderDirection direction)
        {
            this.OrderRules.AddColumn(columnName, direction);
        }
    }
}
