using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CurrencyStore.Common.Dynamic;

namespace CurrencyStore.Common.Dynamic
{
    /// <summary>
    /// 类型比较
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class CompareEquality<T> : IEqualityComparer<T>
    {
        string _expression;
        Delegate _dynamicDelegate;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompareEquality() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="expression">表达式</param>
        public CompareEquality(string expression)
        {
            _expression = expression;
            ParseLambda();
        }

        #region private methods
        private void ParseLambda()
        {
            if (string.IsNullOrEmpty(_expression))
                return;
            var l = DynamicExpressionParsor.ParseLambda<bool>(_expression
               , Expression.Parameter(typeof(T), "a")
               , Expression.Parameter(typeof(T), "b"));

            _dynamicDelegate = l.Compile();
        }

        #endregion

        #region IEqualityComparer<T> Members
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>是否一致</returns>
        public bool Equals(T x, T y)
        {
            if (_dynamicDelegate != null)
            {
                return (bool)_dynamicDelegate.DynamicInvoke(y, x);
            }
            return x.Equals(y);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>对象的哈希值</returns>
        public int GetHashCode(T obj)
        {
            return typeof(T).GetHashCode();
        }

        #endregion

    }
}
