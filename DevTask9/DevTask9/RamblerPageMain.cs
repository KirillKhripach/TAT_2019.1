using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    class RamblerPageMain
    {
        private IWebDriver Driver { get; set; }
        private IWebElement ChooserUnreadLetter { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public RamblerPageMain(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Chooses unread letter from sender
        /// </summary>
        /// <param name="sender">Who send letter</param>
        /// <returns>Rambler letter recipient page</returns>
        public RamblerPageLettterRecipient ChooseUnreadLetter(string sender)
        {
            this.ChooserUnreadLetter = this.Driver.FindElement(By.XPath($"//div[@class = 'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad']//span[contains(@title, '{sender}')]"), 10);
            this.ChooserUnreadLetter.Click();

            return new RamblerPageLettterRecipient(this.Driver);
        }
    }
}
