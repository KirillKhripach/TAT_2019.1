using System;

namespace DevTask1
{
    class EntryPoint
    {
        /// <summary>
        /// Program accepts arguments from the command line and displays
        /// to the console all sequences without consecutive repetitive symbols
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0 || args[0].Length < 2)
                {
                    throw new Exception("Wrong number of arguments");
                }
                SequencesFinder sequencesFinder = new SequencesFinder(args);
                sequencesFinder.FindSequences();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
