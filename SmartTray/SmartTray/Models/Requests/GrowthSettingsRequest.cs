namespace SmartTray.API.Models.Requests
{
    public class GrowthSettingsRequest
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double LightTime { get; set; }

    }
}
