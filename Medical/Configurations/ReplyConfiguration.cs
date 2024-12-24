using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable("replies").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.reply).IsRequired().HasMaxLength(255);
            builder.HasOne(a => a.parentComment).WithMany(a => a.replies).HasForeignKey(a => a.parentCommentID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
