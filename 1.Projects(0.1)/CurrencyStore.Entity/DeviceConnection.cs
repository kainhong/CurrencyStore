using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class DeviceConnection
    {
        public enum ConnectionStatusEnum
        {
            Connect = 1,
            Disconnect = 2
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
        /// 设备地址
        /// </summary>
        public string DeviceIp { get; set; }
        /// <summary>
        /// 网点机构Id，人工创建，引用PkId
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 采集系统名称
        /// </summary>
        public string CollectorName { get; set; }
        /// <summary>
        /// 采集系统IP地址
        /// </summary>
        public string CollectorIp { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }
        /// <summary>
        /// 断开时间
        /// </summary>
        public DateTime DisconnectTime { get; set; }
        /// <summary>
        /// 连接状态，1-已连接，2-未连接
        /// </summary>
        public byte ConnectionStatus { get; set; }
        /// <summary>
        /// 上传张数
        /// </summary>
        public int UploadCount { get; set; }

        public DeviceConnection()
        {
            this.DeviceIp = "0.0.0.0";
            this.ConnectionStatus = (int)ConnectionStatusEnum.Disconnect;
        }
    }
}
