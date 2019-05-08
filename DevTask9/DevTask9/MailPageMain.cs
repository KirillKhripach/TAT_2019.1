using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    class MailPageMain
    {
        private IWebDriver Driver { get; set; }
        private IWebElement LetterButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailPageMain(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Clicks to start writing a letter button
        /// </summary>
        /// <returns>Mail letter sender page</returns>
        public MailPageLetterSender StartWritingLetter()
        {
            this.LetterButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Написать письмо')]"), 10);
            this.LetterButton.Click();

            return new MailPageLetterSender(this.Driver);
        }
    }
}
