using System;
using System.Linq;
using System.Threading;
using CinemaCity.Core;
using Infrastructure.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CinemaCitySeatsReservation
{
    public class Program
    {
        public static IConfigurationManager Configuration = new ConfigurationManager();

        public static void Main(string[] args)
        {
            string cinema = "סינמה סיטי כפר-סבא";
            var a = AjaxParser.Parse(Configuration.GetAjaxPath(cinema));
            ReservationManager reservationManager = new ReservationManager(cinema, a.First().Name, a.First().DateTime.Last().Key, a.First().DateTime.Last().Value.First());
            reservationManager.OrderTickets
                (
                    "8",
                    new[] { "8", "9", "10" }
                );
        }
    }
}
