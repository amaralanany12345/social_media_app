namespace Medical.Models
{
    public class FriendRequests
    {
        public int id { get; set; }
        public Profile sendedProfile { get; set; }
        public int sendedProfileId { get; set; }
        public Profile recievedProfile { get; set; }
        public int recievedProfileId { get; set; }

    }
}
