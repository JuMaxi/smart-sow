namespace SmartTray.API.Models.Responses
{
    public class GrowthSettingsResponse
    {
        public DateTime RegisterDate { get; set; }
        public double TemperatureCelsius { get; set; }
        public double Humidity { get; set; }
        public double DailySolarHours { get; set; }
    }
}
