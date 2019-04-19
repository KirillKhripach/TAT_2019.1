using System;
using System.Linq;

namespace DevTask2
{
    /// <summary>
    /// Class for validating input string
    /// </summary>
    public class ValidationCheker
    {
        public string StringToCheck { get; private set; }
        private readonly string _vowelsString = "аиоуыэеёюя";
        private int _plusCount = 0;
        private int _yoCount = 0;
        private int _vowelsCount = 0;

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="inputString">String to check</param>
        public ValidationCheker(string inputString)
        {
            this.StringToCheck = inputString;
        }

        /// <summary>
        /// Checks the correct position of pluses and vowels
        /// </summary>
        /// <returns>True if correct, else throw exception</returns>
        public bool Check()
        {
            this.CountVowelsAndPluses();

            if (this._vowelsCount == 0)
            {
                throw new Exception("Lack of vowels");
            }

            if (this._plusCount == 0 && this._vowelsCount != 1 && this._yoCount == 0)
            {
                throw new Exception("Lack of plus");
            }

            if (this._plusCount > 1)
            {
                throw new Exception("Too many pluses");
            }

            if (this.StringToCheck.Contains('+') && (this.StringToCheck.IndexOf('+') == 0 || !this._vowelsString.Contains(this.StringToCheck[this.StringToCheck.IndexOf('+') - 1])))
            {
                throw new Exception("Incorrect plus position");
            }

            if (this.StringToCheck.Contains('+') && this._yoCount > 0 && this.StringToCheck[this.StringToCheck.IndexOf('+') - 1] != 'ё')
            {
                throw new Exception("Incorrect plus position");
            }

            return true;
        }

        /// <summary>
        /// Calculates number of pluses and vowels
        /// </summary>
        private void CountVowelsAndPluses()
        {
            for (int i = 0; i < this.StringToCheck.Length; i++)
            {
                switch (this.StringToCheck[i])
                {
                    case '+':
                        this._plusCount++;
                        break;
                    case 'ё':
                        this._yoCount++;
                        this._vowelsCount++;
                        break;
                    default:
                        if (this._vowelsString.Contains(this.StringToCheck[i]))
                        {
                            this._vowelsCount++;
                        }
                        break;
                }
            }
        }
    }
}

