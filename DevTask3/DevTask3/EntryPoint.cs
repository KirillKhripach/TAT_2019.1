using System;
using System.Collections.Generic;

namespace DevTask3
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
                CriterionChooser criterionChooser = new CriterionChooser();
                Company company = new Company();
                List<Employee> employees = company.GetEmployees(criterionChooser.Choose());
                int[] employeesAmount = company.DisplayOptimizedList(employees);
                company.CheckForSufficiency(employeesAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}