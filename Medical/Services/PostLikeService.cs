using Medical.General;
using Medical.Interfaces;
using Medical.Models;
using System.Linq.Expressions;

namespace Medical.Services
{
    public class PostLikeService : ILike<PostLike>
    {
        AppDbContext context;
        public PostLikeService()
        {
            context = new AppDbContext();
        }
        public PostLike AddLike(int profileId, int postId)
        {
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if(profile == null)
            {
                throw new ArgumentException("profile is not found");
            }

            var post = (from item in context.posts where item.id == postId select item).FirstOrDefault();
            if (post == null)
            {
                throw new ArgumentException("post is not found");
            }
            
            var newPostLike = new PostLike();
            newPostLike .profile = profile;
            newPostLike .profileId = profileId;
            newPostLike .postId = postId;
            newPostLike.post = post;
            context.postLikes.Add(newPostLike);
            context.SaveChanges();
            return newPostLike;
        }

        public void DeleteLike(int postLikeId)
        {
            var postLike = (from item in context.postLikes where item.id == postLikeId select item).FirstOrDefault();
            if(postLike == null)
            {
                throw new ArgumentException("post like is not found");
            }
            context.postLikes.Remove(postLike);
            context.SaveChanges();
        }

        public ICollection<PostLike> getAllItemLikes(int postId)
        {
            var allPostLikes = (from item in context.postLikes where item.postId == postId select item).ToList();
            return allPostLikes;
        }

        public PostLike GetLike(int postLikeId)
        {
            var postLike = (from item in context.postLikes where item.id == postLikeId select item).FirstOrDefault();
            if (postLike == null)
            {
                throw new ArgumentException("post like is not found");
            }
            return postLike;
        }
    }
}
