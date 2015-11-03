using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class BlacklistDownloadRequest : DatagramRequest
    {
        public const short Length = 18;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x06 };
        public short BlacklistOrderSize
        {
            get;
            set;
        }
        public byte[] BlacklistOrder
        {
            get;
            set;
        }
        public BlacklistDownloadRequest()
            : base()
        {
            this.Type = DatagramTypeEnum.BlacklistDownloadRequest;
            this.BlacklistOrderSize = 2;
            this.FullDatagramSize = BlacklistDownloadRequest.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.BlacklistOrder = rawDatagram.Read(14, this.BlacklistOrderSize);
            this.Foot = rawDatagram.Read(16, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(BlacklistDownloadRequest.FixCommandCode).Merge(this.BlacklistOrder).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(BlacklistDownloadRequest.FixCommandCode).Merge(this.BlacklistOrder).Sum().ToBytes();
        }
    }
}
