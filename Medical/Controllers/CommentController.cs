using Medical.General;
using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService commentService;
        FileService fileService;
        AppDbContext context;
        private readonly IWebHostEnvironment _environment;
        public CommentController(IWebHostEnvironment environment)
        {
            commentService = new CommentService();
            _environment = environment;
            fileService = new FileService(_environment);
            context = new AppDbContext();
        }
        [HttpPost]
        public ActionResult<Comment> addComment([FromBody] string comment,int postId,int profileId)
        {
            return Ok(commentService.addComment(comment, postId, profileId));
        }
        [HttpPost("/uploadImageToComment")]
        public ActionResult<Comment> uploadImageToComment([FromForm] fileUploadModel fileUploaded, [FromBody] string comment, int postId, int profileId)
        {
            var newImage = fileService.Uploadfile(fileUploaded);
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if (profile == null)
            {
                throw new ArgumentException("profile is not found");
            }
            var post = (from item in context.posts where item.id == postId select item).FirstOrDefault();
            if (post == null)
            {
                throw new ArgumentException("profile is not found");
            }
            var newComment= new Comment();
            newComment.profile = profile;
            newComment.profileId = profileId;
            newComment.post = post;
            newComment.commentImage = newImage;
            newComment.commentImageId = newImage.id;
            context.comments.Add(newComment);
            context.files.Add(newImage);
            context.SaveChanges();
            return newComment;
        }
        [HttpGet("/getAllComments")]
        public ActionResult<List<Comment>> getAllComments()
        {
            return Ok(commentService.getAllComments());
        }

        [HttpGet("/getAllUserComments")]
        public ActionResult<List<Comment>> getAllUserComments(int profileId)
        {
            return Ok(commentService.getAllUserComments(profileId));
        }

        [HttpGet("/getAllPostComments")]
        public ActionResult<List<Comment>> getAllPostComments(int postId)
        {
            return Ok(commentService.getAllPostComments(postId));
        }
    }
}
