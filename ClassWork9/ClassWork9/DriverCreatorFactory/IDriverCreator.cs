using OpenQA.Selenium;

namespace ClassWork9
{
    /// <summary>
    /// Interface for factory pattern
    /// </summary>
    public interface IDriverCreator
    {
        /// <summary>
        /// Creates webdriver
        /// </summary>
        /// <returns>Webdriver</returns>
        IWebDriver Create();
    }
}
