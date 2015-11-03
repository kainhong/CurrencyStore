using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class HexExtension
    {
        public static char ToChar(this sbyte target)
        {
            return (char)target;
        }
        public static string ToHexString(this byte[] target)
        {
            string result = null;

            if (target != null)
            {
                for (int i = 0; i < target.Length; i++)
                {
                    result += target[i].ToString("X2");
                }
            }

            return result;
        }
        public static bool GetBit(this byte target, int index)
        {
            return (target & (1 << index)) > 0;
        }
        public static byte[] ToBitmap(this byte[] target, byte type)
        {
            byte[] result = null;

            int width = 0;
            int height = 0;

            if (type == 0)
            {
                return result;
            }

            else if (type == 1)
            {
                width = 120;
                height = 24;
            }

            else if (type == 2)
            {
                width = 120;
                height = 16;
            }

            else if (type == 3)
            {
                width = 60;
                height = 16;
            }

            List<Color> source = new List<Color>();

            foreach (byte item in target)
            {
                for (int i = 7; i >= 0; i--)
                {
                    source.Add(item.GetBit(i) ? Color.Black : Color.White);
                }
            }

            Bitmap image = new Bitmap(width, height);

            int index = 0;

            for (int column = 0; column < width; column++)
            {
                for (int row = 0; row < height; row++)
                {
                    image.SetPixel(column, row, source[index]);

                    index += 1;
                }
            }

            using (MemoryStream objMS = new MemoryStream())
            {
                image.AdjustQuality(objMS, 25);

                result = objMS.ToArray();
            }

            return result;
        }
    }
}
