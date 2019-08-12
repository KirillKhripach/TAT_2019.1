using OpenQA.Selenium;

namespace DevTask9.Mail
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class LoginPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement LoginBox => this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
        public IWebElement PasswordBox => this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
        public IWebElement CheckBox => this.Driver.FindElement(By.XPath("//input[@class = 'mailbox__saveauth']"), 10);
        public IWebElement LoginButton => this.Driver.FindElement(By.XPath("//input[@class= 'o-control']"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Logins to mail account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Mail main page</returns>
        public MainPage LoginToMail(string login, string password)
        {
            this.LoginBox.SendKeys(login);
            this.PasswordBox.SendKeys(password);

            if (this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.LoginButton.Submit();

            return new MainPage(this.Driver);
        }
    }
}
