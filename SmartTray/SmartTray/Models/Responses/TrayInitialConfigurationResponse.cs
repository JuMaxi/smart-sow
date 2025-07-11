namespace SmartTray.API.Models.Responses
{
    public class TrayInitialConfigurationResponse : TraySettingsResponse
    {
        public int TargetLightMinutes { get; set; }
        public int DailyLightMinutes { get; set; }
        public int RemainingLightMinutes { get; set; }
    }
}
