using OpenQA.Selenium;

namespace DevTask9.Rambler
{
    /// <summary>
    /// Class for logging
    /// </summary>
    public class LoginPage
    {
        private IWebDriver Driver { get; set; }
        public IWebElement Login => this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
        public IWebElement Password => this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
        public IWebElement CheckBox => this.Driver.FindElement(By.XPath("//span[@class = 'rui-Checkbox-fake']"), 10);
        public IWebElement LoginButton => this.Driver.FindElement(By.XPath("//span[@class = 'rui-Button-content']"), 10);

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="driver">WebDriver</param>
        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Logins to rambler account
        /// </summary>
        /// <param name="login">Account login</param>
        /// <param name="password">Account password</param>
        /// <returns>Rambler main page</returns>
        public MainPage LoginToRambler(string login, string password)
        {
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe[contains(@src, 'login')]"), 10));
            this.Login.SendKeys(login);
            this.Password.SendKeys(password);

            if (!this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }
            
            this.LoginButton.Submit();

            return new MainPage(this.Driver);
        }
    }
}
