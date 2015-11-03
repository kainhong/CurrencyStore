using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class DeviceInfo
    {
        public enum DeviceStatusEnum
        {
            Disable = 0,
            Enable = 1
        }
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 设备号码
        /// </summary>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public string SoftwareVersion { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisterIp { get; set; }
        /// <summary>
        /// 设备类别代码
        /// </summary>
        public byte KindCode { get; set; }
        /// <summary>
        /// 设备型号代码
        /// </summary>
        public byte ModelCode { get; set; }
        /// <summary>
        /// 网点机构Id
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime OnLineTime { get; set; }
        /// <summary>
        /// 设备状态，0-禁用，1-启用
        /// </summary>
        public byte DeviceStatus { get; set; }

        public DeviceInfo()
        {
            this.RegisterIp = "0.0.0.0";
        }
    }
}
