using System.Threading;
using CinemaCity.Core;
using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public class TicketsPage
    {
        public IWebDriver Driver { get; set; }

        private readonly IWebElement _mainElement;
        private readonly IConfigurationManager _configuration;

        private string TicketsAmount
        {
            set
            {
                IWebElement amountElement = _mainElement.FindElement(By.ClassName("ddlTicketQuantity"));
                amountElement.SendKeys(value);
                Thread.Sleep(1000);
                amountElement.SendKeys(Keys.Enter);
            }
        }

        public TicketsPage(IWebDriver driver, IConfigurationManager configuration)
        {
            Driver = driver;
            _configuration = configuration;
            _mainElement = driver.FindElement(By.Id("ctl00_pageBody"));
        }

        public SeatsPage Submit(string amount)
        {
            TicketsAmount = amount;
            _mainElement.FindElement(By.Id("ctl00_CPH1_lbNext1")).Click();
            Thread.Sleep(2000);
            return new SeatsPage(Driver, _configuration);
        }
    }
}
