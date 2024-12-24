using Azure.Core;
using Medical.General;
using Medical.Interfaces;
using Medical.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Medical.Services
{
    public class ProfileService : IProfile
    {
        AppDbContext context;
        public ProfileService()
        {
            context = new AppDbContext();
        }

        public void deleteProfile(int userId)
        {
                var profile = (from item in context.profiles where item.userId == userId select item).FirstOrDefault();
                if (profile is null)
                {
                    throw new ArgumentException("user is not found");
                }
                context.profiles.Remove(profile);

                var user = (from item in context.users where item.id == userId select item).FirstOrDefault();
                if (user is null)
                {
                    throw new ArgumentException("user is not found");
                }
                context.users.Remove(user);
                context.SaveChanges();
        }

        public ICollection<Profile> getAllProfiles()
        {
            var allProfiles = (from profile in context.profiles select profile).ToList();
            return allProfiles;
        }

        public Profile getUserProfile(int profileId)
        {
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if(profile == null)
            {
                throw new ArgumentException("profileis not found");
            }
            return profile;
        }
    }
}
