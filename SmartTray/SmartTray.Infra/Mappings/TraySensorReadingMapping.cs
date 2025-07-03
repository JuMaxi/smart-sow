using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Mappings
{
    public class TraySensorReadingMapping : IEntityTypeConfiguration<TraySensorReading>
    {
        public void Configure(EntityTypeBuilder<TraySensorReading> builder)
        {
            builder.ToTable("tray_sensor_readings");
            builder.HasKey(k => k.Id);
            // One tray has many sensor readings. While deleting a tray, the sensor readings musn't be deleted automatically (cascade) 
            builder.HasOne(t => t.Tray).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(d => d.Date).IsRequired().HasColumnName("date");
            builder.Property(t => t.Temperature).IsRequired().HasMaxLength(2).HasColumnName("temperature_celsius");
            builder.Property(h => h.Humidity).IsRequired().HasMaxLength(1).HasColumnName("humidity");
            builder.Property(u => u.UV).IsRequired().HasMaxLength(2).HasColumnName("uv");
            builder.Property(w => w.WaterAdded).IsRequired().HasColumnName("water_added");
            builder.Property(uv => uv.UvLedsOn).IsRequired().HasColumnName("uv_leds_on");
            builder.Property(h => h.HeatingMatOn).IsRequired().HasColumnName("heating_mat_on");
        }
    }
}
