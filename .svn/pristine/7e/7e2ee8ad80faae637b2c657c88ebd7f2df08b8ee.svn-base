using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace CurrencyStore.BatchInsert
{
    public static class DataCounter
    {
        private static int CurrencyCounter;
               
        public static int CurrencyCount
        {
            get { return DataCounter.CurrencyCounter; }
        }
        static DataCounter()
        {
            DataCounter.Reset();
        }
        public static void AddCurrency(int count)
        {
            Interlocked.Add(ref DataCounter.CurrencyCounter, count);
        }
        public static void Reset()
        {
            DataCounter.CurrencyCounter = 0;
        }
    }
}
