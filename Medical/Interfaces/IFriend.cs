using Medical.Models;

namespace Medical.Interfaces
{
    public interface IFriend
    {
        FriendRequests addFreind(int sendedProfileId, int receivedProfileId);
        void acceptRequest(int sendedProfileId, int receivedProfileId);
        void cancelRequest(int sendedProfileId, int receivedProfileId);
        ICollection<FriendRequests> getAllProfileSendedRequest(int profileId);
        ICollection<FriendRequests> getAllProfileRecievedRequest(int profileId);
        ICollection<Profile> getAllProfileFriends(int profileId);

    }
}
