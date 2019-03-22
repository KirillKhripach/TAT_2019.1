﻿using System.Collections.Generic;
using System.Linq;

namespace DevTask3
{
    /// <summary>
    /// Class for optimization
    /// According to first criterion
    /// </summary>
    class FirstCriterionOptimizer : Optimizer
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="sum"></param>
        public FirstCriterionOptimizer(int sum) : base(sum) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to first criterion
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            employeeQualifications.Add(new Junior());
            employeeQualifications.Add(new Middle());
            employeeQualifications.Add(new Senior());
            employeeQualifications.Add(new Lead());
            var sortedEmployeeQualifications = employeeQualifications.OrderBy(i => i.Value);
            int number;
            foreach (Employee qualification in sortedEmployeeQualifications)
            {
                number = CriterionParameter / qualification.Salary;
                CriterionParameter -= qualification.Salary * number;
                for (int i = 0; i < number; i++)
                {
                    if (qualification is Lead)
                    {
                        necessaryEmployees.Add(new Lead());
                        continue;
                    }
                    if (qualification is Senior)
                    {
                        necessaryEmployees.Add(new Senior());
                        continue;
                    }
                    if (qualification is Middle)
                    {
                        necessaryEmployees.Add(new Middle());
                        continue;
                    }
                    if (qualification is Junior)
                    {
                        necessaryEmployees.Add(new Junior());
                        continue;
                    }
                }
            }
            return necessaryEmployees;
        }
    }
}
