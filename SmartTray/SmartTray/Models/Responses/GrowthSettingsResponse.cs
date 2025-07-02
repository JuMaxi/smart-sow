namespace SmartTray.API.Models.Responses
{
    public class GrowthSettingsResponse
    {
        public DateTime RegisterDate { get; set; }
        public int TemperatureCelsius { get; set; }
        public int Humidity { get; set; }
        public int DailySolarHours { get; set; }
    }
}
