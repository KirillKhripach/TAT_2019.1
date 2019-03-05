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
            if (args.Length == 0 || args[0].Length < 2)
            {
                Console.WriteLine("Too little muber of arguments");
            }
            else
            {
                SequencesFinder sequencesFinder = new SequencesFinder(args);
                sequencesFinder.FindSequences();
            }
        }
    }
}
