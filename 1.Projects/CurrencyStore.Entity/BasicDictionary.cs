using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class BasicDictionary
    {
        [Serializable]
        public enum DictKindEnum
        {
            DeviceKind = 1,
            DeviceModel = 2,
            CurrencyKind = 3,
            CurrencyType = 4,
            BusinessType = 5,
            PortNumber = 6
        }
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 字典数据类别，1-设备类别，2-设备型号，3-纸币种类，4-纸币类型，5-业务类型，6-钞口号码
        /// </summary>
        public byte DictKind { get; set; }
        /// <summary>
        /// 字典数据键
        /// </summary>
        public byte DictKey { get; set; }
        /// <summary>
        /// 字典数据值
        /// </summary>
        public string DictValue { get; set; }
        /// <summary>
        /// 是否系统字典，0-非系统参数，1-系统参数
        /// </summary>
        public byte IsSystem { get; set; }
    }
}
