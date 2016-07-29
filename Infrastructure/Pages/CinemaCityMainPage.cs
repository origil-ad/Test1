using System.Threading;
using CinemaCity.Core;
using Infrastructure.Elements;
using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public class CinemaCityMainPage
    {
        private IWebDriver Driver { get; }
        private IWebElement MainElement { get; }
        public SelectMenu SelectMenu { get; set; }

        public CinemaCityMainPage(IWebDriver driver, IConfigurationManager configuration)
        {
            Driver = driver;
            InitPage(configuration);
            MainElement = driver.FindElement(By.ClassName("home"));
            SelectMenu = new SelectMenu(Driver, MainElement, configuration);
        }

        private void InitPage(IConfigurationManager configuration)
        {
            Driver.Navigate().GoToUrl(configuration.GetCinemaCityURL());
            Thread.Sleep(3000);
        }
    }


}
