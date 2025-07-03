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
        }
    }
}
