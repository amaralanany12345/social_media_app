using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostLikeController : ControllerBase
    {
        PostLikeService postLikeService;

        public PostLikeController()
        {
            postLikeService = new PostLikeService();
        }

        [HttpPost]
        public ActionResult<PostLike> AddPostLike(int profileId, int postId)
        {
            return Ok(postLikeService.AddLike(profileId, postId));
        }

        [HttpDelete]
        public ActionResult deletePostLike(int postLikeId)
        {
            postLikeService.DeleteLike(postLikeId);
            return Ok();
        }
        [HttpGet("/allPostLikes")]
        public ActionResult<List<PostLike>> getAllPostLikes(int postId)
        {
            return Ok(postLikeService.getAllItemLikes(postId));
        }
    }
}
