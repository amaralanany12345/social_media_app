using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class PostLikesConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.ToTable("postLikes").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(a => a.post).WithMany(a => a.postLikes).HasForeignKey(a => a.postId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.profile).WithMany(a => a.postLikes).HasForeignKey(a => a.profileId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
