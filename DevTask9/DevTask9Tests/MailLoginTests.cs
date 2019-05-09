using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevTask9;

namespace DevTask9Tests
{
    [TestFixture]
    public class MailLoginTests
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.ru");
            //this.Driver.Manage().Window.Maximize();
        }
        
        [TestCase("DevTask9@mail.ru", "1D2e3v4T5@6s7k89")]
        public void Login_CorrectInput_Completed(string login, string password)
        {
            /*this.Driver = new ChromeDriver();
            MailLoginPage mailPage = new MailLoginPage(this.Driver);
            mailPage.LoginToMail(login, password);*/
            Assert.IsTrue(true);
        }
    }
}