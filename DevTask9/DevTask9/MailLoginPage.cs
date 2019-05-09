using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class MailLoginPage
    {
        private IWebDriver Driver { get; set; }
        private IWebElement LoginBox { get; set; }
        private IWebElement PasswordBox { get; set; }
        private IWebElement CheckBox { get; set; }
        private IWebElement LoginButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Logins to mail account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Mail main page</returns>
        public MailMainPage LoginToMail(string login, string password)
        {
            this.LoginBox = this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
            this.LoginBox.SendKeys(login);
            this.PasswordBox = this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
            this.PasswordBox.SendKeys(password);
            this.CheckBox = this.Driver.FindElement(By.XPath("//input[@class = 'mailbox__saveauth']"), 10);

            if (this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.LoginButton = this.Driver.FindElement(By.XPath("//input[@class= 'o-control']"), 10);
            this.LoginButton.Submit();

            return new MailMainPage(this.Driver);
        }
    }
}
