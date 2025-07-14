namespace SmartTray.Domain.Models
{
    public enum HumidityLevel
    {
        Disabled = 0,
        LowHumidity = 1,
        MediumHumidity = 2,
        HighHumidity = 3
    }
    public class TraySettings
    {
        public int Id { get; set; }

        // The growth settings (target) are related to a seed tray a FK
        public Tray Tray { get; set; }

        // Date to control when the settings were target
        public DateTime RegisterDate { get; set; }

        // The temperature target to the tray seed. A number between 15 and 30.
        public int TemperatureCelsius { get; set; }

        // The user must choose a humidity level from 0 to 3
        public HumidityLevel Humidity { get; set; }

        // The user must choose the quantity of daily solar hours. A number between 1 and 24. 
        public int DailySolarHours { get; set; }
    }
}
