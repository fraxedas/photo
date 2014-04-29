using System;
using NUnit.Framework;

namespace photo.unit.test
{
    [TestFixture]
    public class TextHelperTest
    {
        [Test]
        public void Test_get_items()
        {
            var list = TextHelper.GetItems();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            foreach (var item in list)
            {
                Console.Out.WriteLine("{0} - {1} : {2}", item.Id, item.Title, item.Description);
            }
        }
    }
}