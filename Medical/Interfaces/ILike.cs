using Medical.Models;

namespace Medical.Interfaces
{
    public interface ILike<T>
    {
        T AddLike(int profileId,int itemId);
        void DeleteLike(int likeId);
        T GetLike(int likeId);
        ICollection<T> getAllItemLikes(int itemId);
    }
}
