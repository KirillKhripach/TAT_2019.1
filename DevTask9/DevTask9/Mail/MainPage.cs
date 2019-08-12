using OpenQA.Selenium;

namespace DevTask9.Mail
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    public class MainPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement LetterButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Написать письмо')]"), 10);
        public IWebElement UnreadLetters => this.Driver.FindElement(By.XPath($"//div[@class = 'b-datalist__body']"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Clicks to start writing a letter button
        /// </summary>
        /// <returns>Mail letter sender page</returns>
        public LetterSenderPage StartWritingLetter()
        {
            this.LetterButton.Click();

            return new LetterSenderPage(this.Driver);
        }

        /// <summary>
        /// Chooses unread letter from sender
        /// </summary>
        /// <param name="sender">Who send letter</param>
        /// <returns>Rambler letter recipient page</returns>
        public LetterRecipientPage ChooseUnreadLetter(string sender)
        {
            var letterFromSender = this.UnreadLetters.FindElement(By.XPath($".//a[contains(@data-title, '{sender}')]"));
            letterFromSender.Click();

            return new LetterRecipientPage(this.Driver);
        }
    }
}
