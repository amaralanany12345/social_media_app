using Medical.General;
using Medical.Interfaces;
using Medical.Models;

namespace Medical.Services
{
    public class CommentLikeService : ILike<CommentLike>
    {
        AppDbContext context;
        public CommentLikeService()
        {
            context = new AppDbContext();
        }
        public CommentLike AddLike(int profileId, int commentId)
        {
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if (profile == null)
            {
                throw new ArgumentException("profile is not found");
            }

            var comment = (from item in context.comments where item.id == commentId select item).FirstOrDefault();
            if (comment == null)
            {
                throw new ArgumentException("comment is not found");
            }

            var newCommentLike = new CommentLike();
            newCommentLike .profile = profile;
            newCommentLike .profileId = profileId;
            newCommentLike .commentId = commentId;
            newCommentLike.comment = comment;
            context.commentLikes.Add(newCommentLike);
            context.SaveChanges();
            return newCommentLike;
        }

        public void DeleteLike(int commentLikeId)
        {
            var commentLike = (from item in context.commentLikes where item.id == commentLikeId select item).FirstOrDefault();
            if (commentLike == null)
            {
                throw new ArgumentException("comment like is not found");
            }
            context.commentLikes.Remove(commentLike);
            context.SaveChanges();
        }

        public ICollection<CommentLike> getAllItemLikes(int commentId)
        {
            var allCommentLikes= (from item in context.commentLikes where item.commentId== commentId select item).ToList();
            return allCommentLikes;
        }

        public CommentLike GetLike(int commentLikeId)
        {
            var commentLike = (from item in context.commentLikes where item.id == commentLikeId select item).FirstOrDefault();
            if (commentLike == null)
            {
                throw new ArgumentException("comment like is not found");
            }
            return commentLike;
        }
    }
}
