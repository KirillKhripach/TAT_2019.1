using System;
using System.Collections.Generic;

namespace DevTask3
{
    enum Qualification
    {
        Junior,
        Middle,
        Senior,
        Lead
    }

    /// <summary>
    /// Class with data about number of employees
    /// </summary>
    class Company
    {
        private int numberOfJuniors;
        private int numberOfMiddles;
        private int numberOfSeniors;
        private int numberOfLeads;

        /// <summary>
        /// Constructor initializes number of employees
        /// </summary>
        public Company()
        {
            numberOfJuniors = 10;
            numberOfMiddles = 8;
            numberOfSeniors = 6;
            numberOfLeads = 4;
        }

        /// <summary>
        /// Gets list of employees according to given criterion
        /// </summary>
        /// <param name="optimizer">Criterion</param>
        /// <returns>Optimized list of employees</returns>
        public List<Employee> GetEmployees(Optimizer optimizer)
        {
            return optimizer.Optimize();
        }

        /// <summary>
        /// Checks for sufficiency of employees 
        /// </summary>
        /// <param name="employees">Array of amount of employees</param>
        public void CheckForSufficiency(int[] employeesAmount)
        {
            if (employeesAmount[(int)Qualification.Junior] > numberOfJuniors || employeesAmount[(int)Qualification.Middle] > numberOfMiddles
                || employeesAmount[(int)Qualification.Senior] > numberOfSeniors || employeesAmount[(int)Qualification.Lead] > numberOfLeads)
            {
                Console.WriteLine("The company can not provides so many employees");
            }
            else
            {
                Console.WriteLine("The company can provides the required number of employees");
            }
        }

        /// <summary>
        /// Displays optimized list of employees
        /// </summary>
        /// <param name="employees">Optimized list of employees</param>
        /// <returns>Array of amount of employees</returns>
        public int[] DisplayOptimizedList(List<Employee> employees)
        {
            int[] employeesAmount = new int[Enum.GetNames(typeof(Qualification)).Length];
            foreach (Employee employee in employees)
            {
                if (employee is Lead)
                {
                    employeesAmount[(int)Qualification.Lead]++;
                    continue;
                }
                if (employee is Senior)
                {
                    employeesAmount[(int)Qualification.Senior]++;
                    continue;
                }
                if (employee is Middle)
                {
                    employeesAmount[(int)Qualification.Middle]++;
                    continue;
                }
                if (employee is Junior)
                {
                    employeesAmount[(int)Qualification.Junior]++;
                    continue;
                }
            }
            Console.WriteLine("The number of employees you need:");
            Console.WriteLine($"Junior: {employeesAmount[(int)Qualification.Junior]}");
            Console.WriteLine($"Middle: {employeesAmount[(int)Qualification.Middle]}");
            Console.WriteLine($"Senior: {employeesAmount[(int)Qualification.Senior]}");
            Console.WriteLine($"Lead: {employeesAmount[(int)Qualification.Lead]}");
            return employeesAmount;
        }
    }
}
