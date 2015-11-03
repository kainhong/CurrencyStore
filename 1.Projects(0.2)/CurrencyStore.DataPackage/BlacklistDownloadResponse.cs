using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class BlacklistDownloadResponse : DatagramResponse
    {
        public const short Length = 26;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x06 };
        public short CurrencyNumberSize
        {
            get;
            set;
        }
        public byte[] CurrencyNumber
        {
            get;
            set;
        }
        public BlacklistDownloadResponse()
            : base()
        {
            this.Type = DatagramTypeEnum.BlacklistDownloadResponse;
            this.CurrencyNumberSize = 18;
            this.FullDatagramSize = BlacklistDownloadResponse.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.CurrencyNumber = rawDatagram.Read(6, this.CurrencyNumberSize);
            this.Foot = rawDatagram.Read(24, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(BlacklistDownloadResponse.FixCommandCode).Merge(this.CurrencyNumber).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(BlacklistDownloadResponse.FixCommandCode).Merge(this.CurrencyNumber).Sum().ToBytes();
        }
    }
}
