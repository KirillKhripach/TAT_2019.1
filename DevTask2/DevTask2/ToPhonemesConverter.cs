using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevTask2
{
    /// <summary>
    /// Class for converting word to phonemes
    /// </summary>
    public class ToPhonemesConverter
    {
        public StringBuilder ProcessedString { get; private set; }
        private readonly string _vowelsString = "аиоуыэеёюя";
        private readonly string _consonantsString = "бвгджзйклмнпрстфхцчшщ";

        private readonly Dictionary<string, string> _vowelConverter = new Dictionary<string, string>
        {
            ["е"] = "э",
            ["ё"] = "о",
            ["ю"] = "у",
            ["я"] = "а"
        };

        private readonly Dictionary<string, string> _ringingToDeafConverter = new Dictionary<string, string>
        {
            ["б"] = "п",
            ["в"] = "ф",
            ["г"] = "к",
            ["д"] = "т",
            ["ж"] = "ш",
            ["з"] = "с"
        };

        /// <summary>
        /// Constructor validates input string and initializes properties
        /// </summary>
        /// <param name="inputString">String for converting</param>
        public ToPhonemesConverter(string inputString)
        {
            string lowerString = inputString.ToLower() ?? throw new NullReferenceException("String is null");

            if (lowerString.Replace("+", string.Empty).Length < 2)
            {
                throw new Exception("The word should contains at least two letters");
            }

            CyrillicCheker cyrillicCheker = new CyrillicCheker(lowerString);
            cyrillicCheker.Check();
            ValidationCheker validationCheker = new ValidationCheker(lowerString);
            validationCheker.Check();
            this.ProcessedString = new StringBuilder(lowerString);
        }

        /// <summary>
        /// Converts to phonemes by calling conversion methods
        /// </summary>
        /// <returns>Converted string</returns>
        public string ConvertToPhenomes()
        {
            this.VowelToPhonemes();
            this.OLetterToPhonemes();
            this.OtherSymbolsToPhonemes();
            this.RingingToPhonemes();
            this.DeafToPhonemes();

            return this.ProcessedString.ToString();
        }

        /// <summary>
        /// Converts vowels to phonemes according to previous letter
        /// </summary>
        private void VowelToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this._vowelConverter)
            {
                this.ProcessedString.Replace(keyValue.Key, $"й{keyValue.Value}", 0, 1);

                for (int i = 1; i < this.ProcessedString.Length; i++)
                {
                    if (this._consonantsString.Contains(this.ProcessedString[i - 1]))
                    {
                        this.ProcessedString.Replace(keyValue.Key, $"'{keyValue.Value}", i, 1);
                    }
                    else
                    {
                        this.ProcessedString.Replace(keyValue.Key, $"й{keyValue.Value}", i, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Converts letter 'о' to phonemes according to previous letter,
        /// Count of vowels and stress
        /// </summary>
        private void OLetterToPhonemes()
        {
            bool impactLetter = this.ProcessedString.ToString().Contains("о+");
            int vowelsCount = 0;
            char lastVowel = new char();

            if (this.ProcessedString[0] == 'о')
            {
                this.ProcessedString.Replace('о', 'а', 0, 1);
                vowelsCount++;
                lastVowel = 'о';
            }

            for (int i = 1; i < this.ProcessedString.Length; i++)
            {
                if (this._vowelsString.Contains(this.ProcessedString[i]))
                {
                    vowelsCount++;
                    lastVowel = this.ProcessedString[i];
                }

                if (this.ProcessedString[i - 1] != 'й' && this.ProcessedString[i - 1] != '\'')
                {
                    this.ProcessedString.Replace('о', 'а', i, 1);
                }
            }

            if (vowelsCount == 1 && lastVowel == 'о')
            {
                this.ProcessedString.Replace('а', 'о');
            }

            if (impactLetter)
            {
                this.ProcessedString.Replace("а+", "о+");
            }
        }

        /// <summary>
        /// Converts '+', 'ь' and 'ъ' to phonemes
        /// </summary>
        private void OtherSymbolsToPhonemes()
        {
            this.ProcessedString.Replace("+", string.Empty);
            this.ProcessedString.Replace('ь', '\'');
            this.ProcessedString.Replace("ъ", string.Empty);
        }

        /// <summary>
        /// Converts ringing consonants to phonemes according to their position
        /// On the end of word or before deaf letters
        /// </summary>
        private void RingingToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this._ringingToDeafConverter)
            {
                this.ProcessedString.Replace(keyValue.Key, keyValue.Value, this.ProcessedString.Length - 1, 1);
                this.ProcessedString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", this.ProcessedString.Length - 2, 2);

                if (this._ringingToDeafConverter.ContainsValue(this.ProcessedString[1].ToString()))
                {
                    this.ProcessedString.Replace(keyValue.Key, keyValue.Value, 0, 1);
                }

                for (int i = 1; i < this.ProcessedString.Length - 1; i++)
                {
                    if (this._ringingToDeafConverter.ContainsValue(this.ProcessedString[i + 1].ToString()))
                    {
                        this.ProcessedString.Replace(keyValue.Key, keyValue.Value, i, 1);
                        this.ProcessedString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", i - 1, 2);
                    }
                }
            }
        }

        /// <summary>
        /// Converts deaf consonants to phonemes according to their position
        /// Before ringing letters
        /// </summary>
        private void DeafToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this._ringingToDeafConverter)
            {
                if (this._ringingToDeafConverter.ContainsKey(this.ProcessedString[1].ToString()))
                {
                    this.ProcessedString.Replace(keyValue.Value, keyValue.Key, 0, 1);
                }

                for (int i = 1; i < this.ProcessedString.Length - 1; i++)
                {
                    if (this._ringingToDeafConverter.ContainsKey(this.ProcessedString[i + 1].ToString()))
                    {
                        this.ProcessedString.Replace(keyValue.Value, keyValue.Key, i, 1);
                        this.ProcessedString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", i - 1, 2);
                    }
                }
            }
        }
    }
}
