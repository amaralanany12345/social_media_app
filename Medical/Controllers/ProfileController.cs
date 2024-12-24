using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        ProfileService profileService;
        public ProfileController()
        {
            profileService = new ProfileService();
        }
        [HttpGet("/allProfiles")]
        public ActionResult<List<Profile>> getAllProfiles()
        {
            return Ok(profileService.getAllProfiles());
        }

        [HttpGet("/getUserProfile")]
        public ActionResult<List<Profile>> getUserProfile(int userId)
        {
            return Ok(profileService.getUserProfile(userId));
        }
    }
}
