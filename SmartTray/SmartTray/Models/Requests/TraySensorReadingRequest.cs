namespace SmartTray.API.Models.Requests
{
    public class TraySensorReadingRequest
    {
        // The temperature reading from the sensor is a float, need to be converted in the mapper to int before store into database
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public int UvReading { get; set; }
        public bool WaterAdded { get; set; }
        public bool UvLedsOn { get; set; }
        public bool HeatingMatOn { get; set; }
    }
}
