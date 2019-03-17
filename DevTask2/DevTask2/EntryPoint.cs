using System;

namespace DevTask2
{
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Wrong number of arguments");
                }
                ToPhonemesConverter toPhonemesConverter = new ToPhonemesConverter(args);
                Console.WriteLine(toPhonemesConverter.ConvertToPhenomes());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}