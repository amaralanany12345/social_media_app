using Medical.Models;

namespace Medical.Interfaces
{
    public interface IComment
    {
        Comment addComment(string comment, int postId, int profileId);
        void deleteComment(int commentId);
        Comment getComment(int commentId);
        ICollection<Comment> getAllComments();
        ICollection<Comment> getAllUserComments(int profileId);
        ICollection<Comment> getAllPostComments(int postId);

    }
}
