using System;

namespace DevTask5
{
    class Bird : IFlyable
    {
        public int FlySpeed { get; private set; }
        public Point StartPoint { get; private set; }
        public double Distance { get; private set; }
        public event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;

        /// <summary>
        /// Constructor initializes fields
        /// Starting point (0, 0, 0)
        /// </summary>
        public Bird()
        {
            FlySpeed = new Random().Next(1, 20);
            StartPoint = new Point();
        }

        /// <summary>
        /// Changes coordinates of object
        /// </summary>
        /// <param name="newPoint">New flight point</param>
        public void FlyTo(Point newPoint)
        {
            if (!StartPoint.Equals(newPoint))
            {
                Distance = StartPoint.GetDistance(newPoint);
                StartPoint = newPoint;
                ObjectFlewIn?.Invoke(WhoAmI(), new ObjectFlewInEventArgs(Distance, GetFlyTime(), FlySpeed));
                Distance = 0;
            }
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
