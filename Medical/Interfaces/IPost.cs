using Medical.Models;

namespace Medical.Interfaces
{
    public interface IPost
    {
        Post addPost(string post,int profileId);
        Post getPost(int postId);
        void deletePost(int postId);
        ICollection<Post> getAllPosts();
        ICollection<Post> getAllProfilePosts(int profileId);
    }
}
