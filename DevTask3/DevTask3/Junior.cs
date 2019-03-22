namespace DevTask3
{
    /// <summary>
    /// Class for junior type employee
    /// </summary>
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 250;
            Productivity = 10;
            Value = (double)Salary / Productivity;
        }
    }
}
