using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        FriendsService friendService;
        public FriendController(IHttpContextAccessor httpContextAccessor)
        {
            friendService = new FriendsService(); 
            //_httpContextAccessor = httpContextAccessor;

        }
        [HttpPost]
        public ActionResult<FriendRequests> addFriend(int sendedProfileId, int recievedProfileId)
        {
            return Ok(friendService.addFreind(sendedProfileId, recievedProfileId));
        }
        [HttpPut("/acceptRequest")]
        public ActionResult acceptRequest(int sendedProfileId, int recievedProfileId)
        {
            friendService.acceptRequest(sendedProfileId, recievedProfileId);
            return Ok();
        }
        [HttpGet("/getAllUserRecievedRequests")]
        public ActionResult<ICollection<FriendRequests>> getAllUserRecievedRequests(int profileId)
        {
            return Ok(friendService.getAllProfileRecievedRequest(profileId));
        }
        [HttpGet("/getAllUserSendedRequests")]
        public ActionResult<ICollection<FriendRequests>> getAllUserSendedRequests(int profileId)
        {
            return Ok(friendService.getAllProfileSendedRequest(profileId));
        }

        [HttpGet("/getAllProfileFriends")]
        public ActionResult<ICollection<FriendRequests>> getAllProfileFriends(int profileId)
        {
            return Ok(friendService.getAllProfileFriends(profileId));
        }

        [HttpDelete("/cancelFriendRequest")]
        [Authorize]
        public ActionResult cancelFriendRequest(int sendedProfileId, int recievedProfileId)
        {
            var userName = User.Claims.FirstOrDefault(a=>a.Type==ClaimTypes.Name)?.Value; // This should be the name claim
            var userEmail =User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value; // Extract email claim
            var userIdString = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // Extract user ID claim (password in this case, but should use a better identifier)
            int userId = int.Parse(userIdString);
            if (userId != recievedProfileId)
            {
                return Unauthorized("you are not allowed to cancel this request");
            }
            else
            {
                friendService.cancelRequest(sendedProfileId,recievedProfileId);
                return Ok();
            }
        }
    }
}
