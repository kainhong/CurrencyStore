using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class DeviceStatInfo
    {
        public int OrgId { get; set; }
        public byte KindCode { get; set; }
        public byte ModelCode { get; set; }
        public int Count { get; set; }
    }
}
