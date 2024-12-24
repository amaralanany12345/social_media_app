using Medical.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical.General
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<PostLike> postLikes { get; set; }
        public DbSet<CommentLike> commentLikes { get; set; }
        public DbSet<Reply> replies { get; set; }
        public DbSet<AppFiles> files { get; set; }
        public DbSet<FriendRequests> friendRequests { get; set; }
        public DbSet<Friend> friends { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-NNDJ4G3D\SQLEXPRESS; Database=SocilaMedia; Integrated Security=SSPI; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
