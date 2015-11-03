using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class CurrencyBlacklist
    {
        /// <summary>
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// ֽ���������
        /// </summary>
        public byte CurrencyKindCode { get; set; }
        /// <summary>
        /// ֽ�����
        /// </summary>
        public short FaceAmount { get; set; }
        /// <summary>
        /// ֽ�Ұ汾
        /// </summary>
        public short CurrencyVersion { get; set; }
        /// <summary>
        /// ֽ�Һ���
        /// </summary>
        public string CurrencyNumber { get; set; }
    }
}
