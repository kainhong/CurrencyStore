using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CurrencyStore.Collector
{
    public sealed class SocketAsyncEventArgsPool
    {
        private Stack<SocketAsyncEventArgs> SocketAsyncEventArgsList { get; set; }

        public SocketAsyncEventArgsPool()
        {
            this.SocketAsyncEventArgsList = new Stack<SocketAsyncEventArgs>();
        }

        public SocketAsyncEventArgs Get()
        {
            lock (this.SocketAsyncEventArgsList)
            {
                if (this.SocketAsyncEventArgsList.Count > 0)
                {
                    return this.SocketAsyncEventArgsList.Pop();
                }

                else
                {
                    return null;
                }
            }
        }

        public void Set(SocketAsyncEventArgs item)
        {
            if (item != null)
            {
                lock (this.SocketAsyncEventArgsList)
                {
                    this.SocketAsyncEventArgsList.Push(item);
                }
            }
        }
    }
}
