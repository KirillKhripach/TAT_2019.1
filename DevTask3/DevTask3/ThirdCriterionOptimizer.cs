using System.Collections.Generic;
using System.Linq;

namespace DevTask3
{
    /// <summary>
    /// Class for optimization
    /// According to third criterion
    /// </summary>
    class ThirdCriterionOptimizer : Optimizer
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="sum"></param>
        public ThirdCriterionOptimizer(int productivity) : base(productivity) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to third criterion
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            employeeQualifications.Add(new Middle());
            employeeQualifications.Add(new Senior());
            employeeQualifications.Add(new Lead());
            var sortedEmployeeQualifications = employeeQualifications.OrderBy(i => i.Value);
            int number;
            foreach (Employee qualification in sortedEmployeeQualifications)
            {
                number = CriterionParameter / qualification.Productivity;
                CriterionParameter -= qualification.Productivity * number;
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
            if (CriterionParameter > 0)
            {
                int minimumSalary = employeeQualifications.Min(Employee => Employee.Salary);
                Employee qualification = employeeQualifications.First(Employee => Employee.Salary == minimumSalary);
                if (qualification is Lead)
                {
                    necessaryEmployees.Add(new Lead());
                }
                else if (qualification is Senior)
                {
                    necessaryEmployees.Add(new Senior());
                }
                else if (qualification is Middle)
                {
                    necessaryEmployees.Add(new Middle());
                }
                else if (qualification is Junior)
                {
                    necessaryEmployees.Add(new Junior());
                }
            }
            return necessaryEmployees;
        }
    }
}
