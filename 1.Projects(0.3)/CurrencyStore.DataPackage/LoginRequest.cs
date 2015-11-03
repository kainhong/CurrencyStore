using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class LoginRequest : DatagramRequest
    {
        public const short Length = 20;
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
        public short SoftwareVersionSize
        {
            get;
            set;
        }
        public byte[] SoftwareVersion
        {
            get;
            set;
        }
        public LoginRequest()
            : base()
        {
            this.Type = DatagramTypeEnum.LoginRequest;
            this.KeySize = 1;
            this.SoftwareVersionSize = 3;
            this.FullDatagramSize = LoginRequest.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Key = rawDatagram.Read(14, this.KeySize);
            this.SoftwareVersion = rawDatagram.Read(15, this.SoftwareVersionSize);
            this.Foot = rawDatagram.Read(18, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(LoginRequest.FixCommandCode).Merge(this.Key).Merge(this.SoftwareVersion).Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(LoginRequest.FixCommandCode).Merge(this.Key).Merge(this.SoftwareVersion).Sum().ToBytes();
        }
    }
}
