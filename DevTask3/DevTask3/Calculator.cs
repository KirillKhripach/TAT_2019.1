using System;
using System.Collections.Generic;

namespace DevTask3
{
    class Calculator
    {
        private int InputData { get; set; }
        private List<int> numberOfEmployees;
        private Junior junior;
        private Middle middle;
        private Senior senior;
        private Lead lead;

        /// <summary>
        /// Constructor accepts data and
        /// Fills property and list
        /// </summary>
        /// <param name="inputData">Sum or productivity</param>
        public Calculator(int inputData)
        {
            if (inputData < 0)
                throw new Exception("Value must be non-negative");
            InputData = inputData;
            numberOfEmployees = new List<int>(4) { 0, 0, 0, 0 };
            junior = new Junior();
            middle = new Middle();
            senior = new Senior();
            lead = new Lead();
        }

        /// <summary>
        /// Calculates number of employees for maximum productivity
        /// For specified amount of money
        /// </summary>
        /// <returns>List with the number of employees</returns>
        public List<int> CalculateEmployeesForMaximumProductivity()
        {
            int leadCount = InputData / lead.Salary;
            numberOfEmployees[3] = leadCount;
            int residualAmount = InputData - lead.Salary * leadCount;
            for (; residualAmount >= junior.Salary;)
            {
                if (senior.Salary <= residualAmount)
                {
                    residualAmount -= senior.Salary;
                    numberOfEmployees[2]++;
                    continue;
                }
                if (middle.Salary <= residualAmount)
                {
                    residualAmount -= middle.Salary;
                    numberOfEmployees[1]++;
                    continue;
                }
                if (junior.Salary <= residualAmount)
                {
                    residualAmount -= junior.Salary;
                    numberOfEmployees[0]++;
                    continue;
                }
            }
            return numberOfEmployees;
        }

        /// <summary>
        /// Calculates number of employees for minimum cost
        /// For specified productivity
        /// </summary>
        /// <returns>List with the number of employees</returns>
        public List<int> CalculateEmployeesForMinimumCost()
        {
            int leadCount = InputData / lead.Productivity;
            numberOfEmployees[3] = leadCount;
            int residualAmount = InputData - lead.Productivity * leadCount;
            for (; residualAmount > 0;)
            {
                if (senior.Productivity <= residualAmount)
                {
                    residualAmount -= senior.Productivity;
                    numberOfEmployees[2]++;
                    continue;
                }
                if (middle.Productivity <= residualAmount)
                {
                    residualAmount -= middle.Productivity;
                    numberOfEmployees[1]++;
                    continue;
                }
                if (junior.Productivity <= residualAmount)
                {
                    residualAmount -= junior.Productivity;
                    numberOfEmployees[0]++;
                    continue;
                }
                residualAmount -= junior.Productivity;
                numberOfEmployees[0]++;
            }
            return numberOfEmployees;
        }

        /// <summary>
        /// Calculates minimum number of employees
        /// For specified productivity
        /// </summary>
        /// <returns>List with the number of employees</returns>
        public List<int> CalculateMinimumEmployees()
        {
            int leadCount = InputData / lead.Productivity;
            numberOfEmployees[3] = leadCount;
            int residualAmount = InputData - lead.Productivity * leadCount;
            for (; residualAmount > 0;)
            {
                if (senior.Productivity <= residualAmount)
                {
                    residualAmount -= senior.Productivity;
                    numberOfEmployees[2]++;
                    continue;
                }
                if (middle.Productivity <= residualAmount)
                {
                    residualAmount -= middle.Productivity;
                    numberOfEmployees[1]++;
                    continue;
                }
                residualAmount -= middle.Productivity;
                numberOfEmployees[1]++;
            }
            return numberOfEmployees;
        }
    }
}
