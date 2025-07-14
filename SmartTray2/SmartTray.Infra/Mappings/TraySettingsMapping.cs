using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Mappings
{
    public class TraySettingsMapping : IEntityTypeConfiguration<TraySettings>
    {
        public void Configure(EntityTypeBuilder<TraySettings> builder)
        {
            builder.ToTable("tray_settings");
            builder.HasKey(k => k.Id);
            builder.HasOne(t => t.Tray).WithOne(x => x.Settings).HasForeignKey<Tray>("tray_settings_id").OnDelete(DeleteBehavior.NoAction);
            builder.Property(d => d.RegisterDate).IsRequired().HasColumnName("register_date");
            builder.Property(t => t.TemperatureCelsius).IsRequired().HasColumnName("temperature_celsius");
            builder.Property(h => h.Humidity).IsRequired().HasColumnName("humidity").HasDefaultValue(HumidityLevel.Disabled);
            builder.Property(s => s.DailySolarHours).IsRequired().HasColumnName("daily_solar_hours");
        }
    }
}
