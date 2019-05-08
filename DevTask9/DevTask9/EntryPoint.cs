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
                /*IWebDriver Driver;
                Driver = new ChromeDriver();
                
                MailPageLogin page1 = new MailPageLogin(Driver);
                page1.GoToLoginPage();
                page1.LoginToMail("DevTask9", "1D2e3v4T5@6s7k89").ClickToWriteLetter().SendLetter("devtask9@rambler.ru", "message");
                
                RamblerPageLogin page2 = new RamblerPageLogin(Driver);
                page2.GoToLoginPage();
                page2.LoginToRambler("DevTask9", "DevTask9").ChooseUnreadLetter("devtask9@mail.ru").ReplyOnLetter("Loh");

                MailPageLetterRecipient page3 = new MailPageLetterRecipient(Driver);*/               
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
