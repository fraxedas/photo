using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace photo
{
    public class Parser
    {
        public IEnumerable<ExifItem> Parse(string path)
        {
            using(var theImage = new Bitmap(path))
            {
                return theImage.PropertyItems.Select(x => x.ConvertTo());
            }
        }

        public IEnumerable<ExifItem> Parse(Stream image)
        {
            using(var theImage = new Bitmap(image))
            {
                return theImage.PropertyItems.Select(x => x.ConvertTo());
            }
        }
    }
}