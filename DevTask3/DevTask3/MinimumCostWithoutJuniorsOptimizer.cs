using System.Collections.Generic;
using System.Linq;

namespace DevTask3
{
    /// <summary>
    /// Class for optimization
    /// The minimum cost at a fixed productivity without juniors
    /// </summary>
    class MinimumCostWithoutJuniorsOptimizer : Optimizer
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="productivity">Required productivity</param>
        public MinimumCostWithoutJuniorsOptimizer(int productivity) : base(productivity) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to the minimum cost at a fixed productivity without juniors
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            this.EmployeeQualifications.Add(new Middle());
            this.EmployeeQualifications.Add(new Senior());
            this.EmployeeQualifications.Add(new Lead());

            foreach (Employee qualification in this.EmployeeQualifications.OrderBy(i => i.Value))
            {
                int number = this.CriterionParameter / qualification.Productivity;
                this.CriterionParameter -= qualification.Productivity * number;

                for (int i = 0; i < number; i++)
                {
                    switch (qualification.GetType().Name)
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

            if (this.CriterionParameter > 0)
            {
                this.NecessaryEmployees.Add(this.EmployeeQualifications.OrderBy(i => i.Salary).First());
            }

            return this.NecessaryEmployees;
        }
    }
}
