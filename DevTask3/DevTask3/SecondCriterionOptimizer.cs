using System.Collections.Generic;

namespace DevTask3
{
    /// <summary>
    /// Class for optimization
    /// According to second criterion
    /// </summary>
    class SecondCriterionOptimizer : ThirdCriterionOptimizer
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="sum"></param>
        public SecondCriterionOptimizer(int productivity) : base(productivity) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to second criterion
        /// Calls base method optimize
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            employeeQualifications.Add(new Junior());
            return base.Optimize();
        }
    }
}
