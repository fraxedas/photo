using System.Drawing;
using System.Linq;
using System.Text;

namespace photo
{
    public class Parser
    {
        public string Parse(string path)
        {
            // Create an Image object. 
            var theImage = new Bitmap(path);

            // Get the PropertyItems property from image.
            var propItems = theImage.PropertyItems.Select(x=>x.ConvertTo());

            var builder = new StringBuilder();

            foreach (var item in propItems)
            {
                builder.AppendLine(string.Format("{0} - {1} = {2}", item.Id.ToString("X"), item.Title, item.Value));
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