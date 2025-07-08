namespace SmartTray.API.Models.Responses
{
    public class TraySensorReadingDTOResponse
    {
        public int TargetLightMinutes { get; set; }
        public double DailyLightMinutes { get; set; }
        public int ArtificialLightMinutes { get; set; }
        public int SolarLightMinutes { get; set; }
        public double RemainingLightMinutes { get; set; }
    }
}
