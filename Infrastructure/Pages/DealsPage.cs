using System.Threading;
using CinemaCity.Core;
using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public class DealsPage
    {
        public IWebDriver Driver { get; set; }

        private readonly IConfigurationManager _configuration;

        private readonly IWebElement _mainElement;

        public DealsPage(IWebDriver driver, IConfigurationManager configuration)
        {
            Driver = driver;
            _configuration = configuration;
            _mainElement = driver.FindElement(By.Id("ctl00_pageBody"));
        }

        public PaymentPage Submit()
        {
            _mainElement.FindElement(By.Id("ctl00_CPH1_WebTixsButtonControl1")).Click();
            Thread.Sleep(3000);
            return new PaymentPage(Driver, _configuration);
        }

        public SeatsPage BackToSeatsPage()
        {
            _mainElement.FindElement(By.CssSelector("#ctl00_CPH1_BackButtonControl1_webtixsButtonClientSide>a"))
                .Click();
            Thread.Sleep(2000);
            return new SeatsPage(Driver, _configuration);
        }
    }
}
