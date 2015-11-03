using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CurrencyStore.Collector
{
    /// <summary>
    /// Pools data buffers to prevent both frequent allocation and memory fragmentation
    /// due to pinning in high volume scenarios.
    /// See https://blogs.msdn.com/yunjin/archive/2004/01/27/63642.aspx
    /// </summary>
    public class BufferPool
    {
        Int32 totalBytes;
        Byte[] buffer;
        Stack<Int32> freeIndexPool;
        Int32 currentIndex;
        Int32 bufferSize;

        /// <summary>
        /// Pools data buffers to prevent both frequent allocation and memory fragmentation
        /// due to pinning in high volume scenarios.
        /// </summary>
        /// <param name="numberOfBuffers">The total number of buffers that will be allocated.</param>
        /// <param name="bufferSize">The size of each buffer.</param>
        public BufferPool(Int32 numberOfBuffers, Int32 bufferSize)
        {
            this.totalBytes = numberOfBuffers * bufferSize;
            this.bufferSize = bufferSize;

            currentIndex = 0;
            freeIndexPool = new Stack<Int32>();
            buffer = new Byte[totalBytes];
        }

        /// <summary>
        /// Checks out some buffer space from the pool.
        /// </summary>
        /// <param name="args">The ScoketAsyncEventArgs which needs a buffer.</param>
        public void CheckOut(SocketAsyncEventArgs args)
        {
            lock (freeIndexPool)
            {
                if (freeIndexPool.Count > 0)
                    args.SetBuffer(buffer, freeIndexPool.Pop(), bufferSize);
                else
                {
                    args.SetBuffer(buffer, currentIndex, bufferSize);
                    currentIndex += bufferSize;
                }
            }
        }

        /// <summary>
        /// Checks a buffer back in to the pool.
        /// </summary>
        /// <param name="args">The SocketAsyncEventArgs which has finished with it buffer.</param>
        public void CheckIn(SocketAsyncEventArgs args)
        {
            lock (freeIndexPool)
            {
                freeIndexPool.Push(args.Offset);
                args.SetBuffer(null, 0, 0);
            }
        }

        /// <summary>
        /// The number of available objects in the pool.
        /// </summary>
        public int Available
        {
            get
            {
                lock (freeIndexPool)
                {
                    return ((totalBytes - currentIndex) / bufferSize) + freeIndexPool.Count;
                }
            }
        }
    }
}
