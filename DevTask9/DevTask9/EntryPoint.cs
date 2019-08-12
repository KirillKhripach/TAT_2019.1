using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevTask9
{
    /// <summary>
    /// Contains entry point to the program
    /// Exchanges message between mail and rambler
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Sends message from mail to rambler
        /// Replies to received message
        /// Changes nickname of mail according to replied message
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver;
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://mail.ru");
                new Mail.LoginPage(driver).LoginToMail("devtask9@mail.ru", "1D2e3v4T5@6s7k89").StartWritingLetter().SendLetter("devtask9@rambler.ru", "Gimme some nickname");
                
                driver.Navigate().GoToUrl("https://mail.rambler.ru");
                new Rambler.LoginPage(driver).LoginToRambler("devtask9@rambler.ru", "DevTask9").ChooseUnreadLetter("devtask9@mail.ru").GetMessageFromLetter();//.ReplyToLetter("Goodman");
                
                driver.Navigate().GoToUrl("https://e.mail.ru/messages/inbox/");
                var messagePage = new Mail.MainPage(driver).ChooseUnreadLetter("devtask9@rambler.ru");
                string nickname = messagePage.GetMessageFromLetter();
                messagePage.GoToSettings().ChangeUserName(nickname);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
