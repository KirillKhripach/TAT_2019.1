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
        /// Entry point
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                List<IFlyable> flyables = new List<IFlyable>() { new Bird(), new Plane(), new SpaceShip() };

                foreach (IFlyable flyable in flyables)
                {
                    flyable.ObjectFlewIn += ShowFlightInformation;
                    flyable.FlyTo(new Point(100, 200, 800));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Subscriber to the ObjectFlewIn Event
        /// Receives and displays distance, time and speed of the flight
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        static void ShowFlightInformation(object obj, ObjectFlewInEventArgs e)
        {
            Console.WriteLine($"{obj.GetType().Name} flew {e.Distance:0.###} km in {e.Time * 3600:0.###} sec and reached a speed of {e.Speed:0.###} km/h");
        }
    }
}
