using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for sending letter
    /// </summary>
    public class MailLetterSenderPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Recipient { get; set; }
        private IWebElement TextField { get; set; }
        private IWebElement SendButton { get; set; }
        private IWebElement InboxButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailLetterSenderPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Sends letter
        /// </summary>
        /// <param name="recipient">Who receives the letter</param>
        /// <param name="message">What contains the letter</param>
        public MailMainPage SendLetter(string recipient, string message)
        {
            this.Recipient = this.Driver.FindElement(By.XPath("//textarea[@class = 'js-input compose__labels__input']"), 10);
            this.Recipient.SendKeys(recipient);
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe[contains(@id, 'composeEditor_ifr')]"), 10));
            this.TextField = this.Driver.FindElement(By.XPath("//body[@id = 'tinymce']"), 10);
            this.TextField.Clear();
            this.TextField.SendKeys(message);
            this.Driver.SwitchTo().DefaultContent();
            this.SendButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить')]"), 10);
            this.SendButton.Click();
            this.InboxButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Входящие')]"), 10);
            this.InboxButton.Click();

            return new MailMainPage(this.Driver);
        }
    }
}
