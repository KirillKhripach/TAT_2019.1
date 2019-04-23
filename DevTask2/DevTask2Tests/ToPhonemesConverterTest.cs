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
        public void Convert_Word_ReturnsPhonemes(string inputString, string expectedString)
        {
            ToPhonemesConverter converter = new ToPhonemesConverter(inputString);
            var actual = converter.ConvertToPhenomes();
            Assert.AreEqual(expectedString, actual);
        }

        [TestCase("а+")]
        [TestCase("я")]
        public void Convert_LessThenTwoLetters_ThrowsArgumentOutOfRangeException(string inputString)
        {
            ToPhonemesConverter converter = new ToPhonemesConverter(inputString);
            Assert.Throws<Exception>(() => converter.ConvertToPhenomes());
        }

        [TestCase("мёди+к")]
        [TestCase("иг+олка")]
        [TestCase("мо+ло+ко")]
        [TestCase("почта")]
        [TestCase("клмн")]
        public void Convert_IncorrectWord_ThrowsException(string inputString)
        {
            Assert.Throws<Exception>(() => new ToPhonemesConverter(inputString));
        }

        [TestCase("brain")]
        [TestCase("word")]
        [TestCase("#53i")]
        public void Convert_NonCyrillicSymbols_ThrowsException(string inputString)
        {
            Assert.Throws<Exception>(() => new ToPhonemesConverter(inputString));
        }

        [TestCase]
        public void Convert_Null_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new ToPhonemesConverter(null));
        }
    }
}
