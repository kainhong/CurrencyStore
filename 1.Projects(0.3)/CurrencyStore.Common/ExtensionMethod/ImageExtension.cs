using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class ImageExtension
    {
        public static void AdjustQuality(this Bitmap target, MemoryStream objMemoryStream, int quality)
        {
            target.Save(objMemoryStream, ImageExtension.GetEncoderInfo("JPEG"), ImageExtension.GetEncoderParameters(quality));
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return (from item in ImageCodecInfo.GetImageEncoders() where item.FormatDescription.ToLower().Equals(mimeType.ToLower()) select item).FirstOrDefault();
        }
        private static EncoderParameters GetEncoderParameters(int quality)
        {
            EncoderParameters result = new EncoderParameters(1);

            result.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            return result;
        }
    }
}
