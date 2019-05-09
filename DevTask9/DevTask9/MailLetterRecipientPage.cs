using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for reading letter
    /// </summary>
    public class MailLetterRecipientPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Nickname { get; set; }
        private IWebElement Profile { get; set; }
        private IWebElement Settings { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailLetterRecipientPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets text of message
        /// </summary>
        /// <returns>Received text</returns>
        public string GetNicknameFromLetter()
        {
            this.Nickname = this.Driver.FindElement(By.XPath("//div[@class = 'js-helper js-readmsg-msg']//div[contains(@class, 'class')]"), 10);

            return this.Nickname.Text;
        }

        /// <summary>
        /// Opens settings
        /// </summary>
        /// <returns>Mail settings page</returns>
        public MailSettingsPage GoToSetting()
        {
            this.Profile = this.Driver.FindElement(By.XPath("//span[@id = 'PH_authMenu_button']"), 10);
            this.Profile.Click();
            this.Settings = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Личные данные')]"), 10);
            this.Settings.Click();

            return new MailSettingsPage(this.Driver);
        }
    }
}
