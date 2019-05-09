using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    public class MailMainPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement LetterButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailMainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Clicks to start writing a letter button
        /// </summary>
        /// <returns>Mail letter sender page</returns>
        public MailLetterSenderPage StartWritingLetter()
        {
            this.LetterButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Написать письмо')]"), 10);
            this.LetterButton.Click();

            return new MailLetterSenderPage(this.Driver);
        }
    }
}
