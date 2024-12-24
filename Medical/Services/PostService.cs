using Medical.General;
using Medical.Interfaces;
using Medical.Models;

namespace Medical.Services
{
    public class PostService : IPost
    {
        AppDbContext context;
        public PostService()
        {
            context = new AppDbContext();
        }

        public Post addPost(string post, int profileId)
        {
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if(profile == null)
            {
                throw new ArgumentException("profile is not found");
            }
            var newPost = new Post();
            newPost.post = post;
            newPost.profile = profile;
            newPost.profileId = profileId;
            context.posts.Add(newPost);
            context.SaveChanges();
            return newPost;
        }
        public void deletePost(int postId)
        {
            var post = (from item in context.posts where item.id == postId select item).FirstOrDefault();
            if(post == null)
            {
                throw new ArgumentException("post is not found");
            }
            context.posts.Remove(post);
            context.SaveChanges();
        }

        public ICollection<Post> getAllPosts()
        {
            var allPosts = (from item in context.posts select item).ToList();
            return allPosts;
        }

        public ICollection<Post> getAllProfilePosts(int profileId)
        {
            var userPosts = (from item in context.posts where item.profileId == profileId select item).ToList();
            return userPosts;
        }

        public Post getPost(int postId)
        {
            var post = (from item in context.posts where item.id == postId select item).FirstOrDefault();
            if(post == null)
            {
                throw new ArgumentException("post is not found");
            }
            return post;
        }
    }
}
