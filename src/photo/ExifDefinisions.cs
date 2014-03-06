using System;
using System.Text;

namespace photo
{
    public enum ExifId
    {
        ImageTitle = 0x0320,
        EquipmentManufacturer = 0x010F,
        EquipmentModel = 0x0110,
        ExifDTOriginal = 0x9003,
        ExifExposureTime = 0x829A,
        LuminanceTable = 0x5090,
        ChrominanceTable = 0x5091
    }

    public enum ExifType
    {
        Byte = 1,
        String = 2,
        UInt16 = 3,
        UInt32 = 4,
        URational = 5,
        Object = 6,
        Int32 = 7,
        Long = 9,
        Rational = 10
    }

    public struct URational
    {
        public ulong Denominator;
        public ulong Numerator;
    }

    public struct Rational
    {
        public long Denominator;
        public long Numerator;
    }

    public static class Converter
    {
        public static object ConvertTo(this byte[] bytes, ExifType type)
        {
            switch (type)
            {
                case ExifType.Byte:
                    return bytes;
                case ExifType.String:
                    return Encoding.ASCII.GetString(bytes);
                case ExifType.UInt16:
                    return BitConverter.ToUInt16(bytes, 0);
                case ExifType.UInt32:
                    return BitConverter.ToUInt32(bytes, 0);
                case ExifType.URational:
                    return new URational
                               {
                                   Denominator = BitConverter.ToUInt32(bytes,0),
                                   Numerator = BitConverter.ToUInt32(bytes,4)
                               };
                case ExifType.Object:
                    return bytes;
                case ExifType.Int32:
                    return BitConverter.ToInt32(bytes, 0);
                case ExifType.Long:
                    return BitConverter.ToInt64(bytes, 0);
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
    }
}