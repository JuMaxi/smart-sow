namespace SmartTray.API.Models.Requests
{
    public class TraySensorReadingRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double UvReading { get; set; }
        public bool WaterAdded { get; set; }
        public bool UvLedsOn { get; set; }
    }
}
