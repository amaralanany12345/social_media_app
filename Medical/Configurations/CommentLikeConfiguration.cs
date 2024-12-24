using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.ToTable("commentLikes").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(a => a.comment).WithMany(a => a.commentLikes).HasForeignKey(a => a.commentId);
            builder.HasOne(a => a.profile).WithMany(a => a.commentLikes).HasForeignKey(a => a.profileId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
