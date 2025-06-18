namespace SmartTray.Domain.Models
{
    public class Tray
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CropType { get; set; }
        public DateTime SowingDate { get; set; }
    }
}
