using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using ExifLib;

namespace photo
{
    public class Parser
    {
        public string Parse(string path)
        {
            var reader = new ExifReader(path);
            var builder = new StringBuilder();

            foreach (object value in Enum.GetValues(typeof (ExifTags)))
            {
                object tag;
                if (reader.GetTagValue((ExifTags) value, out tag))
                {
                    builder.AppendLine(string.Format("{0}={1}", value, tag));
                }
            }

            return builder.ToString();
        }

        public string Parse2(string path)
        {
            // Create an Image object. 
            var theImage = new Bitmap(path);

            // Get the PropertyItems property from image.
            PropertyItem[] propItems = theImage.PropertyItems;

            var builder = new StringBuilder();

            foreach (PropertyItem item in propItems)
            {
                builder.AppendLine(string.Format("{0} = {1}", item.Id, item.Value.ConvertTo((ExifType)item.Type, item.Len)));
            }

            return builder.ToString();
        }

        public string ConvertTo(byte[] ascii)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetString(ascii);
        }
    }
}