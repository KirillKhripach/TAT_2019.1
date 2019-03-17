using System;
using System.Linq;
using System.Text;

namespace DevTask2
{
    class ValidationCheker
    {
        private StringBuilder stringToCheck;
        private readonly string vowelsString = "аиоуыэеёюя";

        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public ValidationCheker(string[] inputString)
        {
            stringToCheck = new StringBuilder();
            foreach (string word in inputString)
            {
                stringToCheck.Append(word.ToLower()).Append(" ");
            }
            stringToCheck.Remove(stringToCheck.Length - 1, 1);
        }

        /// <summary>
        /// Checks for validation 
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            int plusCount = 0, yoCount = 0, vowelsCount = 0;
            int firstLetter = 0, lastLetter = stringToCheck.Length - 1;
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                switch (stringToCheck[i])
                {
                    case '+':
                        plusCount += 1;
                        break;
                    case 'ё':
                        yoCount += 1;
                        vowelsCount += 1;
                        break;
                    case ' ':
                        lastLetter = i - 1;
                        break;
                    default:
                        if (vowelsString.Contains(stringToCheck[i]))
                        {
                            vowelsCount += 1;
                        }
                        break;
                }
                if (stringToCheck[i] == ' ' || i == stringToCheck.Length - 1)
                {
                    if (vowelsCount == 0)
                    {
                        throw new Exception("Lack of vowels");
                    }
                    if (plusCount == 0 && yoCount == 0 && vowelsCount != 1)
                    {
                        throw new Exception("Lack of plus");
                    }
                    if (plusCount > 1)
                    {
                        throw new Exception("Too many pluses");
                    }
                    if (stringToCheck[firstLetter] == '+')
                    {
                        throw new Exception("Incorrect plus position");
                    }
                    for (; firstLetter <= lastLetter; firstLetter++)
                    {
                        
                        if (stringToCheck[firstLetter] == '+')
                        {
                            if (!vowelsString.Contains(stringToCheck[firstLetter - 1]))
                            {
                                throw new Exception("Incorrect plus position");
                            }
                            else
                            {
                                if (yoCount > 0 && stringToCheck[firstLetter - 1] != 'ё')
                                {
                                    throw new Exception("Incorrect plus position");
                                }
                            }
                        }
                    }
                    firstLetter = lastLetter + 2;
                    lastLetter = stringToCheck.Length - 1;
                    plusCount = 0; yoCount = 0; vowelsCount = 0;
                }
            }
            return true;
        }
    }
}
