using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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
            var propItems = theImage.PropertyItems.Select(x=>x.ConvertTo());

            var builder = new StringBuilder();

            foreach (var item in propItems)
            {
                builder.AppendLine(string.Format("{0} - {1} = {2}", item.Id, item.Title, item.Value));
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