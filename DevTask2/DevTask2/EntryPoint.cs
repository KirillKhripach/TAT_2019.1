using System;

namespace DevTask2
{
    /// <summary>
    /// Class contains entry point to the program
    /// Where word from command line converts to phonemes
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Checks input word and calls conversion method
        /// </summary>
        /// <param name="args">The command line arguments, word for converting</param>
        static void Main(string[] args)
        {
            try
            {
                //Checks for 1 word
                if (args.Length != 1)
                {
                    throw new Exception("The word should be one");
                }

                ToPhonemesConverter toPhonemesConverter = new ToPhonemesConverter(args[0]);
                Console.WriteLine(toPhonemesConverter.ConvertToPhenomes());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}