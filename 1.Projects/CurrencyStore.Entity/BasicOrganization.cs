using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class BasicOrganization
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// 网点机构号码
        /// </summary>
        public string OrgNumber { get; set; }
        /// <summary>
        /// 网点机构名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 网点机构地址
        /// </summary>
        public string OrgAddress { get; set; }
        /// <summary>
        /// 上级网点机构Id
        /// </summary>
        public int OrgParentId { get; set; }
        /// <summary>
        /// 网点机构全路径
        /// </summary>
        public string OrgFullPath { get; set; }
    }
}
