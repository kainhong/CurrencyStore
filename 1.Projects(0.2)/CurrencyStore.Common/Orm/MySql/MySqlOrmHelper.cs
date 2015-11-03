using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using CurrencyStore.Common.Orm.Common;
using CurrencyStore.Common.Repository;
using MySql.Data.MySqlClient;

namespace CurrencyStore.Common.Orm.MySql
{
    public class MySqlOrmHelper : OrmHelper
    {
        public MySqlOrmHelper()
        {
            this.DbCharacter = "?";
        }
        protected override OrmResult MappedCheckExists<T>(T objModel)
        {
            OrmResult result = null;

            if (objModel != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("select count(*) from `{Table}` where 1 = 1 {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder whereText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    if (column.Value.IsUnique)
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = column.Value.MappedPropertyInfo.GetValue(objModel, null);

                        parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                        parameter.Value = parameterValue;

                        parameters.Add(parameterName, parameter);

                        /**/

                        whereText.Append(" and " + column.Value.ColumName + " = " + parameterName);
                    }
                }

                sqlText.Replace("{Where}", whereText.ToString());

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedInsert<T>(T objModel)
        {
            OrmResult result = null;

            if (objModel != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("insert into `{Table}`({Column}) values({Value})");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder columnText = new StringBuilder();
                StringBuilder valueText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    if (!column.Value.IsAutoincrement && column.Value.IsInsert)
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = column.Value.MappedPropertyInfo.GetValue(objModel, null);

                        if (parameterValue != null || (!column.Value.IsNullable))
                        {
                            parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                            parameter.Value = parameterValue;

                            parameters.Add(parameterName, parameter);

                            /**/

                            columnText.Append(column.Value.ColumName + ", ");
                            valueText.Append(parameterName + ", ");
                        }
                    }
                }

                columnText.Remove(columnText.Length - 2, 2);
                valueText.Remove(valueText.Length - 2, 2);

                sqlText.Replace("{Column}", columnText.ToString());
                sqlText.Replace("{Value}", valueText.ToString());

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedUpdate<T>(T objModel)
        {
            OrmResult result = null;

            if (objModel != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("update `{Table}` set {Column} where 1 = 1 {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder columnText = new StringBuilder();
                StringBuilder whereText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    if (!column.Value.IsPrimaryKey && column.Value.IsUpdate && (!column.Value.IsUpdateIdentity))
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = column.Value.MappedPropertyInfo.GetValue(objModel, null);

                        parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                        parameter.Value = parameterValue;

                        parameters.Add(parameterName, parameter);

                        /**/

                        columnText.Append(column.Value.ColumName + " = " + parameterName + ", ");
                    }

                    if (column.Value.IsPrimaryKey || (column.Value.IsUpdateIdentity && parameterValue != null))
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = column.Value.MappedPropertyInfo.GetValue(objModel, null);

                        parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                        parameter.Value = parameterValue;

                        parameters.Add(parameterName, parameter);

                        /**/

                        whereText.Append(" and " + column.Value.ColumName + " = " + parameterName);
                    }
                }

                columnText.Remove(columnText.Length - 2, 2);

                sqlText.Replace("{Column}", columnText.ToString());
                sqlText.Replace("{Where}", whereText.ToString());

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedDelete<T>(object pkId)
        {
            OrmResult result = null;

            if (pkId != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("delete from `{Table}` where {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder whereText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    if (column.Value.IsPrimaryKey)
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = pkId;

                        parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                        parameter.Value = parameterValue;

                        parameters.Add(parameterName, parameter);

                        /**/

                        whereText.Append(column.Value.ColumName + " = " + parameterName);

                        break;
                    }
                }

                sqlText.Replace("{Where}", whereText.ToString());

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedObject<T>(object pkId)
        {
            OrmResult result = null;

            if (pkId != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("select {Column} from `{Table}` where {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder columnText = new StringBuilder();
                StringBuilder whereText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    columnText.Append(column.Value.ColumName + ", ");

                    if (column.Value.IsPrimaryKey)
                    {
                        parameterName = this.DbCharacter + column.Value.ColumName;
                        parameterValue = pkId;

                        parameter = new MySqlParameter(parameterName, column.Value.MySqlDataType);
                        parameter.Value = parameterValue;

                        parameters.Add(parameterName, parameter);

                        /**/

                        whereText.Append(column.Value.ColumName + " = " + parameterName);
                    }
                }

                columnText.Remove(columnText.Length - 2, 2);

                sqlText.Replace("{Column}", columnText.ToString());
                sqlText.Replace("{Where}", whereText.ToString());

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedObjectCount<T>(SearchCriterion objSearchCriterion)
        {
            OrmResult result = null;

            if (objSearchCriterion != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("select count(*) from `{Table}` where {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder whereText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                if (objSearchCriterion != null)
                {
                    if (objSearchCriterion.WhereRules.Count > 0)
                    {
                        foreach (WhereRule objWhereRule in objSearchCriterion.WhereRules)
                        {
                            if (objWhereRule.Values != null &&
                                (objWhereRule.Match != MatchType.IsNull ||
                                 objWhereRule.Match != MatchType.IsNotNull))
                            {
                                parameterName = this.DbCharacter + objWhereRule.ParameterName;
                                parameterValue = objWhereRule.Values[0];

                                parameter = new MySqlParameter(parameterName, parameterValue);

                                parameters.Add(parameterName, parameter);
                            }

                            whereText.Append(objWhereRule.GetText(this.DbCharacter));
                        }
                    }

                    sqlText.Append(objSearchCriterion.OrderRules.GetText());
                }

                if (objSearchCriterion.WhereRules.Count > 0)
                {
                    sqlText.Replace("{Where}", whereText.ToString());
                }

                else
                {
                    sqlText.Replace("{Where}", "1 = 1");
                }

                /**/

                result = new OrmResult(sqlText.ToString(), parameters);
            }

            return result;
        }
        protected override OrmResult MappedObjectList<T>(SearchCriterion objSearchCriterion)
        {
            OrmResult result = null;

            if (objSearchCriterion != null)
            {
                StringBuilder sqlText = new StringBuilder();
                Dictionary<string, DbParameter> parameters = new Dictionary<string, DbParameter>();

                OrmModel objMappedModel = this.GetMappedModel<T>();

                /**/

                sqlText.Append("select {Column} from `{Table}` where {Where}");

                sqlText.Replace("{Table}", objMappedModel.Table.TableName);

                /**/

                StringBuilder columnText = new StringBuilder();
                StringBuilder whereText = new StringBuilder();
                StringBuilder orderText = new StringBuilder();

                string parameterName = null;
                object parameterValue = null;
                MySqlParameter parameter = null;

                int currentPageIndex = 0;
                int pageSize = 0;

                foreach (KeyValuePair<string, OrmColumnAttribute> column in objMappedModel.Columns)
                {
                    columnText.Append(column.Value.ColumName + ", ");
                }

                columnText.Remove(columnText.Length - 2, 2);

                if (objSearchCriterion != null)
                {
                    currentPageIndex = objSearchCriterion.CurrentPageIndex;
                    pageSize = objSearchCriterion.PageSize;

                    /**/

                    if (objSearchCriterion.WhereRules.Count > 0)
                    {
                        foreach (WhereRule objWhereRule in objSearchCriterion.WhereRules)
                        {
                            if (objWhereRule.Values != null &&
                                (objWhereRule.Match != MatchType.IsNull ||
                                 objWhereRule.Match != MatchType.IsNotNull))
                            {
                                parameterName = this.DbCharacter + objWhereRule.ParameterName;
                                parameterValue = objWhereRule.Values[0];

                                parameter = new MySqlParameter(parameterName, parameterValue);

                                parameters.Add(parameterName, parameter);
                            }

                            whereText.Append(objWhereRule.GetText(this.DbCharacter));
                        }
                    }

                    sqlText.Append(objSearchCriterion.OrderRules.GetText());
                }

                sqlText.Replace("{Column}", columnText.ToString());

                if (objSearchCriterion.WhereRules.Count > 0)
                {
                    sqlText.Replace("{Where}", whereText.ToString());
                }

                else
                {
                    sqlText.Replace("{Where}", "1 = 1");
                }

                /**/

                result = new OrmResult(sqlText.ToString(), parameters, currentPageIndex, pageSize);
            }

            return result;
        }
        public override bool CheckExists<T>(T objModel, bool isInsert)
        {
            OrmResult temp = this.MappedCheckExists<T>(objModel);

            if (temp == null)
            {
                return false;
            }

            return DbFactory.GetDbHelper().Exec_Scalar<int>(temp.SqlText, temp.Parameters) > (isInsert ? 0 : 1);
        }
        public override bool Insert<T>(T objModel)
        {
            OrmResult temp = this.MappedInsert<T>(objModel);

            if (temp == null)
            {
                return false;
            }

            return DbFactory.GetDbHelper().Exec_NonQuery(temp.SqlText, temp.Parameters).Equals(1);
        }
        public override bool Update<T>(T objModel)
        {
            OrmResult temp = this.MappedUpdate<T>(objModel);

            if (temp == null)
            {
                return false;
            }

            return DbFactory.GetDbHelper().Exec_NonQuery(temp.SqlText, temp.Parameters).Equals(1);
        }
        public override bool Save<T>(T objModel, bool isInsert)
        {
            bool result = false;

            if (isInsert)
            {
                result = this.Insert<T>(objModel);
            }

            else
            {
                result = this.Update<T>(objModel);
            }

            return result;
        }
        public override bool Delete<T>(object pkId)
        {
            OrmResult temp = this.MappedDelete<T>(pkId);

            if (temp == null)
            {
                return false;
            }

            return DbFactory.GetDbHelper().Exec_NonQuery(temp.SqlText, temp.Parameters).Equals(1);
        }
        public override T GetObject<T>(object pkId)
        {
            OrmResult temp = this.MappedObject<T>(pkId);

            if (temp == null)
            {
                return null;
            }

            return DbFactory.GetDbHelper().Exec_Object<T>(temp.SqlText, temp.Parameters);
        }
        public override int GetObjectCount<T>(SearchCriterion objSearchCriterion)
        {
            OrmResult temp = this.MappedObjectCount<T>(objSearchCriterion);

            if (temp == null)
            {
                return 0;
            }

            return DbFactory.GetDbHelper().Exec_Scalar<int>(temp.SqlText, temp.Parameters);
        }
        public override List<T> GetObjectList<T>(SearchCriterion objSearchCriterion)
        {
            List<T> result = null;

            OrmResult temp = this.MappedObjectList<T>(objSearchCriterion);

            if (temp == null)
            {
                return new List<T>();
            }

            if (temp.CurrentPageIndex > 0 && temp.PageSize > 0)
            {
                result = DbFactory.GetDbHelper().Exec_ObjectList_Paging<T>
                (
                    temp.SqlText,
                    temp.Parameters,
                    temp.CurrentPageIndex,
                    temp.PageSize
                );
            }

            else
            {
                result = DbFactory.GetDbHelper().Exec_ObjectList<T>
                (
                    temp.SqlText,
                    temp.Parameters
                );
            }

            return result;
        }
    }
}
