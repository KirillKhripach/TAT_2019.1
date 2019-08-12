using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevTask9;
using DevTask9.Rambler;

namespace DevTask9Tests
{
    [TestFixture]
    public class RamblerLoginTests
    {
        private IWebDriver Driver { get; set; }
        private IWebElement ErrorMessage => this.Driver.FindElement(By.XPath("//div[@class = 'rui-InputStatus-message']"), 10);

        [SetUp]
        public void OpenRamblerLoginPage()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.rambler.ru");
        }

        [TestCase("DevTask9@rambler.ru", "DevTask9")]
        public void LoginCorrectInputTest(string login, string password)
        {
            var ramblerPage = new LoginPage(this.Driver);
            ramblerPage.LoginToRambler(login, password);
            Assert.IsTrue(new MainPage(this.Driver).UnreadLetters.Displayed);
        }

        [TestCase("pochta", "parol")]
        [TestCase("", "")]
        [TestCase("pochta", "")]
        [TestCase("", "parol")]
        public void LoginIncorrectInputTest(string login, string password)
        {
            var ramblerPage = new LoginPage(this.Driver);
            ramblerPage.LoginToRambler(login, password);
            Assert.IsTrue(this.ErrorMessage.Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}