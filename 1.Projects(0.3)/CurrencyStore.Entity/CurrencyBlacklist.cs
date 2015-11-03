using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class CurrencyBlacklist
    {
        /// <summary>
        /// Ö÷¼ü
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// Ö½±ÒÖÖÀà´úÂë
        /// </summary>
        public byte CurrencyKindCode { get; set; }
        /// <summary>
        /// Ö½±ÒÃæ¶î
        /// </summary>
        public short FaceAmount { get; set; }
        /// <summary>
        /// Ö½±Ò°æ±¾
        /// </summary>
        public short CurrencyVersion { get; set; }
        /// <summary>
        /// Ö½±ÒºÅÂë
        /// </summary>
        public string CurrencyNumber { get; set; }
    }
}
