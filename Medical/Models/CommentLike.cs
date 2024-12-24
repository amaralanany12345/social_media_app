namespace Medical.Models
{
    public class CommentLike:Like
    {
        public Comment comment { get; set; }
        public int commentId { get; set; }
    }
}
