﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common
{
    public static class Helper
    {
        public static byte[] ToBytes(this string data)
        {
            if ((data.Length % 2) != 0)
            {
                throw new ArgumentException("invalid value");
            }

            var buff = new byte[data.Length / 2];

            buff = new byte[data.Length / 2];
            for (int i = 0; i < buff.Length; i++)
            {
                var val = "0x" + data[i * 2] + data[i * 2 + 1];
                buff[i] = (byte)Convert.ToInt16(val, 16);
            }
            return buff;
        }

        public static string ToHexString(this byte[] bytes, int index = 0, int length = 0)
        {
            string returnStr = "";

            if (length == 0)
            {
                length = bytes.Length;
            }

            if (bytes != null)
            {
                for (int i = index; i < index + length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }

            return returnStr;
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

        public static short ReadShort(this byte[] buffer, int index)
        {
            byte[] vals = new byte[2];
            vals[0] = buffer[index + 1];
            vals[1] = buffer[index];
            return BitConverter.ToInt16(vals, 0);
        }

        public static int ReadInt32(this byte[] buffer, int index)
        {
            byte[] vals = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                vals[i] = buffer[index + i];
            }
            Array.Reverse(vals);
            return BitConverter.ToInt32(vals, 0);
        }

        public static void WriteShort(this BinaryWriter sw, short val)
        {
            var vals = BitConverter.GetBytes(val);
            Array.Reverse(vals);
            sw.Write(vals);
        }

        public static string GetString(this byte[] buff, int index, int count)
        {
            return new string(System.Text.ASCIIEncoding.ASCII.GetChars(buff, index, count));
        }

        public static string GetByteString(this byte[] buffer, int index, int count)
        {
            var val = string.Empty;

            for (int i = index; i < index + count; i++)
            {
                var b = buffer[i];
                val += b.ToString();
            }

            return val;
        }

        public static byte[] GetBytes(this short val)
        {
            var vals = BitConverter.GetBytes(val);
            Array.Reverse(vals);
            return vals;
        }

        public static string CheckAsciiChar(this string val)
        {
            string result = null;

            foreach (var c in val)
            {
                int ascii = (int)c;

                if ((ascii >= 48 && ascii <= 58) || (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
                {
                    result += c;
                }

                else
                {
                    result += "#";
                }
            }

            return result;
        }
    }
}
