﻿using System.Linq;
using System.Threading;
using CinemaCity.Core;
using Infrastructure.Extensions;
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
                    ChooseSeat(row, seat, _configuration.GetChosenSeatCode());
                }
            }
            return isSeatsChosen;
        }

        private bool ChooseSeat(string row, string seat, string desirableSeatCode)
        {
            IWebElement seatElement;
            bool isSeatExist = _mainElement.TryFindElement(By.Id(string.Format("_Seat_{0}_{1}", row, seat)), out seatElement);

            if (!isSeatExist)
            {
                return false;
            }

            string seatCode = GetSeatCode(seatElement);

            if (seatCode.Equals(_configuration.GetTakenSeatCode()))
            {
                return false; //TODO return FindBestClosetSeat
            }

            if (seatCode.Equals(desirableSeatCode))
            {
                seatElement.Click();
                //TODO: check if seat turn as wanted
            }

            Thread.Sleep(300);
            return true;
        }

        private string GetSeatCode(IWebElement seatElement)
        {
            string style = seatElement.GetAttribute("style");
            style = style.Remove(style.Length - 3);
            return style.Last().ToString();
        }

        private DealsPage Submit()
        {
            _mainElement.FindElement(By.Id("ctl00_CPH1_SPC_lnkSubmit")).Click();
            Thread.Sleep(3000);
            return new DealsPage(Driver, _configuration);
        }
    }

   
}