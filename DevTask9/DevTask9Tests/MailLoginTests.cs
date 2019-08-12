using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DevTask9;
using DevTask9.Mail;

namespace DevTask9Tests
{
    [TestFixture]
    public class MailLoginTests
    {
        private IWebDriver Driver { get; set; }
        private IWebElement ErrorMessage => this.Driver.FindElement(By.XPath("//div[@id = 'mailbox:error' and (contains(text(), 'имя') or contains(text(), 'пароль'))]"), 10);

        [SetUp]
        public void OpenMailLoginPage()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.ru");
        }
        
        [TestCase("DevTask9@mail.ru", "1D2e3v4T5@6s7k89")]
        public void LoginCorrectInputTest(string login, string password)
        {
            var mailPage = new LoginPage(this.Driver);
            mailPage.LoginToMail(login, password);
            Assert.IsTrue(new MainPage(this.Driver).LetterButton.Displayed);
        }

        [TestCase("pochta", "parol")]
        [TestCase("", "")]
        [TestCase("pochta", "")]
        [TestCase("", "parol")]
        public void LoginIncorrectInputTest(string login, string password)
        {
            var mailPage = new LoginPage(this.Driver);
            mailPage.LoginToMail(login, password);
            Assert.IsTrue(this.ErrorMessage.Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}