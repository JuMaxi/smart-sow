namespace SmartTray.Domain.Models
{
    public class GrowthSettings
    {
        public int Id { get; set; }

        public Tray TrayId { get; set; }
        public DateTime RegisterDate { get; set; }
        public double TemperatureCelsius { get; set; }
        public double Humidity { get; set; }
        public double DailySolarHours { get; set; }
    }
}
