using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace CurrencyStore.Communication
{
    /// <summary>
    /// Pools SocketAsyncEventArgs objects to avoid repeated allocations.
    /// </summary>
    public class SocketArgsPool : IDisposable
    {
        Stack<SocketAsyncEventArgs> argsPool;

        /// <summary>
        /// Pools SocketAsyncEventArgs objects to avoid repeated allocations.
        /// </summary>
        /// <param name="capacity">The ammount to SocketAsyncEventArgs to create and pool.</param>
        public SocketArgsPool(Int32 capacity)
        {
            argsPool = new Stack<SocketAsyncEventArgs>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                CheckIn(new SocketAsyncEventArgs());
            }
        }

        /// <summary>
        /// Checks an SocketAsyncEventArgs back into the pool.
        /// </summary>
        /// <param name="item">The SocketAsyncEventsArgs to check in.</param>
        public void CheckIn(SocketAsyncEventArgs item)
        {
            lock (argsPool)
            {
                argsPool.Push(item);
            }
        }

        /// <summary>
        /// Check out an SocketAsyncEventsArgs from the pool.
        /// </summary>
        /// <returns>The SocketAsyncEventArgs.</returns>
        public SocketAsyncEventArgs CheckOut()
        {
            lock (argsPool)
            {
                return argsPool.Pop();
            }
        }

        /// <summary>
        /// The number of available objects in the pool.
        /// </summary>
        public int Available
        {
            get
            {
                lock (argsPool)
                {
                    return argsPool.Count;
                }
            }
        }

        #region IDisposable Members
        private Boolean disposed = false;

        ~SocketArgsPool()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    foreach (SocketAsyncEventArgs args in argsPool)
                    {
                        args.Dispose();
                    }
                }

                disposed = true;
            }
        }
        #endregion
    }
}
