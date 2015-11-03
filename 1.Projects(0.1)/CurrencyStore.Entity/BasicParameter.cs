using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class BasicParameter
    {
        /// <summary>
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string ParamKey { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// ����ֵ
        /// </summary>
        public string ParamValue { get; set; }
    }
}
