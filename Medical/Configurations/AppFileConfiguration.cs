using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class AppFileConfiguration : IEntityTypeConfiguration<AppFiles>
    {
        public void Configure(EntityTypeBuilder<AppFiles> builder)
        {
            builder.ToTable("files").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.fileName).IsRequired().HasMaxLength(400);
            builder.Property(a => a.filePath).IsRequired().HasMaxLength(400);

        }
    }
}
