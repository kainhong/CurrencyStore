using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class HeartbeatResponse : DatagramResponse
    {
        public const short Length = 8;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x01 };
        public HeartbeatResponse()
            : base()
        {
            this.Type = DatagramTypeEnum.HeartbeatResponse;
            this.FullDatagramSize = HeartbeatResponse.Length;
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Foot = rawDatagram.Read(6, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(HeartbeatResponse.FixCommandCode).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(HeartbeatResponse.FixCommandCode).Sum().ToBytes();
        }
    }
}
