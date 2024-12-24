namespace Medical.Models
{
    public class Reply
    {
        public int id { get; set; }
        public string reply { get; set; }
        public int parentCommentID { get; set; }
        public Comment parentComment { get; set; }

    }
}
