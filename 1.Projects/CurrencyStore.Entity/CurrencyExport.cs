using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class CurrencyExport
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 网点机构Id
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 设备号码
        /// </summary>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// 操作开始时间
        /// </summary>
        public string OperateStartTime { get; set; }
        /// <summary>
        /// 操作结束时间
        /// </summary>
        public string OperateEndTime { get; set; }
        /// <summary>
        /// 纸币号码
        /// </summary>
        public string CurrencyNumber { get; set; }
        /// <summary>
        /// 导出状态，0-未开始，1-进行中，2-已完成
        /// </summary>
        public byte ExportStatus { get; set; }
        /// <summary>
        /// 数据量
        /// </summary>
        public int DataCount { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 创建用户Id
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
