using System;
using NUnit.Framework;

namespace photo.unit.test
{
    [TestFixture]
    public class ParserTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _parser = new Parser();
        }

        #endregion

        private Parser _parser;

        [Test]
        public void Test_parse_return_same_data()
        {
            string data = _parser.Parse("Images/Canon PowerShot SX500 IS.JPG");
            Console.Out.WriteLine("data = {0}", data);
            Assert.That(data, Is.Not.Empty);
        }
    }
}