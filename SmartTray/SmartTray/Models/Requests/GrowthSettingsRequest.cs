namespace SmartTray.API.Models.Requests
{
    public class GrowthSettingsRequest
    {
        public double TemperatureCelsius { get; set; }
        public double Humidity { get; set; }
        public double DailySolarHours { get; set; }
        public double TodaySolarHours { get; set; }
    }
}
