using OpenQA.Selenium;

namespace DevTask9.Mail
{
    /// <summary>
    /// Class for reading letter
    /// </summary>
    public class LetterRecipientPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement Message => this.Driver.FindElement(By.XPath("//div[@class = 'js-helper js-readmsg-msg']"), 10);
        public IWebElement Profile => this.Driver.FindElement(By.XPath("//span[@id = 'PH_authMenu_button']"), 10);
        public IWebElement Settings => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Личные данные')]"), 10);

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
        /// Opens settings
        /// </summary>
        /// <returns>Mail settings page</returns>
        public SettingsPage GoToSettings()
        {
            this.Profile.Click();
            this.Settings.Click();

            return new SettingsPage(this.Driver);
        }
    }
}
