using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class DatagramRequest : Datagram
    {
        public short DeviceNumberSize
        {
            get;
            set;
        }
        public byte[] DeviceNumber
        {
            get;
            set;
        }
        public DatagramRequest()
            : base()
        {
            this.DeviceNumberSize = 8;
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.DeviceNumber = rawDatagram.Read(4, this.DeviceNumberSize);
            this.CommandCode = rawDatagram.Read(12, this.CommandCodeSize);
        }
        public override byte[] BuildFull()
        {
            return this.Head.Merge(this.DatagramLength).Merge(this.DeviceNumber);
        }
        public override byte[] BuildFoot()
        {
            return this.DatagramLength.Merge(this.DeviceNumber).Sum().ToBytes();
        }
    }
}
