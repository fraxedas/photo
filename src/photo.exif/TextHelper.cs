using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace photo.exif
{
    public class TextHelper
    {
        private const string Pattern = @"(?<title>^.+)(\r\n)(?<description>^.+)(\r\n)(?<id>^.+)(\r\n)(?<type>^.+)(\r\n)(?<lenght>^.+)(\s){2}";

        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Multiline);

        public static IEnumerable<ExifItem> GetItems()
        {
            return (from Match match in Regex.Matches(Properties.Resources.Tags)
                    let title = match.Groups["title"]
                    let description = match.Groups["description"]
                    let id = match.Groups["id"]
                    select new ExifItem
                               {
                                   Title = title.Value, 
                                   Description = description.Value, 
                                   Id = int.Parse(id.Value.Substring(2), NumberStyles.HexNumber)
                               });
        }
    }
}