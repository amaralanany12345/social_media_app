using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.name).IsRequired().HasMaxLength(255);
            builder.Property(a => a.email).IsRequired().HasMaxLength(255);
            builder.Property(a => a.password).IsRequired().HasMaxLength(255);
        }
    }
}
