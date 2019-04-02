using System;

namespace DevTask1
{
    /// <summary>
    /// Finds sequences in string without repetitive in a row elements
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// Checks input string and calls finder's methods
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2 && args[0].Length < 2)
                {
                    throw new Exception("Wrong number of arguments");
                }

                SequencesFinderAndDisplayer sequencesFinder = new SequencesFinderAndDisplayer(args);
                sequencesFinder.DisplaySequences(sequencesFinder.FindSequences());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
