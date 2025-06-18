namespace SmartTray.Domain.Models
{
    public class TraySensorReading
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double UvReading { get; set; }
        public bool WaterAdded { get; set; }
        public bool UvLedsOn { get; set; }
    }
}
