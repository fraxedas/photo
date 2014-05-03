using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace photo.exif.unit.test
{
    [TestFixture("Images/Canon PowerShot SX500 IS.JPG")]
    [TestFixture("Images/Nikon COOLPIX P510.JPG")]
    [TestFixture("Images/Panasonic Lumix DMC-FZ200.JPG")]
    [TestFixture("Images/Samsung SIII.jpg")]
    public class ParserTest
    {
        public ParserTest(string path)
        {
            _path = path;
            _parser = new Parser();
        }

        private readonly string _path;
        private readonly Parser _parser;

        [Test]
        public void Test_parse_path_return_some_data()
        {
            var data = _parser.Parse(_path);
            data.ToList().ForEach(Console.WriteLine);
            Assert.That(data, Is.Not.Null);
            Assert.That(data, Is.Not.Empty);
        }

        [Test]
        public void Test_parse_stream_return_some_data()
        {
            var data = _parser.Parse(new FileStream(_path,FileMode.Open));
            data.ToList().ForEach(Console.WriteLine);
            Assert.That(data, Is.Not.Null);
            Assert.That(data, Is.Not.Empty);
        }
    }
}