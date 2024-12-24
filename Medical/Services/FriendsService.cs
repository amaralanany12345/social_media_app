using Medical.General;
using Medical.Interfaces;
using Medical.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medical.Services
{
    public class FriendsService : IFriend
    {
        AppDbContext context;
        public FriendsService()
        {
            context = new AppDbContext();
        }
        

        public void acceptRequest(int sendedProfileId, int receivedProfileId)
        {
            
            var friendRequest = (from item in context.friendRequests where item.sendedProfileId ==sendedProfileId && item.recievedProfileId== receivedProfileId select item).FirstOrDefault();
            if(friendRequest == null)
            {
                throw new ArgumentException("friend request is not found");
            }
            
            var receivedProfile = (from item in context.profiles where item.id == receivedProfileId select item).FirstOrDefault();
            if (receivedProfile == null)
            {
                throw new ArgumentException("recieved profile is not found");
            }

            var sendedProfile = (from item in context.profiles where item.id == sendedProfileId select item).FirstOrDefault();
            if (sendedProfile == null)
            {
                throw new ArgumentException("sended profile is not found");
            }
            var fristFriend = (from item in context.users where item.id == receivedProfile.userId select item).FirstOrDefault();
            if(fristFriend == null)
            {
                throw new ArgumentException("friend is not found");
            }

            var sendedProfileFriend = new Friend();
            sendedProfileFriend.profile = sendedProfile;
            sendedProfileFriend.profileId = sendedProfileId;
            sendedProfileFriend.friend = fristFriend;
            sendedProfileFriend.friendId = fristFriend.id;

            sendedProfile.FriendsTo.Add(sendedProfileFriend);
            context.friends.Add(sendedProfileFriend);

            var secondFriend = (from item in context.users where item.id == sendedProfile.userId select item).FirstOrDefault();
            if (secondFriend == null)
            {
                throw new ArgumentException("friend is not found");
            }

            var receivedProfileFriend = new Friend();
            receivedProfileFriend.profile = receivedProfile;
            receivedProfileFriend.profileId = receivedProfileId;
            receivedProfileFriend.friend = secondFriend;
            receivedProfileFriend.friendId = secondFriend.id;

            receivedProfile.FriendsTo.Add(receivedProfileFriend);
            context.friends.Add(receivedProfileFriend);

            context.friendRequests.Remove(friendRequest);
            context.SaveChanges();

        }

        public FriendRequests addFreind(int sendedProfileId, int recievedProfileId)
        {
            var sendedProfile = (from item in context.profiles where item.id == sendedProfileId select item).FirstOrDefault();
            if(sendedProfile == null)
            {
                throw new ArgumentException("sended profile is not found");
            }
            var recievedProfile = (from item in context.profiles where item.id == recievedProfileId select item).FirstOrDefault();
            if (recievedProfile == null)
            {
                throw new ArgumentException("recieved profile is not found");
            }
            var applicableAddFriend = (from item in context.friendRequests where item.recievedProfileId == recievedProfileId && item.sendedProfileId == sendedProfileId select item).FirstOrDefault();
            if (applicableAddFriend != null)
            {
                throw new ArgumentException("you add this request friend before");
            }
            var existedFriend = (from item in context.friends where (item.profileId == sendedProfileId && item.friendId == recievedProfile.userId) ||
                               (item.profileId == recievedProfileId && item.friendId == sendedProfile.userId) select item ).FirstOrDefault();
            if(existedFriend != null)
            {
                throw new ArgumentException("you are already friends");
            }

            var newFriendRequest = new FriendRequests();
            newFriendRequest.sendedProfile = sendedProfile;
            newFriendRequest.sendedProfileId = sendedProfileId;
            newFriendRequest.recievedProfile = recievedProfile;
            newFriendRequest.recievedProfileId = recievedProfileId;
            context.friendRequests.Add(newFriendRequest);
            context.SaveChanges();
            return newFriendRequest;
        }

        public ICollection<FriendRequests> getAllProfileRecievedRequest(int profileId)
        {
            var allReceivedRequests = (from item in context.friendRequests where item.recievedProfileId == profileId select item).ToList();
            return allReceivedRequests;
        }

        public ICollection<FriendRequests> getAllProfileSendedRequest(int profileId)
        {
            var allSendedRequests = (from item in context.friendRequests where item.sendedProfileId == profileId select item).ToList();
            return allSendedRequests;
        }
        public ICollection<Profile> getAllProfileFriends(int profileId)
        {
            var profileFriends = (from item in context.friends where item.profileId == profileId select item).ToList();
            var friends = new List<Profile>();

            foreach(var item in profileFriends)
            {
                var friend=(from profile in context.profiles where profile.userId == item.friendId select profile).FirstOrDefault();
                if(friend == null)
                {
                    throw new ArgumentException("friend is not found");
                }
                friends.Add(friend);
            }

            return friends;
        }

        public void cancelRequest(int sendedProfileId, int receivedProfileId)
        {
            var friendRequest = (from item in context.friendRequests where item.sendedProfileId == sendedProfileId && item.recievedProfileId == receivedProfileId select item).FirstOrDefault();
            if (friendRequest == null)
            {
                throw new ArgumentException("friend request is not found");
            }
            context.friendRequests.Remove(friendRequest);
            context.SaveChanges();
        }
    }
}
