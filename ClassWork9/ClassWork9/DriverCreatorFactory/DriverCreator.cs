namespace ClassWork9
{
    /// <summary>
    /// Class for choosing webdriver
    /// </summary>
    public class DriverCreator
    {
        private const string _chromeDriver = "chrome";
        private const string _operaDriver = "opera";

        /// <summary>
        /// Returns webdriver creator according to input data
        /// </summary>
        /// <param name="browserName">Name of the browser</param>
        /// <returns>Webdriver creator</returns>
        public IDriverCreator GetDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case _chromeDriver:
                    return new ChromeDriverCreator();
                default:
                    return null;
            }
        }
    }
}
