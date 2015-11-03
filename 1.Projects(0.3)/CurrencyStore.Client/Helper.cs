using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Client
{
    public static class Helper
    {
        private static int[] CurrencyFaceAmount = { 1, 5, 10, 20, 50, 100 };

        public static Random CurrentRandom
        {
            get;
            set;
        }
        static Helper()
        {
            Helper.CurrentRandom = new Random();
        }
        public static byte[] GetBytes(this DateTime date)
        {
            var buff = new byte[6];
            buff[0] = (byte)(date.Year % 2000);
            buff[1] = (byte)(date.Month);
            buff[2] = (byte)(date.Day);
            buff[3] = (byte)(date.Hour);
            buff[4] = (byte)(date.Minute);
            buff[5] = (byte)(date.Second);
            return buff;
        }
        public static byte[] GetBytes(this int value)
        {
            return BitConverter.GetBytes((short)value).Reverse().ToArray();
        }
        public static byte[] GetCurrencyFaceAmount()
        {
            return Helper.CurrencyFaceAmount[Helper.CurrentRandom.Next(0, Helper.CurrencyFaceAmount.Length)].GetBytes();
        }
    }
}
