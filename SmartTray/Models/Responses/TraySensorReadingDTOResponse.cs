namespace SmartTray.API.Models.Responses
{
    public class TraySensorReadingDTOResponse
    {
        public int DailyLightMinutes { get; set; }
        public int ArtificialLightMinutes { get; set; }
        public int SolarLightMinutes { get; set; }
        public int RemainingLightMinutes { get; set; }

        public int Humidity { get; set; }
    }
}
