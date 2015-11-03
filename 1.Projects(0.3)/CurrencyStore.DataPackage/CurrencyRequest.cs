using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class CurrencyRequest : DatagramRequest
    {
        public const short Length = 302;
        public static readonly byte[] FixCommandCode = { 0xA0, 0x0A };
        public int KeySize
        {
            get;
            set;
        }
        public byte[] Key
        {
            get;
            set;
        }
        public int OperateTimeSize
        {
            get;
            set;
        }
        public byte[] OperateTime
        {
            get;
            set;
        }
        public int OperatorNumberSize
        {
            get;
            set;
        }
        public byte[] OperatorNumber
        {
            get;
            set;
        }
        public int ClientCardNumberSize
        {
            get;
            set;
        }
        public byte[] ClientCardNumber
        {
            get;
            set;
        }
        public int BusinessTypeSize
        {
            get;
            set;
        }
        public byte[] BusinessType
        {
            get;
            set;
        }
        public int BatchNumberSize
        {
            get;
            set;
        }
        public byte[] BatchNumber
        {
            get;
            set;
        }
        public int OrderNumberSize
        {
            get;
            set;
        }
        public byte[] OrderNumber
        {
            get;
            set;
        }
        public int CurrencyTypeSize
        {
            get;
            set;
        }
        public byte[] CurrencyType
        {
            get;
            set;
        }
        public int CurrencyAmountSize
        {
            get;
            set;
        }
        public byte[] CurrencyAmount
        {
            get;
            set;
        }
        public int CurrencyVersionSize
        {
            get;
            set;
        }
        public byte[] CurrencyVersion
        {
            get;
            set;
        }
        public int CurrencyFlagSize
        {
            get;
            set;
        }
        public byte[] CurrencyFlag
        {
            get;
            set;
        }
        public int CurrencyRealSize
        {
            get;
            set;
        }
        public byte[] CurrencyReal
        {
            get;
            set;
        }
        public int CurrencyNumberSize
        {
            get;
            set;
        }
        public byte[] CurrencyNumber
        {
            get;
            set;
        }
        public int CurrencyNumberImageTypeSize
        {
            get;
            set;
        }
        public byte[] CurrencyNumberImageType
        {
            get;
            set;
        }
        public int CurrencyNumberImageSize
        {
            get;
            set;
        }
        public byte[] CurrencyNumberImage
        {
            get;
            set;
        }
        public int ReserveSize
        {
            get;
            set;
        }
        public byte[] Reserve
        {
            get;
            set;
        }
        public CurrencyRequest()
            : base()
        {
            this.Type = DatagramTypeEnum.CurrencyRequest;
            this.KeySize = 1;
            this.OperateTimeSize = 6;
            this.OperatorNumberSize = 1;
            this.ClientCardNumberSize = 10;
            this.BusinessTypeSize = 1;
            this.BatchNumberSize = 3;
            this.OrderNumberSize = 2;
            this.CurrencyTypeSize = 1;
            this.CurrencyAmountSize = 2;
            this.CurrencyVersionSize = 2;
            this.CurrencyFlagSize = 1;
            this.CurrencyRealSize = 1;
            this.CurrencyNumberSize = 13;
            this.CurrencyNumberImageTypeSize = 1;
            this.CurrencyNumberImageSize = 240;
            this.ReserveSize = 1;
            this.FullDatagramSize = CurrencyRequest.Length;

            this.DatagramLength = this.FullDatagramSize.ToBytes();
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.Key = rawDatagram.Read(14, this.KeySize);
            this.OperateTime = rawDatagram.Read(15, this.OperateTimeSize);
            this.OperatorNumber = rawDatagram.Read(21, this.OperatorNumberSize);
            this.ClientCardNumber = rawDatagram.Read(22, this.ClientCardNumberSize);
            this.BusinessType = rawDatagram.Read(32, this.BusinessTypeSize);
            this.BatchNumber = rawDatagram.Read(33, this.BatchNumberSize);
            this.OrderNumber = rawDatagram.Read(36, this.OrderNumberSize);
            this.CurrencyType = rawDatagram.Read(38, this.CurrencyTypeSize);
            this.CurrencyAmount = rawDatagram.Read(39, this.CurrencyAmountSize);
            this.CurrencyVersion = rawDatagram.Read(41, this.CurrencyVersionSize);
            this.CurrencyFlag = rawDatagram.Read(43, this.CurrencyFlagSize);
            this.CurrencyReal = rawDatagram.Read(44, this.CurrencyRealSize);
            this.CurrencyNumber = rawDatagram.Read(45, this.CurrencyNumberSize);
            this.CurrencyNumberImageType = rawDatagram.Read(58, this.CurrencyNumberImageTypeSize);
            this.CurrencyNumberImage = rawDatagram.Read(59, this.CurrencyNumberImageSize);
            this.Reserve = rawDatagram.Read(299, this.ReserveSize);
            this.Foot = rawDatagram.Read(300, this.FootSize);
        }
        public override byte[] BuildFull()
        {
            return base.BuildFull().Merge(CurrencyRequest.FixCommandCode).Merge(this.Key)
                .Merge(this.OperateTime).Merge(this.OperatorNumber).Merge(this.ClientCardNumber).Merge(this.BusinessType)
                .Merge(this.BatchNumber).Merge(this.OrderNumber).Merge(this.CurrencyType).Merge(this.CurrencyAmount)
                .Merge(this.CurrencyVersion).Merge(this.CurrencyFlag).Merge(this.CurrencyReal).Merge(this.CurrencyNumber)
                .Merge(this.CurrencyNumberImageType).Merge(this.CurrencyNumberImage).Merge(this.Reserve)
                .Merge(this.Foot);
        }
        public override byte[] BuildFoot()
        {
            return base.BuildFoot().Merge(CurrencyRequest.FixCommandCode).Merge(this.Key)
               .Merge(this.OperateTime).Merge(this.OperatorNumber).Merge(this.ClientCardNumber).Merge(this.BusinessType)
               .Merge(this.BatchNumber).Merge(this.OrderNumber).Merge(this.CurrencyType).Merge(this.CurrencyAmount)
               .Merge(this.CurrencyVersion).Merge(this.CurrencyFlag).Merge(this.CurrencyReal).Merge(this.CurrencyNumber)
               .Merge(this.CurrencyNumberImageType).Merge(this.CurrencyNumberImage).Merge(this.Reserve).Sum().ToBytes();
        }
    }
}
