namespace CinemaCity.Core
{
    public interface IConfigurationManager
    {
        string GetChromeDriverDirectory();
        string GetCinemaCityURL();
        string GetTakenSeatCode();
        string GetAvailableSeatCode();
        string GetChosenSeatCode();
        string GetKfarSabaCode();
        string GetGlilotCode();
        string GetRashlatzCode();
        string GetParkCode();
        string GetRaananCode();
        string GetJerusalemCode();
        string GetAjaxPath(string cinema);
    }
}
