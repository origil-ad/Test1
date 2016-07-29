using System.Threading;
using CinemaCity.Core;
using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public class SeatsPage
    {
        public IWebDriver Driver { get; set; }

        private readonly IConfigurationManager _configuration;

        private readonly IWebElement _mainElement;

        public SeatsPage(IWebDriver driver, IConfigurationManager configuration)
        {
            _configuration = configuration;
            Driver = driver;
            _mainElement = driver.FindElement(By.Id("ctl00_pageBody"));
        }


        public DealsPage ChooseSeatsAndSubmit(string row, string[] seats, bool undo = false)
        {
            ClickOnSeats(row, seats, undo);

            Thread.Sleep(300);
            return Submit();
        }

        public DealsPage CancelSeats(string row, string[] seats)
        {
            ClickOnSeats(row, seats, true);
            return ChooseSeatsAndSubmit("2", seats);
        }

        public TicketsPage BackToTicketsPage()
        {
            _mainElement.FindElement(By.Id("ctl00_CPH1_SPC_BackButtonControl2_webtixsButtonClientSide")).Click();
            Thread.Sleep(3000);
            return new TicketsPage(Driver, _configuration);
        }

        private bool ClickOnSeats(string row, string[] seats, bool undo)
        {
            bool isSeatsChosen = true;
            row = (int.Parse(row) + 1).ToString();
            foreach (string seat in seats)
            {
                if (!undo)
                {
                    if (!ChooseSeat(row, seat, _configuration.GetAvailableSeatCode()))
                    {
                        isSeatsChosen = false;
                    }
                }

                else
                {
                    if (!ChooseSeat(row, seat, _configuration.GetChosenSeatCode()))
                    {
                        isSeatsChosen = false;
                    }
                }
            }
            return isSeatsChosen;
        }

        private bool ChooseSeat(string row, string seat, string desirableSeatCode)
        {
            IWebElement seatElement;
            var isSeatExist = _mainElement.TryFindElement(By.Id(string.Format("_Seat_{0}_{1}", row, seat)), out seatElement);

            if (isSeatExist)
            {
                return false;
            }

            string style = seatElement.GetAttribute("style");

            style = style.Remove(style.Length - 3);

            if (style.EndsWith(_configuration.GetTakenSeatCode()))
            {
                return false;
            }

            if (style.EndsWith(desirableSeatCode))
            {
                seatElement.Click();
            }

            Thread.Sleep(300);
            return true;
        }

        private DealsPage Submit()
        {
            _mainElement.FindElement(By.Id("ctl00_CPH1_SPC_lnkSubmit")).Click();
            Thread.Sleep(3000);
            return new DealsPage(Driver, _configuration);
        }
    }

    public static class Extensions
    {
        public static bool TryFindElement(this IWebElement mainElement, By by, out IWebElement element)
        {
            try
            {
                element = mainElement.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                element = null;
                return false;
            }
            return true;
        }
    }
}