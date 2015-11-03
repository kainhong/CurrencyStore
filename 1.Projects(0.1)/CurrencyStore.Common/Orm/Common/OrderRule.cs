using System.Collections.Generic;
using System.Text;

namespace CurrencyStore.Common.Orm.Common
{
    public class OrderRule
    {
        private List<string> Columns
        {
            get;
            set;
        }
        public OrderRule()
        {
            this.Columns = new List<string>();
        }
        public void AddColumn(string columnName, OrderDirection direction)
        {
            string temp = columnName + " " + direction.ToString().ToLower();

            if (!this.Columns.Contains(temp))
            {
                this.Columns.Add(temp);
            }
        }
        public string GetText()
        {
            StringBuilder result = new StringBuilder();

            if (this.Columns.Count > 0)
            {
                result.Append(" order by ");
            }

            for (int i = 0; i < this.Columns.Count; i++)
            {
                result.Append(this.Columns[i]);

                if (i != this.Columns.Count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }
    }
}
