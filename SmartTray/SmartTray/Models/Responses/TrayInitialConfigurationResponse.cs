namespace SmartTray.API.Models.Responses
{
    public class TrayInitialConfigurationResponse : TraySettingsResponse
    {
        // This is the humidity in a number that humidity sensor in the arduino understand
        // The numbers usually are between 2000 and 3000. Greater the number, dryer is the soil.
        public int Humidity { get; set; }

        // This is the daily uv minutos that the tray has already had over the current day
        public int DailyLightMinutes { get; set; }
        // This is the remaining daily uv minutos that the trat still needs. Target setting in minutes less daily light in minutes
        public int RemainingLightMinutes { get; set; }
    }
}
