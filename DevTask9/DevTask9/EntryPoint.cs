using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevTask9
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver Driver;
                Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://mail.ru");
                MailLoginPage page1 = new MailLoginPage(Driver);
                page1.LoginToMail("DevTask9@mail.ru", "1D2e3v4T5@6s7k89").StartWritingLetter().SendLetter("devtask9@rambler.ru", "message");
                
                /*Driver.Navigate().GoToUrl("https://mail.rambler.ru");
                RamblerLoginPage page2 = new RamblerLoginPage(Driver);
                page2.LoginToRambler("DevTask9", "DevTask9").ChooseUnreadLetter("devtask9@mail.ru").ReplyToLetter("Loh");*/

                //MailLetterRecipientPage page3 = new MailLetterRecipientPage(Driver);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
