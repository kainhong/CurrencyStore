using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public static class StringExtension
    {
        public static int ToInt(this string target)
        {
            int result = default(int);

            int.TryParse(target, out result);

            return result;
        }
        public static byte[] ToAsciiByte(this string target)
        {
            return Encoding.ASCII.GetBytes(target);
        }
    }

    public static class IntExtension
    {
        public static byte[] ToBytes(this short target)
        {
            return BitConverter.GetBytes(target).Reverse().ToArray();
        }
        public static byte[] ToBytes(this int target)
        {
            return BitConverter.GetBytes(target).Reverse().ToArray();
        }
    }

    public static class ByteExtension
    {
        public static string ToText(this byte[] target)
        {
            return BitConverter.ToString(target);
        }
        public static short ToInt16(this byte[] target)
        {
            return BitConverter.ToInt16(target.Reverse().ToArray(), 0);
        }
        public static byte[] Read(this byte[] target, int startIndex, int length)
        {
            byte[] result = new byte[length];

            Array.Copy(target, startIndex, result, 0, length);

            return result;
        }
        public static byte[] Merge(this byte[] target, byte[] secondArray)
        {
            return target.Concat(secondArray).ToArray();
        }
        public static short Sum(this byte[] target)
        {
            short result = 0;

            foreach (byte item in target)
            {
                result += item;
            }

            return result;
        }
    }

    public static class Unity
    {
        public static byte[] GetDatagramLengthHex(this short target)
        {
            return target.ToBytes();
        }
        public static byte[] GetDeviceNumberHex(this string target)
        {
            string charPart = target.Substring(0, 4);
            int numberPart = target.Substring(4).ToInt();

            return charPart.ToAsciiByte().Merge(numberPart.ToBytes());
        }
    }
}
