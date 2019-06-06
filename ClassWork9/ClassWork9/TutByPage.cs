using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ClassWork9
{
    /// <summary>
    /// The class of tut.by page
    /// </summary>
    public class TutByPage
    {
        private IWebDriver _driver;
        private IWebElement _exchangeRatesTable;
        private List<IWebElement> _currencyNames = new List<IWebElement>();
        private List<IWebElement> _exchangeRates = new List<IWebElement>();

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="driver">Webdriver</param>
        public TutByPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(10));
            this._exchangeRatesTable = wait.Until(drv => drv.FindElement(By.XPath("//table[@class = 'w-currency_table']")));
            this._currencyNames = this._exchangeRatesTable.FindElements(By.XPath(".//tr//td[@align= 'left']")).ToList();

            foreach (IWebElement currencyName in this._currencyNames)
            {
                this._exchangeRates.Add(this._exchangeRatesTable.FindElement(By.XPath($"//tr[.//a[contains(text(), '{currencyName.Text}')]]//p")));
            }
        }

        /// <summary>
        /// Returns list of currencies
        /// </summary>
        /// <returns>List of currencies</returns>
        public List<Currency> GetExchangeRates()
        {
            List<Currency> currencies = new List<Currency>();

            for (int i = 0; i < this._currencyNames.Count; i++)
            {
                currencies.Add(new Currency(this._currencyNames[i].Text, this._exchangeRates[i].Text));
            }

            return currencies;
        }
    }
}
