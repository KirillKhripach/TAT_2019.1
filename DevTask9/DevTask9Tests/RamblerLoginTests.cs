using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevTask9;

namespace DevTask9Tests
{
    [TestFixture]
    public class RamblerLoginTests
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.rambler.ru");
        }

        [TestCase("DevTask9@rambler.ru", "DevTask9")]
        public void Login_CorrectInput_ElementDisplayed(string login, string password)
        {
            RamblerLoginPage ramblerPage = new RamblerLoginPage(this.Driver);
            ramblerPage.LoginToRambler(login, password);
            Assert.IsTrue(this.Driver.FindElement(By.XPath("//span[contains(text(), 'Написать')]"), 3).Displayed);
        }

        [TestCase("pochta", "parol")]
        [TestCase("", "")]
        [TestCase("pochta", "")]
        [TestCase("", "parol")]
        public void Login_IncorrectInput_ErrorDisplayed(string login, string password)
        {
            RamblerLoginPage ramblerPage = new RamblerLoginPage(this.Driver);
            ramblerPage.LoginToRambler(login, password);
            Assert.IsTrue(this.Driver.FindElement(By.XPath("//div[@class = 'rui-InputStatus-message']"), 3).Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}