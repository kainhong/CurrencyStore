using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CurrencyStore.Utility
{
    public class ThreadSafeRandom
    {
        private static readonly ThreadLocal<Random> appRandom = new ThreadLocal<Random>(() => new Random());

        public static int GetRandomNumber()
        {
            return appRandom.Value.Next();
        }

        public static double NextDouble()
        {
            return appRandom.Value.NextDouble();
        }

        public static int Next()
        {
            return appRandom.Value.Next();
        }

        public static int Next(int max)
        {
            return appRandom.Value.Next(max);
        }

        public static void NextBytes(byte[] buffer)
        {
            appRandom.Value.NextBytes(buffer);
        }

        public static int Next(int min, int max)
        {
            return appRandom.Value.Next(min, max);
        }
    }
}
