using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for mail settings
    /// </summary>
    public class MailSettingsPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Nickname { get; set; }
        private IWebElement SaveButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailSettingsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Changes nickname of account
        /// </summary>
        /// <param name="newNickname">New nickname</param>
        public void ChangeUserName(string newNickname)
        {
            this.Nickname = this.Driver.FindElement(By.XPath("//input[@name = 'NickName']"), 10);
            this.Nickname.Clear();
            this.Nickname.SendKeys(newNickname);
            this.SaveButton = this.Driver.FindElement(By.XPath("//span[text() = 'Сохранить']"), 10);
            this.SaveButton.Click();
        }
    }
}
