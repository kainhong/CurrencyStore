using System;
using System.Net;
using CurrencyStore.Business;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Communication
{
    public class Device
    {
        public Device()
        {
            ConnectionDate = DateTime.Now;
            Connected = true;
            this.Reset();
        }

        internal bool Updated { get; set; }

        public void Increate()
        {
            Counter += 1;

            if (!string.IsNullOrEmpty(Number))
            {
                ConnectionCounter.Current.Increase(this.Number, 1);
            }
        }

        public void Reset()
        {
            Counter = 0;

            if (!string.IsNullOrEmpty(Number))
            {
                ConnectionCounter.Current.Reset(this.Number);
            }
        }

        public int Counter { get; private set; }

        public string Number { get; set; }

        public string RemoteIP { get; set; }

        public string LocalIP { get; set; }

        public DateTime ConnectionDate { get; set; }

        public DateTime DisconnectionDate { get; set; }

        public bool Connected { get; set; }
    }

    /// <summary>
    /// EventArgs class holding a Byte[].
    /// </summary>
    public class DataEventArgs : EventArgs
    {
        public IPEndPoint RemoteEndPoint { get; set; }
        public Byte[] Data { get; set; }
        public Int32 Offset { get; set; }
        public Int32 Length { get; set; }
        public Device Device { get; set; }
    }
}
