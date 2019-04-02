using System;

namespace DevTask5
{
    /// <summary>
    /// Class for planes
    /// </summary>
    class Plane : IFlyable
    {
        public int FlySpeed { get; private set; }
        public int Acceleration { get; private set; }
        public int AccelerationFrequency { get; private set; }
        public Point StartPoint { get; private set; }
        public double Distance { get; private set; }
        public event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;

        /// <summary>
        /// Constructor initializes fields
        /// Start speed 200 km/h
        /// Acceleration 10 km/h every 10 km
        /// Starting point (0, 0, 0)
        /// </summary>
        public Plane()
        {
            FlySpeed = 200;
            Acceleration = 10;
            AccelerationFrequency = 10;
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
            double flyTime = 0;
            double distance = Distance;

            for (; distance > AccelerationFrequency;)
            {
                flyTime += (double)AccelerationFrequency / FlySpeed;
                FlySpeed += Acceleration;
                distance -= AccelerationFrequency;
            }

            flyTime += distance / FlySpeed;
            FlySpeed += (int)(Acceleration * distance / AccelerationFrequency);

            return flyTime;
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
