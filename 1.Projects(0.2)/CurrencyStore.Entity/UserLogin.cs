using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class UserLogin
    {
        /// <summary>
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// �û�Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// ��¼IP��ַ
        /// </summary>
        public string LoginIp { get; set; }
    }
}
