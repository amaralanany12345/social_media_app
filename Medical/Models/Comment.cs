namespace Medical.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string comment { get; set; }
        public Post post { get; set; }
        public int postId { get; set; }
        public Profile profile { get; set; }
        public int profileId { get; set; }
        public AppFiles commentImage { get; set; }
        public int? commentImageId { get; set; } 
        public ICollection<CommentLike> commentLikes { get; set; } = new List<CommentLike>();
        public ICollection<Reply> replies { get; set; } = new List<Reply>();
    }
}
