using Medical.Models;

namespace Medical.Interfaces
{
    public interface IProfile
    {
        Profile getUserProfile(int userId);
        ICollection<Profile> getAllProfiles();
        void deleteProfile(int userId);
    }
}
