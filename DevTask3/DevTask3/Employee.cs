namespace DevTask3
{
    class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }

        public Employee()
        {
            Salary = 250;
            Productivity = 10;
        }
    }
}
