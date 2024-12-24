using Medical.General;
using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using System;
using System.Runtime.InteropServices;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        PostService postService;
        AppDbContext context;
        FileService fileService;
        private readonly IWebHostEnvironment _environment;
        public PostController(IWebHostEnvironment environment)
        {
            _environment = environment;
            postService = new PostService();
            context = new AppDbContext();
            fileService = new FileService(_environment);
        }
        [HttpPost]
        public ActionResult<Post> addPost([FromBody] string post ,int profileId)
        {
            return Ok(postService.addPost(post, profileId));
        }

        [HttpPost("uploadPostWithImage")]
        public ActionResult<Post> UploadImageToPost([FromForm] fileUploadModel fileUploaded,[FromForm]string post,int profileId)
        {
            var newImage= fileService.Uploadfile(fileUploaded);
            var profile = (from item in context.profiles where item.id == profileId select item).FirstOrDefault();
            if (profile == null)
            {
                throw new ArgumentException("profile is not found");
            }
            var newPost = new Post();
            newPost.profile = profile;
            newPost.profileId = profileId;
            newPost.post = post;
            newPost.postImage = newImage;
            newPost.postImageId = newImage.id;
            context.posts.Add(newPost);
            context.files.Add(newImage);
            context.SaveChanges();
            return newPost;
    }

        [HttpGet("/getAllPosts")]
        public ActionResult<List<Post>> getAllPosts()
        {
            return Ok(postService.getAllPosts());
        }
        [HttpGet("/getAllUserPosts")]
        public ActionResult<List<Post>> getAllProfilePosts(int profileId)
        {
            return Ok(postService.getAllProfilePosts(profileId));
        }

    }
}
