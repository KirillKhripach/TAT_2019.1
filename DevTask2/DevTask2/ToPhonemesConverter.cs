using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevTask2
{
    class ToPhonemesConverter
    {
        private StringBuilder processedString;

        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public ToPhonemesConverter(string[] inputString)
        {
            processedString = new StringBuilder();
            foreach (string word in inputString)
            {
                processedString.Append(word.ToLower()).Append(" ");
            }
            processedString.Remove(processedString.Length - 1, 1);
            ValidationCheker validationCheker = new ValidationCheker(processedString);
            validationCheker.Check();
        }

        private readonly string consonantsString = "бвгджзйклмнпрстфхцчшщ";
        private Dictionary<string, string> vowelConverter = new Dictionary<string, string>
        {
            ["е"] = "э",
            ["ё"] = "о",
            ["ю"] = "у",
            ["я"] = "а"
        };
        private Dictionary<string, string> ringingToDeafConverter = new Dictionary<string, string>
        {
            ["б"] = "п",
            ["в"] = "ф",
            ["г"] = "к",
            ["д"] = "т",
            ["ж"] = "ш",
            ["з"] = "с"
        };

        /// <summary>
        /// Converts to phenomes
        /// </summary>
        /// <returns>Converted string</returns>
        public StringBuilder ConvertToPhenomes()
        {
            if (processedString.ToString().Contains("+") || processedString.ToString().Contains("ё"))
            {
                for (int i = 0; i < processedString.Length - 1; i++)
                {
                    if (processedString[i] == 'о' && processedString[i + 1] != '+')
                    {
                        processedString.Replace('о', 'а', i, 1);
                    }
                }
                processedString.Replace('о', 'а', processedString.Length - 1, 1);
            }
            processedString.Replace("+", string.Empty);
            processedString.Replace('ь', '\'');

            foreach (KeyValuePair<string, string> keyValue in vowelConverter)
            {
                processedString.Replace(keyValue.Key, $"й{keyValue.Value}", 0, 1);
                for (int i = 1; i < processedString.Length; i++)
                {
                    if (consonantsString.Contains(processedString[i - 1]))
                    {
                        processedString.Replace(keyValue.Key, $"'{keyValue.Value}", i, 1);
                    }
                    else
                    {
                        processedString.Replace(keyValue.Key, $"й{keyValue.Value}", i, 1);
                    }
                }
            }
            processedString.Replace("ъ", string.Empty);

            foreach (KeyValuePair<string, string> keyValue in ringingToDeafConverter)
            {
                processedString.Replace($"{keyValue.Key} ", $"{keyValue.Value} ");
                processedString.Replace($"{keyValue.Key}' ", $"{keyValue.Value}' ");
                processedString.Replace(keyValue.Key, keyValue.Value, processedString.Length - 1, 1);

                if (processedString.Length > 1)
                {
                    processedString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", processedString.Length - 2, 2);

                    if (ringingToDeafConverter.ContainsValue(processedString[1].ToString()))
                    {
                        processedString.Replace(keyValue.Key, keyValue.Value, 0, 1);
                    }
                    if (ringingToDeafConverter.ContainsKey(processedString[1].ToString()))
                    {
                        processedString.Replace(keyValue.Value, keyValue.Key, 0, 1);
                    }

                    if (processedString.Length > 2)
                    {
                        if (ringingToDeafConverter.ContainsValue(processedString[2].ToString()))
                        {
                            processedString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", 0, 2);
                        }
                        if (ringingToDeafConverter.ContainsKey(processedString[2].ToString()))
                        {
                            processedString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", 0, 2);
                        }
                    }

                    for (int i = 1; i < processedString.Length - 1; i++)
                    {
                        if (ringingToDeafConverter.ContainsValue(processedString[i + 1].ToString()))
                        {
                            processedString.Replace(keyValue.Key, keyValue.Value, i, 1);
                            processedString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", i - 1, 2);
                        }
                    }
                    for (int i = 1; i < processedString.Length - 1; i++)
                    {
                        if (ringingToDeafConverter.ContainsKey(processedString[i + 1].ToString()))
                        {
                            processedString.Replace(keyValue.Value, keyValue.Key, i, 1);
                            processedString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", i - 1, 2);
                        }
                    }
                }
            }

            return processedString;
        }
    }
}
