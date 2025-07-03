using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50).HasColumnName("name");
            builder.Property(e => e.Email).IsRequired().HasMaxLength(80).HasColumnName("email");
            builder.Property(p => p.PasswordHash).IsRequired().HasMaxLength(100).HasColumnName("password_hash");
            builder.Property(s => s.Salt).IsRequired().HasMaxLength(10).HasColumnName("salt");
            builder.Property(p => p.Postcode).IsRequired().HasMaxLength(10).HasColumnName("post_code");
        }
    }
}
