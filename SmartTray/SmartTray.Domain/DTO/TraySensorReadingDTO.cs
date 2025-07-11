namespace SmartTray.Domain.DTO
{
    public class TraySensorReadingDTO
    {
        public int DailyLightMinutes { get; set; }
        public int ArtificialLightMinutes { get; set; }
        public int SolarLightMinutes { get; set; }
        public int RemainingLightMinutes { get; set; }
    }
}
