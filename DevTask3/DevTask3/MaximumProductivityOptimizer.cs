using System.Collections.Generic;
using System.Linq;

namespace DevTask3
{
    /// <summary>
    /// Class for optimization
    /// Maximum productivity within the sum
    /// </summary>
    class MaximumProductivityOptimizer : Optimizer
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="sum">Amount of money</param>
        public MaximumProductivityOptimizer(int sum) : base(sum) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to maximum productivity within the sum
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            this.EmployeeQualifications.Add(new Junior());
            this.EmployeeQualifications.Add(new Middle());
            this.EmployeeQualifications.Add(new Senior());
            this.EmployeeQualifications.Add(new Lead());

            foreach (Employee qualification in this.EmployeeQualifications.OrderBy(i => i.Value))
            {
                int number = this.CriterionParameter / qualification.Salary;
                this.CriterionParameter -= qualification.Salary * number;

                for (int i = 0; i < number; i++)
                {
                    switch(qualification.GetType().Name)
                    {
                        case "Lead":
                            this.NecessaryEmployees.Add(new Lead());
                            break;
                        case "Senior":
                            this.NecessaryEmployees.Add(new Senior());
                            break;
                        case "Middle":
                            this.NecessaryEmployees.Add(new Middle());
                            break;
                        case "Junior":
                            this.NecessaryEmployees.Add(new Junior());
                            break;
                    }
                }
            }

            return this.NecessaryEmployees;
        }
    }
}
