using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for sending letter
    /// </summary>
    class MailPageLetterSender
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Recipient { get; set; }
        private IWebElement TextField { get; set; }
        private IWebElement SendButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailPageLetterSender(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Sends letter
        /// </summary>
        /// <param name="recipient">Who receives the letter</param>
        /// <param name="message">What contains the letter</param>
        public void SendLetter(string recipient, string message)
        {
            this.Recipient = this.Driver.FindElement(By.XPath("//label[@class = 'container--zU301']"), 10);
            this.Recipient.SendKeys(recipient);
            //this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe"), 10));
            this.TextField = this.Driver.FindElement(By.XPath("//div[@role = 'textbox']/div/div"), 10);
            //this.Text.Clear();
            this.TextField.SendKeys(message);
            this.SendButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить')]"), 10);
            this.SendButton.Click();
        }
    }
}
