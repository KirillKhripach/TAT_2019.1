using System;

namespace DevTask3
{
    /// <summary>
    /// Contains entry point to the program
    /// Creates team according to choosen criterion
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates criterion chooser, gets employees according to choosen criterion
        /// Displays necessary employees
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                CriterionChooser criterionChooser = new CriterionChooser();
                Company company = new Company();
                company.GetEmployees(criterionChooser.Choose());
                company.DisplayNecessaryEmployees();
                company.CheckForSufficiency();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
