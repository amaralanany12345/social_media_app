namespace Medical.Models
{
    public class PostLike:Like
    {
        public Post post { get; set; }
        public int postId { get; set; }
    }
}
