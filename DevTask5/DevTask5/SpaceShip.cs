using System;

namespace DevTask5
{
    /// <summary>
    /// Class for spaceships
    /// </summary>
    class SpaceShip : IFlyable
    {
        public int FlySpeed { get; private set; }
        public Point StartPoint { get; private set; }
        public double Distance { get; private set; }
        public event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;

        /// <summary>
        /// Constructor initializes fields
        /// Starting speed = 8000 km/h = 8000 * 3600 km/s
        /// Starting point (0, 0, 0)
        /// </summary>
        public SpaceShip()
        {
            FlySpeed = 8000 * 3600;
            StartPoint = new Point();
        }

        /// <summary>
        /// Changes coordinates of object
        /// </summary>
        /// <param name="newPoint">New flight point</param>
        public void FlyTo(Point newPoint)
        {
            Distance = StartPoint.GetDistance(newPoint);
            ObjectFlewIn?.Invoke(WhoAmI(), new ObjectFlewInEventArgs(Distance, GetFlyTime(), FlySpeed));
            StartPoint = newPoint;
            Distance = 0;
        }

        /// <summary>
        /// Calculates time of flight
        /// </summary>
        /// <returns>Time of flight</returns>
        public double GetFlyTime()
        {
            return Distance / FlySpeed;
        }

        /// <summary>
        /// Returns object reference
        /// </summary>
        /// <returns>Object reference</returns>
        public object WhoAmI()
        {
            return this;
        }
    }
}
