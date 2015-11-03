/*************
* 
* 
*  Description:
*  Create By kain.hong at 9/20/2010 10:16:32 AM
*  
*
*  Revision History:
*  Date                  Who                 What
*  
* 
******/
#region namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

#endregion


namespace CurrencyStore.Common.Query
{
    /// <summary>
    /// 查询条件
    /// </summary>

    [Serializable]
    public class QueryInformation
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryInformation()
            : this(Guid.NewGuid())
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">查询的编号</param>
        public QueryInformation(Guid id)
        {
            Id = id;
            Parameters = new List<QueryParameter>();
            Pagination = new Pagination();
        }
        /// <summary>
        /// 编号
        /// </summary>

        public Guid Id { get; private set; }

        /// <summary>
        /// 参数
        /// </summary>

        public List<QueryParameter> Parameters { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>

        public Pagination Pagination { get; set; }


    }

    /// <summary>
    /// 查询参数
    /// </summary>

    [Serializable]
    public class QueryParameter
    {
        private object _value;

        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryParameter()
        {
            Comperation = "AND";
            Operator = "=";
        }

        /// <summary>
        /// 左括号
        /// </summary>

        public string OpenParen { get; set; }

        /// <summary>
        /// 右括号
        /// </summary>

        public string CloseParen { get; set; }

        /// <summary>
        /// 是否必须
        /// </summary>

        public bool Required { get; set; }
        /// <summary>
        /// 查询条件值
        /// </summary>

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected string _valueType;

        /// <summary>
        /// 查询条件的值类型
        /// </summary>

        public string ValueType
        {
            get
            {
                if (_valueType == null && Value != null)
                    return Value.GetType().Name;
                return _valueType;
            }
            set { _valueType = value; }
        }

        /// <summary>
        /// 查询条件名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 查询条件
        /// <example>
        /// =,StartsWith,...
        /// </example>
        /// </summary>

        public string Operator { get; set; }

        /// <summary>
        /// 查询逻辑,如果是第一个条件则此参数会被忽略
        /// <example>
        /// And,Or
        /// </example>
        /// </summary>

        public string Comperation { get; set; }

        /// <summary>
        /// 条件是否为空
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (ValueType == "String")
                {
                    if (Value == null || Value.ToString().Length == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return Value == null;
            }
        }
    }
}
