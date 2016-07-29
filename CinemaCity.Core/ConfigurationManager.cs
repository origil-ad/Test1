using System;

namespace CinemaCity.Core
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetChromeDriverDirectory()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ChromeDriverPath"];
        }

        public string GetCinemaCityURL()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaCityURL"];
        }

        public string GetTakenSeatCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["TakenSeat"];
        }

        public string GetAvailableSeatCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["AvailableSeat"];
        }

        public string GetChosenSeatCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ChosenSeat"];
        }

        public string GetKfarSabaCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["כפר סבא"];
        }

        public string GetGlilotCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaGlilot"];
        }

        public string GetRashlatzCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaRashlatz"];
        }

        public string GetParkCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaPark"];
        }

        public string GetRaananCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaRaanan"];
        }

        public string GetJerusalemCode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CinemaJerusalem"];
        }

        public string GetAjaxPath(string cinema)
        {
            return System.Configuration.ConfigurationManager.AppSettings[cinema];
        }
    }
}
