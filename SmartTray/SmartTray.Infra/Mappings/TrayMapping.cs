using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Mappings
{
    public class TrayMapping : IEntityTypeConfiguration<Tray>
    {
        public void Configure(EntityTypeBuilder<Tray> builder)
        {
            builder.ToTable("tray");
            builder.HasKey(k => k.Id);
            builder.HasOne(u => u.User).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50).HasColumnName("name");
            builder.Property(c => c.CropType).IsRequired().HasMaxLength(50).HasColumnName("crop_type");
            builder.Property(s => s.SowingDate).IsRequired().HasColumnName("sowing_date");
            builder.Property(st => st.Status).IsRequired().HasColumnName("status").HasDefaultValue(Status.Active);
            builder.Property(t => t.Token).IsRequired().HasMaxLength(10).HasColumnName("token");
        }
    }
}
