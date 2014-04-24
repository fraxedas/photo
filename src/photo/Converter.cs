using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace photo
{
    public static class Converter
    {
        public static Dictionary<int, KeyValuePair<string, string>> IdNameDescription = new Dictionary
            <int, KeyValuePair<string, string>>
                                                                                            {
                                                                                                {
                                                                                                    0x0132,
                                                                                                    new KeyValuePair
                                                                                                    <string, string>(
                                                                                                    "DateTime",
                                                                                                    "Date and time the image was created")
                                                                                                }
                                                                                            };

        public static ExifItem ConvertTo(this PropertyItem item)
        {
            KeyValuePair<string, string> values;
            bool exist = IdNameDescription.TryGetValue(item.Id, out values);
            return new ExifItem
                       {
                           Id = item.Id,
                           Title = exist ? values.Key : null,
                           Description = exist ? values.Value : null,
                           Value = item.Value.ConvertTo((ExifType) item.Type, item.Len),
                       };
        }

        public static object ConvertTo(this byte[] bytes, ExifType type, int len)
        {
            switch (type)
            {
                case ExifType.Byte:
                    return bytes;
                case ExifType.String:
                    return Encoding.ASCII.GetString(bytes);
                case ExifType.UInt16:
                    return BitConverter.ToUInt16(bytes.Safe(2), 0);
                case ExifType.UInt32:
                    return BitConverter.ToUInt32(bytes.Safe(4), 0);
                case ExifType.URational:
                    return new URational
                               {
                                   Denominator = BitConverter.ToUInt32(bytes, 4),
                                   Numerator = BitConverter.ToUInt32(bytes, 0)
                               };
                case ExifType.Object:
                    return bytes;
                case ExifType.Int32:
                    return BitConverter.ToInt32(bytes.Safe(4), 0);
                case ExifType.Long:
                    return BitConverter.ToInt64(bytes.Safe(8), 0);
                case ExifType.Rational:
                    return new Rational
                               {
                                   Denominator = BitConverter.ToInt32(bytes, 0),
                                   Numerator = BitConverter.ToInt32(bytes, 4)
                               };

                default:
                    return bytes;
            }
        }

        public static byte[] Safe(this byte[] bytes, int minimun)
        {
            if (bytes.Length >= minimun) return bytes;

            var safe = new byte[minimun];
            bytes.CopyTo(safe, minimun - bytes.Length);
            return safe;
        }
    }
}