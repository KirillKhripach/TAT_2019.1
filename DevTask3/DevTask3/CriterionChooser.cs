using System;

namespace DevTask3
{
    /// <summary>
    /// Class for choosing criterion
    /// </summary>
    class CriterionChooser
    {
        /// <summary>
        /// Chooses criterion according to input data
        /// </summary>
        /// <returns>Choosed criterion</returns>
        public Optimizer Choose()
        {
            Console.WriteLine("Select a criterion to calculate:\n1. Maximum productivity\n2. Minimum cost\n3. Minimum number of employees");
            int choice = Int32.Parse(Console.ReadLine());
            Optimizer optimizer;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the amount of money you have:");
                    optimizer = new FirstCriterionOptimizer(Int32.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Enter required productivity:");
                    optimizer = new SecondCriterionOptimizer(Int32.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Enter required productivity without juniors:");
                    optimizer = new ThirdCriterionOptimizer(Int32.Parse(Console.ReadLine()));
                    break;
                default:
                    throw new Exception("Incorrect input data");
            }
            return optimizer;
        }
    }
}
