namespace Medical.Models
{
    public class Friend
    {
        public int profileId { get; set; }
        public Profile profile { get; set; }
        public int friendId { get; set; }
        public User friend { get; set; }

    }
}
