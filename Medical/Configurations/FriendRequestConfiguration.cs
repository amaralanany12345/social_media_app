using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequests>
    {
        public void Configure(EntityTypeBuilder<FriendRequests> builder)
        {
            builder.ToTable("friendRequests").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(a => a.sendedProfile).WithMany(a => a.SentFriendRequests).HasForeignKey(a => a.sendedProfileId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.recievedProfile).WithMany(a => a.ReceievedFriendRequests).HasForeignKey(a => a.recievedProfileId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
