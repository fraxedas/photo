using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace photo
{
    public class TextHelper
    {
        private const string Pattern = @"(?<title>^.+$)(?<description>^.+$)";

        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Multiline);

        public static List<ExifItem> GetItems()
        {
            var result = new List<ExifItem>();
            foreach (Match match in Regex.Matches(Properties.Resources.Tags))
            {
                var title = match.Groups[1];
                var description = match.Groups[2];
                var id = match.Groups[3];

                var exif = new ExifItem
                               {
                                   Title = title.Value,
                                   Description = description.Value,
                                   Id = int.Parse(id.Value)
                               };
                result.Add(exif);
            }

            return result;
        }

    }
}