using System;
using NUnit.Framework;
using DevTask2;

namespace DevTask2Tests
{
    [TestFixture]
    public class ToPhonemesConverterTest
    {
        [TestCase("подъе+зд", "падйэст")]
        [TestCase("ёлка", "йолка")]
        [TestCase("смерть", "см'эрт'")]
        [TestCase("моло+тьба", "малод'ба")]
        public void ConvertWordTest(string inputString, string expectedString)
        {
            ToPhonemesConverter converter = new ToPhonemesConverter(inputString);
            var actual = converter.ConvertToPhenomes();
            Assert.AreEqual(expectedString, actual);
        }

        [TestCase("а+")]
        [TestCase("я")]
        public void ConvertLessThenTwoLettersTest(string inputString)
        {
            Assert.Throws<Exception>(() => new ToPhonemesConverter(inputString));
        }

        [TestCase("мёди+к")]
        [TestCase("иг+олка")]
        [TestCase("мо+ло+ко")]
        [TestCase("почта")]
        [TestCase("клмн")]
        public void ConvertIncorrectWordTest(string inputString)
        {
            Assert.Throws<Exception>(() => new ToPhonemesConverter(inputString));
        }

        [TestCase("brain")]
        [TestCase("word")]
        [TestCase("#53")]
        public void ConvertNonCyrillicSymbolsTest(string inputString)
        {
            Assert.Throws<Exception>(() => new ToPhonemesConverter(inputString));
        }

        [TestCase(null)]
        public void ConvertNullTest(string inputString)
        {
            Assert.Throws<NullReferenceException>(() => new ToPhonemesConverter(inputString));
        }
    }
}
