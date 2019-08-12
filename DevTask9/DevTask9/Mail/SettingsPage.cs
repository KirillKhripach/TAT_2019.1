using OpenQA.Selenium;

namespace DevTask9.Mail
{
    /// <summary>
    /// Class for mail settings
    /// </summary>
    public class SettingsPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement Nickname => this.Driver.FindElement(By.XPath("//input[@name = 'NickName']"), 10);
        public IWebElement SaveButton => this.Driver.FindElement(By.XPath("//span[text() = 'Сохранить']"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public SettingsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Changes nickname of account
        /// </summary>
        /// <param name="newNickname">New nickname</param>
        public void ChangeUserName(string newNickname)
        {
            this.Nickname.Clear();
            this.Nickname.SendKeys(newNickname);
            this.SaveButton.Click();
        }

        /// <summary>
        /// Gets nickname of account
        /// </summary>
        /// <returns>Nickname</returns>
        public string GetUserName()
        {
            return this.Nickname.GetProperty("value");
        }
    }
}
