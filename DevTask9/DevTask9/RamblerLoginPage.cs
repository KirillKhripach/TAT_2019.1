using OpenQA.Selenium;

namespace DevTask9
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class RamblerLoginPage
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
        public RamblerLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Logins to rambler account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Rambler main page</returns>
        public RamblerMainPage LoginToRambler(string login, string password)
        {
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe[contains(@src, 'login')]"), 10));
            this.Login = this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
            this.Login.SendKeys(login);
            this.Password = this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
            this.Password.SendKeys(password);
            this.CheckBox = this.Driver.FindElement(By.XPath("//span[@class = 'rui-Checkbox-fake']"), 10);

            if (!this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.LoginButton = this.Driver.FindElement(By.XPath("//span[@class = 'rui-Button-content']"), 10);
            this.LoginButton.Submit();

            return new RamblerMainPage(this.Driver);
        }
    }
}
