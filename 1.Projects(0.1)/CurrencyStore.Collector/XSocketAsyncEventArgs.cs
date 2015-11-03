using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CurrencyStore.Collector
{
    public class XSocketAsyncEventArgs : SocketAsyncEventArgs
    {
        public int BufferSize { get; set; }

        public XSocketAsyncEventArgs()
            : this(512)
        {
        }

        public XSocketAsyncEventArgs(int bufferSize)
        {
            this.BufferSize = bufferSize;

            this.SetBuffer(new byte[this.BufferSize], 0, this.BufferSize);
        }
    }
}
