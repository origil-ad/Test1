using CinemaCity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using Infrastructure.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CinemaCitySeatsReservation
{
    public class ReservationManager
    {
        public event Action CancelProgram;
        public event Action FinishRound;

        private string _cinema;
        private string _movie;
        private string _date;
        private string _time;
        private string _row;
        private string[] _seats;
        private bool _toContinue = true;

        private readonly IConfigurationManager _configuration = new ConfigurationManager();
        private IWebDriver _chrome;
        private IEnumerable<MovieMetadata> _moviesMetadatas;

        public ReservationManager()
        {
        }

        public ReservationManager(string cinema, string movie, string date, string time)
        {
            _cinema = cinema;
            _movie = movie;
            _date = date;
            _time = time;
        }

        public IEnumerable<string> GetMoviesByCinema(string cinema)
        {
            _cinema = cinema;
            _moviesMetadatas = AjaxParser.Parse(_configuration.GetAjaxPath(cinema));
            return _moviesMetadatas.Select(m => m.Name);
        }

        public IEnumerable<string> GetDatesByMovie(string movie)
        {
            _movie = movie;
            var chosenMovie = _moviesMetadatas.First(m => m.Name == movie);
            return chosenMovie.DateTime.Select(date => date.Key);
        }

        public IEnumerable<string> GetTimesByDate(string date)
        {
            _date = date;
            return _moviesMetadatas.First(m => m.Name == _movie).DateTime[date];
        }

        public void SetTime(string time)
        {
            _time = time;

        }
        public void OrderTickets(string row, string[] seats)
        {
            _row = row;
            _seats = seats;

            _chrome = new ChromeDriver(_configuration.GetChromeDriverDirectory());
            try
            {
                CinemaCityMainPage cinemaPage = new CinemaCityMainPage(_chrome, _configuration)
                {
                    SelectMenu =
                    {
                        Cinema = _cinema,
                        Movie = _movie,
                        Date = _date,
                        Time = _time 
                    }
                };

                TicketsPage ticketsPage = cinemaPage.SelectMenu.Submit();

                SeatsPage seatsPage = ticketsPage.Submit(string.Format("{0}", seats.Length));

                DealsPage dealsPage = seatsPage.ChooseSeatsAndSubmit(_row, _seats);

                PaymentPage paymentPage = dealsPage.Submit();
                paymentPage.CountDownTimeIsUp += TryOrderAgain;
                FinishRound?.Invoke();

                while (_toContinue)
                {
                    Thread.Sleep(20000);
                }

                dealsPage = paymentPage.BackToDealsPage();
                seatsPage = dealsPage.BackToSeatsPage();
                seatsPage.CancelSeats(_row, _seats);
                //seatsPage.BackToTicketsPage();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (_chrome != null)
                {
                    _chrome.Dispose();
                }
                CancelProgram?.Invoke();
            }
        }

        private void TryOrderAgain(DealsPage dealsPage)
        {
            if (_toContinue)
            {
                try
                {
                    SeatsPage seatsPage = dealsPage.BackToSeatsPage();

                    dealsPage = seatsPage.ChooseSeatsAndSubmit(_row, _seats);

                    PaymentPage paymentPage = dealsPage.Submit();
                    paymentPage.CountDownTimeIsUp += TryOrderAgain;
                }
                catch (Exception)
                {
                    CancelProgram?.Invoke();
                } 
            }
        }

        public void Cancel()
        {
            _toContinue = false;
        }
    }
}
