using System;
using System.Collections.Generic;
using System.Text;

namespace DevTask1
{
    class SequencesFinderAndDisplayer
    {
        StringBuilder processedString;

        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public SequencesFinderAndDisplayer(string[] inputString)
        {
            if (inputString[0].Length < 2 && inputString.Length < 2)
            {
                throw new Exception("Wrong number of arguments");
            }
            processedString = new StringBuilder();
            foreach (string word in inputString)
            {
                processedString.Append(word);
            }
        }

        /// <summary>
        /// Finds sequences by
        /// Comparing current symbol with next symbols
        /// </summary>
        /// <returns>List of sequences</returns>
        public List<string> FindSequences()
        {
            StringBuilder sequence;
            List<string> sequences = new List<string>();
            for (int i = 0; i < processedString.Length - 1; i++)
            {
                sequence = new StringBuilder();
                sequence.Append(processedString[i]);
                for (int j = i + 1; j < processedString.Length; j++)
                {
                    if (processedString[j - 1] != processedString[j])
                    {
                        sequence.Append(processedString[j]);
                        sequences.Add(sequence.ToString());
                    }
                    else break;
                }
            }
            return sequences;
        }

        /// <summary>
        /// Displays sequences
        /// </summary>
        /// <param name="sequences">List of sequences</param>
        public void DisplaySequences(List<string> sequences)
        {
            if (sequences.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                foreach (string sequence in sequences)
                {
                    Console.WriteLine(sequence);
                }
            }
        }
    }
}
