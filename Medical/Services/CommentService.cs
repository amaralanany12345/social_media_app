using Medical.General;
using Medical.Interfaces;
using Medical.Models;

namespace Medical.Services
{
    public class CommentService : IComment
    {
        AppDbContext context;

        public CommentService()
        {
            context = new AppDbContext();
        }

        public Comment addComment(string comment,int postId, int profileId)
        {
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if(profile == null)
            {
                throw new ArgumentException("profile is not found");
            }
            var post = (from item in context.posts where item.id == postId select item).FirstOrDefault();
            if (post == null)
            {
                throw new ArgumentException("profile is not found");
            }

            var newComment = new Comment();
            
            newComment.profile = profile;
            newComment.profileId = profileId;
            newComment.post = post;
            newComment.postId = postId;
            newComment.comment = comment;
            context.comments.Add(newComment);
            context.SaveChanges();
            return newComment;
        }

        public void deleteComment(int commentId)
        {
            var comment = (from item in context.comments where item.id == commentId select item).FirstOrDefault();
            if(comment is null)
            {
                throw new ArgumentException("comment is not found");
            }
            context.comments.Remove(comment);
        }

        public ICollection<Comment> getAllComments()
        {
            var allComments = (from item in context.comments select item).ToList();
            return allComments;
        }

        public ICollection<Comment> getAllPostComments(int postId)
        {
            var allPostComments = (from item in context.comments where item.postId == postId select item).ToList();
            return allPostComments;
        }

        public ICollection<Comment> getAllUserComments(int profileId)
        {
            var allUserComments = (from item in context.comments where item.profileId==profileId select item).ToList();
            return allUserComments;
        }

        public Comment getComment(int commentId)
        {
            var comment = (from item in context.comments where item.id == commentId select item).FirstOrDefault();
            if (comment is null)
            {
                throw new ArgumentException("comment is not found");
            }
            return comment;
        }
    }
}
