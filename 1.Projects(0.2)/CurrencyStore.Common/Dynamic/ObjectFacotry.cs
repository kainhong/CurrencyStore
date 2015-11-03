using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CurrencyStore.Common.Dynamic
{
    /// <summary>
    /// 对象构造工厂
    /// </summary>
    public static class ObjectFactory
    {
        static ConcurrentDictionary<RuntimeTypeHandle, Dictionary<string, PropertyDescription>> _memberCache =
        new ConcurrentDictionary<RuntimeTypeHandle, Dictionary<string, PropertyDescription>>();

        static Dictionary<int, Func<object[], object>> _cache = new Dictionary<int, Func<object[], object>>();
        /// <summary>
        /// 创建用来返回构造函数的委托
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="parameterTypes">构造函数的参数类型数组</param>
        /// <returns></returns>
        static Func<object[], object> CreateInstanceDelegate(this Type type, Type[] parameterTypes)
        {
            //根据参数类型数组来获取构造函数
            var constructor = type.GetConstructor(parameterTypes);

            //创建lambda表达式的参数
            var lambdaParam = Expression.Parameter(typeof(object[]), "_args");

            //创建构造函数的参数表达式数组
            Expression[] constructorParam = buildParameters(parameterTypes, lambdaParam);

            //创建构造函数表达式
            NewExpression newExp = Expression.New(constructor, constructorParam);


            //创建lambda表达式，返回构造函数
            Expression<Func<object[], object>> lambdaExp =
                Expression.Lambda<Func<object[], object>>(newExp, lambdaParam);

            return lambdaExp.Compile();
        }

        /// <summary>
        /// 根据类型数组和lambda表达式的参数，转化参数成相应类型 
        /// </summary>
        /// <param name="parameterTypes">类型数组</param>
        /// <param name="paramExp">lambda表达式的参数表达式（参数是：object[]）</param>
        /// <returns>构造函数的参数表达式数组</returns>
        static Expression[] buildParameters(Type[] parameterTypes, ParameterExpression paramExp)
        {
            List<Expression> list = new List<Expression>();
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                //从参数表达式（参数是：object[]）中取出参数
                var arg = BinaryExpression.ArrayIndex(paramExp, Expression.Constant(i));
                //把参数转化成指定类型
                var argCast = Expression.Convert(arg, parameterTypes[i]);

                list.Add(argCast);
            }
            return list.ToArray();
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="args">参数</param>
        /// <returns>对象的实例</returns>
        public static object CreateInstance(string typeName, params object[] args)
        {
            var t = GetType(typeName);
            return t.CreateInstance(args);
        }

        /// <summary>
        /// 根据类型名称获取类型实例
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns>类型</returns>
        public static Type GetType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                throw new ArgumentNullException("类型名称不能为空.");

            Type t = Type.GetType(typeName);
            if (t == null)
            {
                var temp = typeName.Split(',');
                if (temp.Length >= 2)
                {
                    var assemblyName = temp[1];
                    var assemblyFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, assemblyName + ".dll");//当前目录

                    if (System.IO.File.Exists(assemblyFile))//plugin目录
                    {
                        var assembly = Assembly.LoadFile(assemblyFile);
                        if (assembly != null)
                        {
                            t = assembly.GetType(temp[0], true, true);
                        }
                    }
                }

                if (t == null)
                    throw new ArgumentException("没有找到具体的类型：\"" + typeName + "\".");
            }
            return t;
        }

        /// <summary>
        /// 创建一个对象实例
        /// </summary>
        /// <typeparam name="T">类型T</typeparam>
        /// <param name="typeName">类型名称</param>
        /// <param name="args">构造参数</param>
        /// <returns>T实例</returns>
        public static T CreateInstance<T>(string typeName, params object[] args) where T : class
        {
            return CreateInstance(typeName, args) as T;
        }

        /// <summary>
        /// 创建一个对象实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="args">构造参数</param>
        /// <returns>类型实例</returns>
        public static object CreateInstance(this Type type, params object[] args)
        {
            Func<object[], object> createInstanceDelegate;
            if (args == null)
                args = new object[] { };
            //根据参数列表返回参数类型数组
            Type[] parameterTypes = args.Select(c => c.GetType()).ToArray();

            //从缓存中获取构造函数的委托（注：key是 type 和 parameterTypes）
            int key = type.GetHashCode() | parameterTypes.GetHashCode();

            if (!_cache.TryGetValue(key, out createInstanceDelegate))
            {
                //缓存中没有找到，新建一个构造函数的委托
                createInstanceDelegate = type.CreateInstanceDelegate(parameterTypes);

                //缓存构造函数的委托
                _cache.Add(key, createInstanceDelegate);
            }

            return createInstanceDelegate(args);
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">类型 T</typeparam>
        /// <param name="args">构造参数</param>
        /// <returns>T的实例</returns>
        public static T CreateInstance<T>(params object[] args) where T : class
        {
            Type t = typeof(T);
            return t.CreateInstance(args) as T;
        }

        /// <summary>
        /// 反射调用获取object的一个属性值
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性值</returns>
        public static object GetValue(this object obj, string propertyName)
        {
            object val;
            TryGetValue(obj, propertyName, out val);
            return val;
        }

        /// <summary>
        /// 反射调用获取object的一个属性值
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="obj">object</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性值</returns>
        public static T GetValue<T>(this object obj, string propertyName)
        {
            var val = GetValue(obj, propertyName);
            return (T)val;
        }

        /// <summary>
        /// 尝试获取一个对象的属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryGetValue(this object obj, string propertyName, out object value)
        {
            value = null;
            if (obj == null)
                return false;
            var item = GetTypeMemberInfo(obj.GetType(), propertyName);
            if (item != null)
            {
                value = item.Get.DynamicInvoke(obj);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 反射调用设置object的一个属性值
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">属性值</param>
        public static void SetValue(this object obj, string propertyName, object value)
        {
            TrySetValue(obj, propertyName, value);
        }

        /// <summary>
        /// 尝试对一个对象属性赋值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TrySetValue(this object obj, string propertyName, object value)
        {
            if (obj == null)
                return false;
            var item = GetTypeMemberInfo(obj.GetType(), propertyName);
            if (item == null)
                return false;
            var val = Convert.ChangeType(value, item.Type);
            item.Set.DynamicInvoke(obj, val);

            return true;
        }

        /// <summary>
        /// 转换为dynamic对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ObjectProxy AsDynamic(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            return new ObjectProxy(obj);

        }

        /// <summary>
        /// 获取对象属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="readonly"></param>
        /// <param name="writeonly"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyDescription> GetProperties(this Type type, bool @readonly = false, bool @writeonly = false)
        {
            var dict = GetTypeMemberInfos(type);
            foreach (var item in dict)
            {
                if (!@readonly && !@writeonly)
                    yield return item.Value;
                if (@readonly && item.Value.CanRead)
                    yield return item.Value;
                if (@writeonly && item.Value.CanWrite)
                    yield return item.Value;
            }
        }

        private static PropertyDescription GetTypeMemberInfo(Type type, string property)
        {
            var dict = GetTypeMemberInfos(type);
            return dict[property];
        }

        internal static Dictionary<string, PropertyDescription> GetTypeMemberInfos(Type type)
        {
            Dictionary<string, PropertyDescription> dict;
            if (!_memberCache.TryGetValue(type.TypeHandle, out dict))
                lock (type)
                {
                    if (_memberCache.TryGetValue(type.TypeHandle, out dict))
                        return dict;

                    var properties = type.GetProperties();
                    dict = new Dictionary<string, PropertyDescription>();
                    foreach (var p in properties)
                    {
                        var item = new PropertyDescription();
                        item.CanRead = p.CanRead;
                        item.CanWrite = p.CanWrite;
                        item.Name = p.Name;
                        item.Type = p.PropertyType;
                        if (p.CanRead)
                        {
                            var c = Expression.Parameter(type, "c");
                            var body = Expression.PropertyOrField(c, p.Name);
                            item.Get = Expression.Lambda(body, c).Compile();
                        }
                        if (p.CanWrite)
                        {
                            var param_obj = Expression.Parameter(typeof(object), "obj");
                            //值
                            var param_val = Expression.Parameter(typeof(object), "val");
                            //转换参数为真实类型
                            var body_obj = Expression.Convert(param_obj, type);
                            var body_val = Expression.Convert(param_val, p.PropertyType);
                            //调用给属性赋值的方法
                            var body = Expression.Call(body_obj, p.GetSetMethod(), body_val);
                            item.Set = Expression.Lambda<Action<object, object>>(body, param_obj, param_val).Compile();
                        }
                        dict.Add(p.Name, item);
                    }
                    _memberCache.TryAdd(type.TypeHandle, dict);
                }

            return dict;
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public class PropertyDescription
    {
        private RuntimeTypeHandle _typeHander;
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
        public Type Type
        {
            get { return System.Type.GetTypeFromHandle(_typeHander); }
            set { _typeHander = value.TypeHandle; }
        }

        /// <summary>
        /// 是否可读
        /// </summary>
        public bool CanRead { get; set; }

        /// <summary>
        /// 是否可写
        /// </summary>
        public bool CanWrite { get; set; }

        /// <summary>
        /// 读方法
        /// </summary>
        public Delegate Get { get; set; }

        /// <summary>
        /// 写方法
        /// </summary>
        public Delegate Set { get; set; }
    }
}
