using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevTask9Tests
{
    class SendLetterTests
    {
        private IWebDriver Driver { get; set; }
        private string MailAdress { get; set; } = "DevTask9@mail.ru";
        private string MailPassword { get; set; } = "1D2e3v4T5@6s7k89";
        private string RamblerAdress { get; set; } = "DevTask9@rambler.ru";
        private string RamblerPassword { get; set; } = "DevTask9";
        private string _message = "Gimme some nickname";
        private string _nickname = "Goodman";

        [SetUp]
        public void OpenBrowserAndSendMessage()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.ru");
            new DevTask9.Mail.LoginPage(this.Driver).LoginToMail(this.MailAdress, this.MailPassword).StartWritingLetter().SendLetter(this.RamblerAdress, this._message);
        }

        [Test]
        public void SendLetter()
        {
            this.Driver.Navigate().GoToUrl("https://mail.rambler.ru");
            var ramblerPage = new DevTask9.Rambler.LoginPage(this.Driver).LoginToRambler(this.RamblerAdress, this.RamblerPassword).ChooseUnreadLetter(this.MailAdress.ToLower());
            Assert.AreEqual(ramblerPage.GetMessageFromLetter(), this._message);
        }

        [Test]
        public void ReplyToLetterAndChangeNickname()
        {
            this.Driver.Navigate().GoToUrl("https://mail.rambler.ru");
            new DevTask9.Rambler.LoginPage(this.Driver).LoginToRambler(this.RamblerAdress, this.RamblerPassword).ChooseUnreadLetter(this.MailAdress.ToLower()).ReplyToLetter(this._nickname);

            this.Driver.Navigate().GoToUrl("https://e.mail.ru/messages/inbox/");
            var mailPage = new DevTask9.Mail.MainPage(this.Driver).ChooseUnreadLetter(this.RamblerAdress.ToLower());
            string nickname = mailPage.GetMessageFromLetter();
            mailPage.GoToSettings().ChangeUserName(nickname);

            Assert.AreEqual(mailPage.GoToSettings().GetUserName(), this._nickname);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}
