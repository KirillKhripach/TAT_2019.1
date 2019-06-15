using System;
using NUnit.Framework;
using DevTask2;

namespace DevTask2Tests
{
    [TestFixture]
    public class ValidationChekerTest
    {
        [TestCase("подъе+зд")]
        [TestCase("ёлка")]
        [TestCase("смерть")]
        [TestCase("моло+тьба")]
        public void CheckWordTest(string inputString)
        {
            ValidationCheker cheker = new ValidationCheker(inputString);
            var actual = cheker.Check();
            Assert.IsTrue(actual);
        }

        [TestCase("+Артём")]
        [TestCase("Мо+ло+ко+")]
        [TestCase("вр+ед")]
        [TestCase("уупс")]
        public void CheckIncorrectWordWordTest(string inputString)
        {
            ValidationCheker cheker = new ValidationCheker(inputString);
            Assert.Throws<Exception>(() => cheker.Check());
        }

        [TestCase(null)]
        public void CheckNullTest(string inputString)
        {
            Assert.Throws<NullReferenceException>(() => new ValidationCheker(inputString));
        }
    }
}
