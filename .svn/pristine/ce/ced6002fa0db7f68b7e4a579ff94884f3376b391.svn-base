using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class DatagramResponse : Datagram
    {
        public DatagramResponse()
            : base()
        {
        }
        public override void Parse(byte[] rawDatagram)
        {
            base.Parse(rawDatagram);

            this.CommandCode = rawDatagram.Read(4, this.CommandCodeSize);
        }
        public override byte[] BuildFull()
        {
            return this.Head.Merge(this.DatagramLength);
        }
        public override byte[] BuildFoot()
        {
            return this.DatagramLength;
        }
    }
}
