using System;
using System.Collections.Generic;

namespace DevTask3
{
    /// <summary>
    /// Abstract claas for optimizers
    /// </summary>
    abstract class Optimizer
    {
        protected int CriterionParameter { get; set; }
        protected List<Employee> employeeQualifications;
        protected List<Employee> necessaryEmployees;

        /// <summary>
        /// Constructor checks validity of input data
        /// And allocates memory
        /// </summary>
        /// <param name="criterionParameter">Sum or productivity</param>
        public Optimizer(int criterionParameter)
        {
            if (criterionParameter < 0)
                throw new Exception("Value must be non-negative");
            CriterionParameter = criterionParameter;
            employeeQualifications = new List<Employee>();
            necessaryEmployees = new List<Employee>();
        }

        /// <summary>
        /// Abstract method for optimization
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public abstract List<Employee> Optimize();
    }
}
