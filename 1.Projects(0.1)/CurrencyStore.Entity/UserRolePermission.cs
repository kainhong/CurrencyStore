using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserRolePermission
    {
        /// <summary>
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// ��ɫId
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Ȩ�޴���
        /// </summary>
        public string PermCode { get; set; }
    }
}
