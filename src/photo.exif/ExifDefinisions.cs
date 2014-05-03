namespace photo.exif
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

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }

    public struct Rational
    {
        public long Denominator;
        public long Numerator;

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}