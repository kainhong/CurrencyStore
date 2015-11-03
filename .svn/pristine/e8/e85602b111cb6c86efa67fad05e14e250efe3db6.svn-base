using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Utility;

namespace CurrencyStore.Client
{
    public static class Helper
    {
        private static object locker1 = new object();
        private static object locker2 = new object();

        private static readonly int[] CurrencyFaceAmount = { 1, 5, 10, 20, 50, 100 };
        private static readonly char[] CurrencyNumberFigure = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly char[] CurrencyNumberLetter = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

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
        public static byte[] GetBytes(this string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
        public static byte[] GetCurrencyFaceAmount()
        {
            lock (locker1)
            {
                return Helper.CurrencyFaceAmount[ThreadSafeRandom.Next(0, Helper.CurrencyFaceAmount.Length)].GetBytes();
            }
        }
        public static byte[] GetCurrencyNumber()
        {
            lock (locker2)
            {
                char[] result = new char[13];

                for (int i = 0; i < 2; i++)
                {
                    result[i] = Helper.CurrencyNumberLetter[ThreadSafeRandom.Next(0, Helper.CurrencyNumberLetter.Length)];
                }

                for (int i = 2; i < 13; i++)
                {
                    result[i] = Helper.CurrencyNumberFigure[ThreadSafeRandom.Next(0, Helper.CurrencyNumberFigure.Length)];
                }

                return new string(result).GetBytes();
            }
        }
    }
}
