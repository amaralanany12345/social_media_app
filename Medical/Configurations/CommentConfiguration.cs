using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.comment).IsRequired().HasMaxLength(255);
            builder.HasOne(a => a.post).WithMany(a => a.comments).HasForeignKey(a => a.postId);
            builder.HasOne(a => a.commentImage).WithOne().HasForeignKey<Comment>(a => a.commentImageId);
            builder.HasOne(a => a.profile).WithMany(a => a.comments).HasForeignKey(a => a.profileId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
