using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.post).IsRequired().HasMaxLength(255);
            builder.HasOne(a => a.postImage).WithOne().HasForeignKey<Post>(a => a.postImageId);
            builder.HasOne(a => a.profile).WithMany(a => a.posts).HasForeignKey(a => a.profileId);
        }
    }
}
