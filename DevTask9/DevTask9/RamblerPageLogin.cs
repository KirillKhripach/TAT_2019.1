using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    class RamblerPageLogin
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
        public RamblerPageLogin(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Goes to the start page of rambler
        /// </summary>
        public void GoToLoginPage()
        {
            this.Driver.Navigate().GoToUrl("https://mail.rambler.ru");
            this.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Logins to rambler account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Rambler main page</returns>
        public RamblerPageMain LoginToRambler(string login, string password)
        {
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe"), 10));
            this.Login = this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
            this.Login.SendKeys(login);
            this.Password = this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
            this.Password.SendKeys(password);
            this.CheckBox = this.Driver.FindElement(By.XPath("//span[@class = 'rui-Checkbox-fake']"), 10);

            if (this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.LoginButton = this.Driver.FindElement(By.XPath("//span[@class = 'rui-Button-content']"), 10);
            this.LoginButton.Submit();

            return new RamblerPageMain(this.Driver);
        }
    }
}
