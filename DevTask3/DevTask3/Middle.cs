namespace DevTask3
{
    /// <summary>
    /// Class for middle type employee
    /// </summary>
    class Middle : Junior
    {
        public Middle()
        {
            Salary = 500;
            Productivity = 25;
            Value = (double)Salary / Productivity;
        }
    }
}
