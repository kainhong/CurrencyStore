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
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// ���ݹ��ˣ�0-�����ˣ�1-����
        /// </summary>
        public byte DataFilter { get; set; }
        /// <summary>
        /// ��ɫ״̬��0-���ã�1-����
        /// </summary>
        public byte RoleStatus { get; set; }
    }
}
