using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Configurations
{
    public class FriendShipConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("friends").HasKey(a=> new {a.profileId,a.friendId});
            builder.HasOne(a => a.profile).WithMany(a => a.FriendsTo).HasForeignKey(a => a.profileId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(a => a.friend).WithMany(a => a.FriendsFrom).HasForeignKey(a => a.friendId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
