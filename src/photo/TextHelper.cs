using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace photo
{
    public class TextHelper
    {
        private const string Pattern = @"(?<title>^.+)(\r\n)(?<description>^.+)(\r\n)(?<id>^.+)(\r\n)(?<type>^.+)(\r\n)(?<lenght>^.+)(\s){1,2}";

        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Multiline);

        public static List<ExifItem> GetItems()
        {
            var result = new List<ExifItem>();
            foreach (Match match in Regex.Matches(Properties.Resources.Tags))
            {
                var title = match.Groups["title"];
                var description = match.Groups["description"];
                var id = match.Groups["id"];

                var exif = new ExifItem
                               {
                                   Title = title.Value,
                                   Description = description.Value,
                                   Id = int.Parse(id.Value.Substring(2), NumberStyles.HexNumber)
                               };
                result.Add(exif);
            }

            return result;
        }

    }
}