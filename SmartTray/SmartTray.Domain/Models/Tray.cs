namespace SmartTray.Domain.Models
{
    public enum Status
    {
        Inactive = 0,
        Active = 1
    }
    public class Tray
    {
        public int Id { get; set; }

        // A tray is related to a User, it is a FK
        public User User { get; set; }

        // User gives a name to a seed tray to identify it
        public string Name { get; set; }

        // User specify the type of plant will be grow (kind of seed)
        public string CropType { get; set; }

        // User specify the date of sowing fro having a control between sowing and time to transplant the baby plant
        public DateTime SowingDate { get; set; }

        // User can deactivate the tray
        public Status Status { get; set; }

        public TraySettings Settings { get; set; }
    }
}
