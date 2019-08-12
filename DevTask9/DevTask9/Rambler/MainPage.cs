using OpenQA.Selenium;

namespace DevTask9.Rambler
{
    /// <summary>
    /// Class to start writing a letter
    /// </summary>
    public class MainPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement UnreadLetters => this.Driver.FindElement(By.XPath($"//div[@class = 'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad']"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Chooses unread letter from sender
        /// </summary>
        /// <param name="sender">Who send letter</param>
        /// <returns>Rambler letter recipient page</returns>
        public LetterRecipientPage ChooseUnreadLetter(string sender)
        {
            var letterFromSender = this.UnreadLetters.FindElement(By.XPath($".//span[contains(@title, '{sender}')]"));
            letterFromSender.Click();

            return new LetterRecipientPage(this.Driver);
        }
    }
}
