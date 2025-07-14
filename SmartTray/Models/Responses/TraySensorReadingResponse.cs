namespace SmartTray.API.Models.Responses
{
    public class TraySensorReadingResponse
    {
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int UvReading { get; set; }
        public bool WaterAdded { get; set; }
        public bool UvLedsOn { get; set; }
        public bool HeatingMatOn { get; set; }
    }
}
