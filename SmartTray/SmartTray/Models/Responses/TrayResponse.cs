namespace SmartTray.API.Models.Responses
{
    public class TrayResponse
    {
        public string Name { get; set; }
        public string CropType { get; set; }
        public DateTime SowingDate { get; set; }
        public TraySettingsResponse Settings { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
    }
}
