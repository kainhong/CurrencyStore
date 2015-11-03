using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class CurrencyStatInfo
    {
        public int OrgId { get; set; }
        public byte DeviceKindCode { get; set; }
        public byte DeviceModelCode { get; set; }
        public string CurrencyKindCode { get; set; }
        public short FaceAmount { get; set; }
        public byte IsSuspicious { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
    }
}
