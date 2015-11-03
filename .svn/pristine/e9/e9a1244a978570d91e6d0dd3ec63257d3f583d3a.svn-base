using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class HeartbeatRequest : DatagramRequest
    {
        public const short Length = 16;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x01 };
        public HeartbeatRequest()
            : base()
        {
            this.Type = DatagramTypeEnum.HeartbeatRequest;
            this.FullDatagramSize = HeartbeatRequest.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
            this.CommandCode = HeartbeatRequest.FixCommandCode;
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Foot = rawDatagram.Read(14, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(HeartbeatRequest.FixCommandCode).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(HeartbeatRequest.FixCommandCode).Sum().ToBytes();
        }
    }
}
