using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserInfo
    {
        public enum UserStatusEnum
        {
            Disable = 0,
            Enable = 1
        }
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 用户账户
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户状态，0-禁用，1-启用
        /// </summary>
        public byte UserStatus { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 网点机构Id
        /// </summary>
        public int OrgId { get; set; }
    }
}
