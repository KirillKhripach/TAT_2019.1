using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for reading letter
    /// </summary>
    class RamblerPageLettterRecipient
    {
        private IWebDriver Driver { get; set; }
        private IWebElement TextField { get; set; }
        private IWebElement SendButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public RamblerPageLettterRecipient(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Replies to the letter
        /// </summary>
        /// <param name="message">What contains the letter</param>
        public void ReplyToLetter(string message)
        {
            this.TextField = this.Driver.FindElement(By.XPath("//textarea[@class = 'rui-Input-input QuickReply-textarea-3R']"), 10);
            this.TextField.SendKeys(message);
            this.SendButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить письмо')]"), 10);
            this.SendButton.Click();
        }
    }
}
