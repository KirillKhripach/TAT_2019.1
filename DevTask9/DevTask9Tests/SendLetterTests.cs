/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevTask9;

namespace DevTask9Tests
{
    class SendLetterTests
    {
        private IWebDriver Driver { get; set; }
        private string MailAdress { get; set; } = "DevTask9@mail.ru";
        private string MailPassword { get; set; } = "1D2e3v4T5@6s7k89";
        private string RamblerAdress { get; set; } = "DevTask9@rambler.ru";
        private string RamblerPassword { get; set; } = "DevTask9";

        [SetUp]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.ru");
        }

        [TestCase("DevTask9@mail.ru", "1D2e3v4T5@6s7k89")]
        public void Login_CorrectInput_NoErrorDisplayed(string login, string password)
        {
            MailLoginPage mailPage = new MailLoginPage(this.Driver);
            mailPage.LoginToMail(login, password);
            Assert.IsTrue(!this.Driver.FindElement(By.XPath("//div[@id = 'mailbox:error']"), 3).Displayed);
        }

        [TestCase("pochta", "parol")]
        [TestCase("", "")]
        [TestCase("pochta", "")]
        [TestCase("", "parol")]
        public void Login_IncorrectInput_ErrorDisplayed(string login, string password)
        {
            MailLoginPage mailPage = new MailLoginPage(this.Driver);
            mailPage.LoginToMail(login, password);
            Assert.IsTrue(this.Driver.FindElement(By.XPath("//div[@id = 'mailbox:error']"), 3).Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}
*/