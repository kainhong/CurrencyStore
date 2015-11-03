using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserRole
    {
        public enum DataFilterEnum
        {
            NoFilter = 0,
            Filter = 1
        }
        public enum RoleStatusEnum
        {
            Disable = 0,
            Enable = 1
        }
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 数据过滤，0-不过滤，1-过滤
        /// </summary>
        public byte DataFilter { get; set; }
        /// <summary>
        /// 角色状态，0-禁用，1-启用
        /// </summary>
        public byte RoleStatus { get; set; }
    }
}
