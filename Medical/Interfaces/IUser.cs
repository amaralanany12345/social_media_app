using Medical.Models;

namespace Medical.Interfaces
{
    public interface IUser
    {
        SigningResponse signin(SignInInfo userInfo);
        SigningResponse signup(SignUpInfo userInfo);
        ICollection<User> GetAllUsers();

    }
}
