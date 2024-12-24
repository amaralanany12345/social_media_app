using Microsoft.Extensions.Configuration.UserSecrets;

namespace Medical.Models
{
    public class Profile
    {
        public int id { get; set; }
        public User user { get; set; }
        public int userId { get; set; }
        public ICollection<FriendRequests> SentFriendRequests { get; set; } = new List<FriendRequests>();
        public ICollection<FriendRequests> ReceievedFriendRequests { get; set; } = new List<FriendRequests>();
        public ICollection<Friend> FriendsTo { get; set; } = new List<Friend>();
        //public ICollection<Friend> FriendsFrom { get; set; } = new List<Friend>();
        public ICollection<Post> posts { get; set; } = new List<Post>();
        public ICollection<Comment> comments{ get; set; } = new List<Comment>();
        public ICollection<PostLike> postLikes { get; set; } = new List<PostLike>();
        public ICollection<CommentLike> commentLikes { get; set; } = new List<CommentLike>();


    }
}
