﻿using System;
using System.Linq;

namespace DevTask2
{
    /// <summary>
    /// Class for checking that string is contains from Cyrillic letters
    /// </summary>
    public class CyrillicCheker
    {
        public string StringToCheck { get; private set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="inputString"></param>
        public CyrillicCheker(string inputString)
        {
            this.StringToCheck = inputString.ToLower() ?? throw new NullReferenceException("String is null");
        }

        /// <summary>
        /// Checks that letters are Cyrillic
        /// </summary>
        /// <returns>True if letters are Cyrillic, else throws exception</returns>
        public bool Check()
        {
            foreach (char i in this.StringToCheck)
            {
                // Range(1072, 34) for Cyrillic letters
                if (i != '+' && !Enumerable.Range(1072, 34).Contains(i))
                {
                    throw new Exception("String contains non-Cyrillic symbols");
                }
            }

            return true;
        }
    }
}
