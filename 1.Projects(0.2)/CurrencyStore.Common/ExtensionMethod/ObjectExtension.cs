using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class ObjectExtension
    {
        public static T Convert<T>(this object target)
        {
            T result = default(T);

            result = (T)System.Convert.ChangeType(target, typeof(T), CultureInfo.InvariantCulture);

            return result;
        }
        public static T CloneObject<T>(this object target)
        {
            T result = default(T);

            using (MemoryStream objMemoryStream = new MemoryStream())
            {
                BinaryFormatter objBinaryFormatter = new BinaryFormatter
                (
                    null,
                    new StreamingContext(StreamingContextStates.Clone)
                );

                objBinaryFormatter.Serialize(objMemoryStream, target);

                objMemoryStream.Seek(0, SeekOrigin.Begin);

                result = (T)objBinaryFormatter.Deserialize(objMemoryStream);
            }

            return result;
        }
        public static bool IsNullOrEmpty<T>(this object target)
        {
            bool result = false;

            if (target == null)
            {
                result = true;
            }

            if (target.GetType() == typeof(string))
            {
                if ((target as string).IsNullOrEmpty())
                {
                    result = true;
                }
            }

            if (target.GetType() == typeof(DBNull))
            {
                result = true;
            }

            if (target.GetType() == typeof(Nullable))
            {
                result = true;
            }

            return result;
        }
        public static object GetPropertyValue(this object target, string propertyName)
        {
            object result = null;

            if (target != null)
            {
                result = target.GetType().GetProperty(propertyName).GetValue(target, null);
            }

            return result;
        }
        public static T GetPropertyValue<T>(this object target, string propertyName)
        {
            return (T)GetPropertyValue(target, propertyName);
        }
        public static bool InRange(this IComparable target, object min, object max)
        {
            return target.CompareTo(min) >= 0 && target.CompareTo(max) <= 0;
        }
        public static bool InRange<T>(this IComparable<T> target, T min, T max)
        {
            return target.CompareTo(min) >= 0 && target.CompareTo(max) <= 0;
        }
        public static string ToXml<T>(this object target)
        {
            StringBuilder result = new StringBuilder();

            {
                XmlSerializer objXmlSerializer = new XmlSerializer(typeof(T));

                using (XmlWriter objXmlWriter = XmlWriter.Create(result))
                {
                    objXmlSerializer.Serialize(objXmlWriter, target);
                }
            }

            return result.ToString();
        }
        public static string ToBinary<T>(this object target)
        {
            StringBuilder result = new StringBuilder();

            {
                BinaryFormatter objBinaryFormatter = new BinaryFormatter();

                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    objBinaryFormatter.Serialize(objMemoryStream, target);

                    objMemoryStream.Position = 0;

                    byte[] bytes = objMemoryStream.ToArray();

                    foreach (byte bt in bytes)
                    {
                        result.Append(string.Format("{0:X2}", bt));
                    }
                }
            }

            return result.ToString();
        }
        public static string ToString(this object target, string defaultValue)
        {
            return target == null ? defaultValue : target.ToString();
        }
    }
}
