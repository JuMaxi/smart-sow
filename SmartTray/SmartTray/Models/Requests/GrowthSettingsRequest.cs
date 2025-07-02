namespace SmartTray.API.Models.Requests
{
    public class GrowthSettingsRequest
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int LightTime { get; set; }

    }
}
