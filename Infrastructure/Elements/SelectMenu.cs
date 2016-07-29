using System;
using System.Linq;
using System.Threading;
using CinemaCity.Core;
using Infrastructure.Pages;
using OpenQA.Selenium;

namespace Infrastructure.Elements
{
    public class SelectMenu
    {
        private readonly IConfigurationManager _configuration;
        private IWebDriver Driver { get; }
        private IWebElement MainElement { get; }

        public string Cinema
        {
            set
            {
                IWebElement cinema = MainElement.FindElement(By.ClassName("scheduleDropBox_subSite"));
                cinema.Click();
                cinema.FindElements(By.TagName("option"))
                    .First(element => element.Text.Contains(value))
                    .Click();
                //.FindElement(By.CssSelector($"option[value=\"{value}\"]"))
                //    .Click();
                Thread.Sleep(1000);
            }
        }

        public string Movie
        {
            set
            {
                IWebElement movie = MainElement.FindElement(By.ClassName("scheduleDropBox_feature"));
                movie.Click();
                movie.FindElements(By.TagName("option"))
                    .First(element => element.Text.Contains(value))
                    .Click();
                //.FindElement(By.CssSelector($"option[value=\"{value}\"]"))
                //    .Click();
                Thread.Sleep(1000);
            }
        }

        public string Date
        {
            set
            {
                IWebElement date = MainElement.FindElement(By.ClassName("scheduleDropBox_date"));
                date.Click();
                date.FindElements(By.TagName("option"))
                    .First(element => element.Text.Contains(value))//By.CssSelector($"option[value=\"{value}\"]")) 
                    .Click();
                Thread.Sleep(1000);
            }

        }

        public string Time
        {
            set
            {
                IWebElement time = MainElement.FindElement(By.ClassName("scheduleDropBox_time"));
                time.Click();
                time.FindElements(By.TagName("option"))
                    .First(element => element.Text.Contains(value)) //FindElement(By.CssSelector($"option[value=\"{value}\"]")).Click();
                    .Click();

                Thread.Sleep(1000);
            }
        }

        public SelectMenu(IWebDriver driver, IWebElement mainElement, IConfigurationManager configuration)
        {
            _configuration = configuration;
            Driver = driver;
            MainElement = mainElement.FindElement(By.ClassName("scheduleDropBoxExtended"));
        }

        public TicketsPage Submit()
        {
            MainElement.FindElement(By.TagName("input")).Click();

            Thread.Sleep(3000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Driver.Manage().Window.Maximize();

            return new TicketsPage(Driver, _configuration);
        }
    }
}
