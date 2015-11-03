using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class BlacklistQueryRequest : DatagramRequest
    {
        public const short Length = 19;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x05 };
        public short BlacklistVersionSize
        {
            get;
            set;
        }
        public byte[] BlacklistVersion
        {
            get;
            set;
        }
        public BlacklistQueryRequest()
            : base()
        {
            this.Type = DatagramTypeEnum.BlacklistQueryRequest;
            this.BlacklistVersionSize = 3;
            this.FullDatagramSize = BlacklistQueryRequest.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.BlacklistVersion = rawDatagram.Read(13, this.BlacklistVersionSize);
            this.Foot = rawDatagram.Read(17, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(BlacklistQueryRequest.FixCommandCode).Merge(this.BlacklistVersion).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(BlacklistQueryRequest.FixCommandCode).Merge(this.BlacklistVersion).Sum().ToBytes();
        }
    }
}
