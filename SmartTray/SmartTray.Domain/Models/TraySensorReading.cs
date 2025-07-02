namespace SmartTray.Domain.Models
{
    public class TraySensorReading
    {
        public int Id { get; set; }

        // The sensor reading is related to a seed tray, it is a FK.
        public Tray Tray { get; set; }

        // The date and time of the readings for having data to show in the front-end charts.
        public DateTime Date { get; set; }

        // The temperature sensor returns the current temperature as an int (still need testing it).
        public int Temperature { get; set; }

        // The humidity sensor reading returns an int.
        // My reference number after tests are: 2100 HighHumidity, 2500 MediumHumidity, 2700 LowHumidity, more than it is no humidity.
        public int Humidity { get; set; }

        // The UV sensor reading returns an int. 
        // After tests: returning 0 = no UV
        public int UV { get; set; }

        // If the sensor reading detected the humidity is lower than the target, this variable will change to true.
        // Using the variable to control how many times water as added.
        public bool WaterAdded { get; set; }

        // If the sensor reading detected the UV is equal to 0, than artificial UV leds are turned ON.
        // Using this variable to control how many times/hours the leds were turned on.
        public bool UvLedsOn { get; set; }

        // If the sensor reading detected the current temperature is less than the target, it turns on the heating mat.
        // Using this variable to control how many times/hours the rug was turned on.
        public bool HeatingMatOn { get; set; }
    }
}
