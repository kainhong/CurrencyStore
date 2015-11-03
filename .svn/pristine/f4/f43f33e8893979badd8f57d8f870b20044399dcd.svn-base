using System;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.Orm.Common
{
    public class WhereRule
    {
        public WherePriority Priority
        {
            get;
            set;
        }
        public string ColumnName
        {
            get;
            set;
        }
        public string ParameterName
        {
            get;
            set;
        }
        public MatchType Match
        {
            get;
            set;
        }
        public object[] Values
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public WhereRule(WherePriority priority, string columnName, MatchType match, object[] values)
        {
            this.Priority = priority;
            this.ColumnName = columnName;
            this.ParameterName = columnName;
            this.Match = match;

            if (values != null && values.Length > 0 &&
                (this.Match == MatchType.Like || this.Match == MatchType.NotLike))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].ToString().Escape(new String[] { @"\", @"%", @"_" });
                }
            }

            this.Values = values;
        }
        public WhereRule(WherePriority priority, string columnName, string parameterName, MatchType match, object[] values)
        {
            this.Priority = priority;
            this.ColumnName = columnName;
            this.ParameterName = parameterName;
            this.Match = match;

            if (values != null && values.Length > 0 &&
                (this.Match == MatchType.Like || this.Match == MatchType.NotLike))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].ToString().Escape(new String[] { @"\", @"%", @"_" });
                }
            }

            this.Values = values;
        }
        public WhereRule(WherePriority priority, MatchType match, string text)
        {
            this.Priority = priority;
            this.Match = match;
            this.Text = text;
        }
        private string GetPriorityText()
        {
            string result = null;

            switch (this.Priority)
            {
                case WherePriority.None:
                    result = "";
                    break;

                case WherePriority.Not:
                    result = " not";
                    break;

                case WherePriority.And:
                    result = " and";
                    break;

                case WherePriority.Or:
                    result = " or";
                    break;
            }

            return result;
        }
        public string GetText(string dbCharacter)
        {
            string result = null;

            switch (this.Match)
            {
                case MatchType.Equal:
                    result = "{0} {1} = {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.NotEqual:
                    result = "{0} {1} != {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.AlwaysEqual:
                    result = "{0} {1}".FormatWith(this.GetPriorityText(), this.Text);
                    break;

                /*
                case MatchType.In:
                    result = "{0} {1} in {2}";
                    break;

                case MatchType.NotIn:
                    result = "{0} {1} not in {2}";
                    break;

                case MatchType.Between:
                    result = "{0} between {1} and {2}";
                    break;
                 */

                case MatchType.Like:
                    result = "{0} {1} like concat(\'%\', {2}, \'%\')".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.NotLike:
                    result = "{0} {1} not like concat(\'%\', {2}, \'%\')".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.BigThan:
                    result = "{0} {1} > {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.LessThan:
                    result = "{0} {1} < {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.BigEqualThan:
                    result = "{0} {1} >= {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.LessEqualThan:
                    result = "{0} {1} <= {2}".FormatWith(this.GetPriorityText(), this.ColumnName, dbCharacter + this.ParameterName);
                    break;

                case MatchType.IsNull:
                    result = "{0} {1} is null".FormatWith(this.GetPriorityText(), this.ColumnName);
                    break;

                case MatchType.IsNotNull:
                    result = "{0} {1} is not null".FormatWith(this.GetPriorityText(), this.ColumnName);
                    break;
            }

            return result;
        }
    }
}
