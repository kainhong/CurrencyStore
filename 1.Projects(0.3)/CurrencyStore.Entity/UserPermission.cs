using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserPermission
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 权限代码
        /// </summary>
        public string PermCode { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermName { get; set; }
        /// <summary>
        /// 权限级别，1-1级菜单，2-2级菜单
        /// </summary>
        public byte PermLevel { get; set; }
        /// <summary>
        /// 权限内容
        /// </summary>
        public string PermContent { get; set; }
        /// <summary>
        /// 上级权限Id
        /// </summary>
        public int PermParentId { get; set; }
    }
}
