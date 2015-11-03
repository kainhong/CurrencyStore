using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Client
{
    public class BufferPool
    {
        private Queue<byte[]> BufferList { get; set; }

        public BufferPool()
        {
            this.BufferList = new Queue<byte[]>();
        }

        public void Set(byte[] data)
        {
            lock (this.BufferList)
            {
                this.BufferList.Enqueue(data);
            }
        }

        public byte[] Get()
        {
            lock (this.BufferList)
            {
                if (this.BufferList.Count > 0)
                {
                    return this.BufferList.Dequeue();
                }

                else
                {
                    return null;
                }
            }
        }
    }
}
