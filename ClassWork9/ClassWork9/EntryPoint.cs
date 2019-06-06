using System;
using OpenQA.Selenium;

namespace ClassWork9
{
    /// <summary>
    /// Class contains entry point to the program
    /// Gets exchange rates from tut.by and write it to the file
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates writer to the file and creator of web driver
        /// According to input data from command line
        /// </summary>
        /// <param name="args">File name and browser name</param>
        static void Main(string[] args)
        {
            try
            {
                //args[0] - file name
                IWriter writer = new Writer().GetWriter($"{args[0]}");

                //args[1] - browser name
                IDriverCreator driverCreator = new DriverCreator().GetDriver($"{args[1]}");

                if (writer == null || driverCreator == null)
                {
                    throw new Exception("Incorrect input data");
                }

                IWebDriver driver = driverCreator.Create();
                driver.Navigate().GoToUrl("https://finance.tut.by");
                TutByPage tutBy = new TutByPage(driver);
                writer.Write(tutBy.GetExchangeRates());
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
