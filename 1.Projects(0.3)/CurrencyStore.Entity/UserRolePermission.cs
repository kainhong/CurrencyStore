using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserRolePermission
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限代码
        /// </summary>
        public string PermCode { get; set; }
    }
}
