namespace Medical.Models
{
    public class Post
    {
        public int id { get; set; }
        public string post { get; set; }
        public Profile profile { get; set; }
        public int profileId { get; set; }
        public AppFiles? postImage { get; set; }
        public int? postImageId { get; set; }
        public ICollection<Comment> comments { get; set; } = new List<Comment>();
        public ICollection<PostLike> postLikes { get; set; } = new List<PostLike>();

    }
}
