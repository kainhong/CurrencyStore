using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class CurrencyResponse : DatagramResponse
    {
        public const short Length = 9;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x0A };
        public int ResultSize
        {
            get;
            set;
        }
        public byte[] Result
        {
            get;
            set;
        }
        public CurrencyResponse()
            : base()
        {
            this.Type = DatagramTypeEnum.CurrencyResponse;
            this.ResultSize = 1;
            this.FullDatagramSize = CurrencyResponse.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Result = rawDatagram.Read(6, this.ResultSize);
            this.Foot = rawDatagram.Read(7, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(CurrencyResponse.FixCommandCode).Merge(this.Result).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(CurrencyResponse.FixCommandCode).Merge(this.Result).Sum().ToBytes();
        }
    }
}
