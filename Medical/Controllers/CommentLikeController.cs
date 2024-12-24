using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CommentLikeController : Controller
    {
        CommentLikeService commentLikeService;

        public CommentLikeController()
        {
            commentLikeService = new CommentLikeService();
        }

        [HttpPost]
        public ActionResult<CommentLike> addCommentLike(int profileId,int commentId)
        {
            return Ok(commentLikeService.AddLike(profileId, commentId));
        }

        [HttpDelete]
        public ActionResult deleteCommentLike(int commentLikeId)
        {
            var commentLike = commentLikeService.GetLike(commentLikeId);
            commentLikeService.DeleteLike(commentLikeId);
            return Ok();
        }
        [HttpGet("/allCommentLikes")]
        public ActionResult<List<CommentLike>> getAllCommentLikes(int commentId)
        {
            return Ok(commentLikeService.getAllItemLikes(commentId));
        }
    }
}
