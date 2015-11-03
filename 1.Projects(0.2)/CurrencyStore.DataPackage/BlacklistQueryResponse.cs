using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class BlacklistQueryResponse : DatagramResponse
    {
        public const short Length = 13;
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
        public int BlacklistCountSize
        {
            get;
            set;
        }
        public byte[] BlacklistCount
        {
            get;
            set;
        }
        public BlacklistQueryResponse()
            : base()
        {
            this.Type = DatagramTypeEnum.BlacklistQueryResponse;
            this.BlacklistVersionSize = 3;
            this.BlacklistCountSize = 2;
            this.FullDatagramSize = BlacklistQueryResponse.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.BlacklistVersion = rawDatagram.Read(6, this.BlacklistVersionSize);
            this.BlacklistCount = rawDatagram.Read(9, this.BlacklistCountSize);
            this.Foot = rawDatagram.Read(11, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(BlacklistQueryResponse.FixCommandCode).Merge(this.BlacklistVersion).Merge(this.BlacklistCount).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(BlacklistQueryResponse.FixCommandCode).Merge(this.BlacklistVersion).Merge(this.BlacklistCount).Sum().ToBytes();
        }
    }
}
