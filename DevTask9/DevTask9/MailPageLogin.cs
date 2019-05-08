using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    class MailPageLogin
    {
        private IWebDriver Driver { get; set; }
        private IWebElement Login { get; set; }
        private IWebElement Password { get; set; }
        private IWebElement CheckBox { get; set; }
        private IWebElement LoginButton { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public MailPageLogin(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Goes to the start page of mail
        /// </summary>
        public void GoToLoginPage()
        {
            this.Driver.Navigate().GoToUrl("https://mail.ru");
            this.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Logins to mail account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Mail main page</returns>
        public MailPageMain LoginToMail(string login, string password)
        {
            this.Login = this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
            this.Login.SendKeys(login);
            this.Password = this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
            this.Password.SendKeys(password);
            this.CheckBox = this.Driver.FindElement(By.XPath("//input[@class = 'mailbox__saveauth']"), 10);

            if (this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.LoginButton = this.Driver.FindElement(By.XPath("//input[@class= 'o-control']"), 10);
            this.LoginButton.Submit();

            return new MailPageMain(this.Driver);
        }
    }
}
