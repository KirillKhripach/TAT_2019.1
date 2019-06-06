using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassWork9
{
    /// <summary>
    /// Class for creating chrome webdriver
    /// </summary>
    public class ChromeDriverCreator : IDriverCreator
    {
        /// <summary>
        /// Creates chrome webdriver
        /// </summary>
        /// <returns>Chrome webdriver</returns>
        public IWebDriver Create()
        {
            return new ChromeDriver();
        }
    }
}
