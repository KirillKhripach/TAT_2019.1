using System;
using System.Collections.Generic;

namespace DevTask3
{
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
        /// Checks for sufficiency of employees and
        /// Displays optimized list of employees
        /// </summary>
        /// <param name="employees">Optimized list of employees</param>
        public void CheckForSufficiencyAndDisplay(List<Employee> employees)
        {
            int[] employeesAmount = new int[4];
            foreach (Employee employee in employees)
            {
                if (employee is Lead)
                {
                    employeesAmount[3]++;
                    continue;
                }
                if (employee is Senior)
                {
                    employeesAmount[2]++;
                    continue;
                }
                if (employee is Middle)
                {
                    employeesAmount[1]++;
                    continue;
                }
                if (employee is Junior)
                {
                    employeesAmount[0]++;
                    continue;
                }
            }
            Console.WriteLine("The number of employees you need:");
            Console.WriteLine($"Junior: {employeesAmount[0]}\nMiddle: {employeesAmount[1]}\nSenior: {employeesAmount[2]}\nLead:   {employeesAmount[3]}");
            if (employeesAmount[0] > numberOfJuniors || employeesAmount[1] > numberOfMiddles
                || employeesAmount[2] > numberOfSeniors || employeesAmount[3] > numberOfLeads)
            {
                Console.WriteLine("The company can not provides so many employees");
            }
            else Console.WriteLine("The company can provides the required number of employees");
        }
    }
}
