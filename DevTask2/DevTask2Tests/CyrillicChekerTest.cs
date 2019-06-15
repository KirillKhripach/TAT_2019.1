using System;
using NUnit.Framework;
using DevTask2;

namespace DevTask2Tests
{
    [TestFixture]
    public class CyrillicChekerTest
    {
        [TestCase("подъе+зд")]
        [TestCase("Ёлка")]
        [TestCase("")]
        public void CheckWordTest(string inputString)
        {
            CyrillicCheker cheker = new CyrillicCheker(inputString);
            var actual = cheker.Check();
            Assert.IsTrue(actual);
        }

        [TestCase("az")]
        [TestCase("ooor")]
        [TestCase("а-ф")]
        public void CheckNoncyrillicLettersTest(string inputString)
        {
            CyrillicCheker cheker = new CyrillicCheker(inputString);
            Assert.Throws<Exception>(() => cheker.Check());
        }

        [TestCase(null)]
        public void CheckNullTest(string inputString)
        {
            Assert.Throws<NullReferenceException>(() => new CyrillicCheker(inputString));
        }
    }
}
