using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using CinemaCity.Core;
using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public class PaymentPage
    {
        public event Action<DealsPage> CountDownTimeIsUp;
        protected IWebDriver Driver { get; set; }

        private readonly IConfigurationManager _configuration;

        private readonly IWebElement _mainElement;

        public PaymentPage(IWebDriver driver, IConfigurationManager configuration)
        {
            Driver = driver;
            _configuration = configuration;
            _mainElement = driver.FindElement(By.Id("ctl00_pageBody"));
            IsCountDownTimeIsUp();
        }

        public DealsPage BackToDealsPage()
        {
            _mainElement.FindElement(By.Id("ctl00_CPH1_BackButtonControl1_webtixsButtonClientSide")).Click();
            Thread.Sleep(3000);
            return new DealsPage(Driver, _configuration);
        }

        private void IsCountDownTimeIsUp()
        {
            IWebElement countDownElement =
                _mainElement.FindElement(By.Id("ctl00_CPH1_OrderFormControl1_SessionInfoTimerControl1_cntDown"));
            Task t = Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        countDownElement.FindElement(By.TagName("b"));
                        Thread.Sleep(10000);
                    }
                }
                catch (NoSuchElementException)
                {
                    CountDownTimeIsUp?.Invoke(BackToDealsPage());
                }
            });
        }
    }
}