using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class CurrencyInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long PkId { get; set; }
        /// <summary>
        /// 网点机构Id
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 设备号码
        /// </summary>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// 设备类别代码
        /// </summary>
        public byte DeviceKindCode { get; set; }
        /// <summary>
        /// 设备型号代码
        /// </summary>
        public byte DeviceModelCode { get; set; }
        /// <summary>
        /// 操作员号码
        /// </summary>
        public byte OperatorNumber { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }
        /// <summary>
        /// 业务类型，0-未知，1-存款，2-取款，3-复点，4-清分，5-ATM配钞
        /// </summary>
        public byte BusinessType { get; set; }
        /// <summary>
        /// 客户卡号
        /// </summary>
        public string ClientCardNumber { get; set; }
        /// <summary>
        /// 批次号码
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 纸币顺序号
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// 纸币种类代码
        /// </summary>
        public byte CurrencyKindCode { get; set; }
        /// <summary>
        /// 纸币面额
        /// </summary>
        public short FaceAmount { get; set; }
        /// <summary>
        /// 纸币版本
        /// </summary>
        public short CurrencyVersion { get; set; }
        /// <summary>
        /// 纸币类型，4-ATM券，5-流通券，6-残损券，7-退钞券，机器发送
        /// </summary>
        public byte CurrencyType { get; set; }
        /// <summary>
        /// 钞口号码，0-退钞口，1-1号钞口，2-2号钞口，3-3号钞口，4-4号钞口
        /// </summary>
        public byte PortNumber { get; set; }
        /// <summary>
        /// 是否可疑，0-真钞，非0-可疑钞
        /// </summary>
        public byte IsSuspicious { get; set; }
        /// <summary>
        /// 纸币号码
        /// </summary>
        public string CurrencyNumber { get; set; }
        /// <summary>
        /// 纸币图像类型，0-无图像，1-360字节，2-240字节，3-120字节
        /// </summary>
        public byte CurrencyImageType { get; set; }
        /// <summary>
        /// 纸币图像
        /// </summary>
        public byte[] CurrencyImage { get; set; }
        /// <summary>
        /// 是否重复，0-不重复，1-重复
        /// </summary>
        public byte IsDuplicate { get; set; }
        /// <summary>
        /// 是否已上传，0-未上传，1-已上传
        /// </summary>
        public byte IsUpload { get; set; }
    }
}
