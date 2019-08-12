using OpenQA.Selenium;

namespace DevTask9.Rambler
{
    /// <summary>
    /// Class for reading letter
    /// </summary>
    public class LetterRecipientPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement Message => this.Driver.FindElement(By.XPath("//div[@class = 'messageBody isFormattedText']"), 10);
        public IWebElement TextField => this.Driver.FindElement(By.XPath("//textarea[@class = 'rui-Input-input QuickReply-textarea-3R']"), 10);
        public IWebElement SendButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить письмо')]"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public LetterRecipientPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets text of message
        /// </summary>
        /// <returns>Received text</returns>
        public string GetMessageFromLetter()
        {
            return this.Message.Text.Split('\u000A')[0];
        }

        /// <summary>
        /// Replies to the letter
        /// </summary>
        /// <param name="message">What contains the letter</param>
        public void ReplyToLetter(string message)
        {
            this.TextField.SendKeys(message);
            this.SendButton.Click();
        }
    }
}
