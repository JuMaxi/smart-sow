namespace SmartTray.API.Models.Requests
{
    public class TraySettingsRequest
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int LightTime { get; set; }

    }
}
