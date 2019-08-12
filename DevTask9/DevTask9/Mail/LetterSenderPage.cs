using OpenQA.Selenium;

namespace DevTask9.Mail
{
    /// <summary>
    /// Class for sending letter
    /// </summary>
    public class LetterSenderPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement Recipient => this.Driver.FindElement(By.XPath("//textarea[@class = 'js-input compose__labels__input']"), 10);
        public IWebElement TextField => this.Driver.FindElement(By.XPath("//body[@id = 'tinymce']"), 10);
        public IWebElement SendButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить')]"), 10);
        public IWebElement InboxButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Входящие')]"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public LetterSenderPage(IWebDriver driver)
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
            this.Recipient.SendKeys(recipient);
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe[contains(@id, 'composeEditor_ifr')]"), 10));
            this.TextField.Clear();
            this.TextField.SendKeys(message);
            this.Driver.SwitchTo().DefaultContent();
            this.SendButton.Click();
            this.InboxButton.Click();
        }
    }
}
