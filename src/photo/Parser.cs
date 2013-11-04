using System;
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
    }
}