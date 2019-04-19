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
                //Checks for 1 word and 2 symbols at least without '+'  
                if (args.Length != 1 || args[0].Replace("+", string.Empty).Length < 2)
                {
                    throw new Exception("The word should be one and contains at least two letters");
                }

                ToPhonemesConverter toPhonemesConverter = new ToPhonemesConverter("brain");
                Console.WriteLine(toPhonemesConverter.ConvertToPhenomes());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}