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
                Console.WriteLine("Select a criterion to calculate:\n1. Maximum productivity\n2. Minimum cost\n3. Minimum number of employees");
                int choice = Int32.Parse(Console.ReadLine());
                Calculator calculator;
                List<int> employeesAmount;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the amount of money you have");
                        calculator = new Calculator(Int32.Parse(Console.ReadLine()));
                        employeesAmount = calculator.CalculateEmployeesForMaximumProductivity();
                        break;
                    case 2:
                        Console.WriteLine("Enter required productivity");
                        calculator = new Calculator(Int32.Parse(Console.ReadLine()));
                        employeesAmount = calculator.CalculateEmployeesForMinimumCost();
                        break;
                    case 3:
                        Console.WriteLine("Enter required productivity without juniors");
                        calculator = new Calculator(Int32.Parse(Console.ReadLine()));
                        employeesAmount = calculator.CalculateMinimumEmployees();
                        break;
                    default:
                        throw new Exception("Incorrect input data");
                }
                Console.WriteLine("The number of employees you need:");
                Console.WriteLine($"Junior: {employeesAmount[0]}\nMiddle: {employeesAmount[1]}\nSenior: {employeesAmount[2]}\nLead:   {employeesAmount[3]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}