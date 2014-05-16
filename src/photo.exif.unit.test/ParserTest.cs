using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace photo.exif.unit.test
{
    public class ParserTest
    {
        public ParserTest()
        {
            _parser = new Parser();
        }

        private readonly Parser _parser;

        static string[] paths = Directory.GetFiles( Environment.CurrentDirectory, "*.jpg", SearchOption.AllDirectories);

        [Test, TestCaseSource("paths")]
        public void Test_parse_path_return_some_data(string path)
        {
            var data = _parser.Parse(path);
            data.ToList().ForEach(Console.WriteLine);
            Assert.That(data, Is.Not.Null);
            Assert.That(data, Is.Not.Empty);
        }

        [Test, TestCaseSource("paths")]
        public void Test_parse_stream_return_some_data(string path)
        {
            var data = _parser.Parse(new FileStream(path,FileMode.Open));
            data.ToList().ForEach(Console.WriteLine);
            Assert.That(data, Is.Not.Null);
            Assert.That(data, Is.Not.Empty);
        }
    }
}