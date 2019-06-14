using System;
using System.Collections.Generic;

namespace DevTask5
{
    /// <summary>
    /// Calculates flight time of different objects
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point creates 3 different IFlyable objects, adds subscribers to event
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                List<IFlyable> flyables = new List<IFlyable>() { new Bird(), new Plane(), new SpaceShip() };
                Point targetPoint = new Point(100, 200, 800);
                Logger logger = new Logger();

                foreach (IFlyable flyable in flyables)
                {
                    flyable.ObjectFlewIn += logger.LogFlight;
                    flyable.FlyTo(targetPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
