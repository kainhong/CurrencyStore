/********
* Copyright © 深圳市新元素医疗技术开发有限公司 . All rights reserved.
* 
*  Description:
*  Create By Kain at 5/23/2011 1:48:12 PM
*  
*
*  Revision History:
*  Date                  Who                 What
*  
* 
********/

#region namespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

#endregion

namespace CurrencyStore.Common.Dynamic
{
    /// <summary>
    /// 对象动态代理
    /// </summary>
    public class ObjectProxy : DynamicObject, IEnumerable
    {
        Type type;
        /// <summary>
        /// Wrap对象
        /// </summary>
        public virtual object Object { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public ObjectProxy(object val)
        {
            Object = val;
            type = val.GetType();
        }

        /// <summary>
        /// 属性数量
        /// </summary>
        public int Count
        {
            get
            {
                return ObjectFactory.GetProperties(type).Count();
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="property">属性名称</param>
        /// <returns></returns>
        public object this[string property]
        {
            get
            {
                return Object.GetValue(property);
            }
            set
            {
                Object.SetValue(property, value);
            }
        }

        /// <summary>
        /// Get Member
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            return Object.TryGetValue(binder.Name, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            return Object.TrySetValue(binder.Name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return ObjectFactory.GetProperties(type).Select(c => c.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            var ie = this.Object as IEnumerable;
            if (ie == null)
                ie = GetDynamicMemberNames();

            foreach (var item in ie)
            {
                yield return item;
            }
        }
    }

}
