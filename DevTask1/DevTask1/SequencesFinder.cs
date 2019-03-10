using System;
using System.Text;

namespace DevTask1
{
    class SequencesFinder
    {
        StringBuilder processedString;

        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public SequencesFinder(string[] inputString)
        {
            processedString = new StringBuilder();
            foreach (string word in inputString)
            {
                processedString.Append(word).Append(" ");
            }
            processedString.Remove(processedString.Length - 1, 1);
        }

        /// <summary>
        /// Compares current symbol with next symbols
        /// and displays it if they different
        /// </summary>
        public void FindSequences()
        {
            StringBuilder sequence;
            for (int i = 0; i < processedString.Length - 1; i++)
            {
                sequence = new StringBuilder();
                sequence.Append(processedString[i]);
                for (int j = i + 1; j < processedString.Length; j++)
                {
                    if (processedString[j - 1] != processedString[j])
                    {
                        sequence.Append(processedString[j]);
                        Console.WriteLine(sequence);
                    }
                    else break;
                }
            }
        }
    }
}
