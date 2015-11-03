using System;
using System.Collections.Generic;
using System.Reflection;

namespace CurrencyStore.Common.Orm.Common
{
    public abstract class OrmHelper
    {
        protected string DbCharacter
        {
            get;
            set;
        }
        protected OrmModel GetMappedModel<T>() where T : class, new()
        {
            OrmModel result = null;

            {
                Type entityType = typeof(T);
                string key = entityType.FullName;

                /**/

                result = OrmCache.Get(key);

                if (result == null)
                {
                    result = new OrmModel();

                    result.Table = Attribute.GetCustomAttribute
                    (
                        entityType,
                        typeof(OrmTableAttribute)
                    ) as OrmTableAttribute;

                    /**/

                    result.Columns = new Dictionary<string, OrmColumnAttribute>();

                    foreach (PropertyInfo objPropertyInfo in entityType.GetProperties())
                    {
                        OrmColumnAttribute temp = objPropertyInfo.GetCustomAttributes
                        (
                            typeof(OrmColumnAttribute),
                            false
                        )[0] as OrmColumnAttribute;

                        temp.MappedPropertyInfo = objPropertyInfo;

                        /**/

                        result.Columns.Add(temp.ColumName, temp);
                    }

                    /**/

                    OrmCache.Set(key, result);
                }

                return result;
            }
        }
        protected abstract OrmResult MappedCheckExists<T>(T objModel) where T : class, new();
        protected abstract OrmResult MappedInsert<T>(T objModel) where T : class, new();
        protected abstract OrmResult MappedUpdate<T>(T objModel) where T : class, new();
        protected abstract OrmResult MappedDelete<T>(object pkId) where T : class, new();
        protected abstract OrmResult MappedObject<T>(object pkId) where T : class, new();
        protected abstract OrmResult MappedObjectCount<T>(SearchCriterion objSearchCriterion) where T : class, new();
        protected abstract OrmResult MappedObjectList<T>(SearchCriterion objSearchCriterion) where T : class, new();
        public abstract bool CheckExists<T>(T objModel, bool isInsert) where T : class, new();
        public abstract bool Insert<T>(T objModel) where T : class, new();
        public abstract bool Update<T>(T objModel) where T : class, new();
        public abstract bool Save<T>(T objModel, bool isInsert) where T : class, new();
        public abstract bool Delete<T>(object pkId) where T : class, new();
        public abstract T GetObject<T>(object pkId) where T : class, new();
        public abstract int GetObjectCount<T>(SearchCriterion objSearchCriterion) where T : class, new();
        public abstract List<T> GetObjectList<T>(SearchCriterion objSearchCriterion) where T : class, new();
    }
}
