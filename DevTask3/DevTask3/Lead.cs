namespace DevTask3
{
    /// <summary>
    /// Class for lead type employee
    /// </summary>
    class Lead : Senior
    {
        public Lead()
        {
            Salary = 1500;
            Productivity = 85;
            Value = (double)Salary / Productivity;
        }
    }
}
