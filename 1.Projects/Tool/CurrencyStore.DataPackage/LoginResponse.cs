using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class LoginResponse : DatagramResponse
    {
        public const short Length = 16;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x03 };
        public short KeySize
        {
            get;
            set;
        }
        public byte[] Key
        {
            get;
            set;
        }
        public short ServerTimeSize
        {
            get;
            set;
        }
        public byte[] ServerTime
        {
            get;
            set;
        }
        public short RegisterFlagSize
        {
            get;
            set;
        }
        public byte[] RegisterFlag
        {
            get;
            set;
        }
        public LoginResponse()
            : base()
        {
            this.Type = DatagramTypeEnum.LoginResponse;
            this.KeySize = 1;
            this.ServerTimeSize = 6;
            this.RegisterFlagSize = 1;
            this.FullDatagramSize = LoginResponse.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Key = rawDatagram.Read(6, this.KeySize);
            this.ServerTime = rawDatagram.Read(7, this.ServerTimeSize);
            this.RegisterFlag = rawDatagram.Read(13, this.RegisterFlagSize);
            this.Foot = rawDatagram.Read(14, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(LoginResponse.FixCommandCode).Merge(this.Key).Merge(this.ServerTime).Merge(this.RegisterFlag).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(LoginResponse.FixCommandCode).Merge(this.Key).Merge(this.ServerTime).Merge(this.RegisterFlag).Sum().ToBytes();
        }
    }
}
