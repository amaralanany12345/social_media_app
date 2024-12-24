using Medical.Models;
using Medical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService;
        private readonly JwtClass _jwt;
        public UserController(JwtClass jwt)
        {
            _jwt = jwt;
            userService = new UserService(_jwt);
        }

        [HttpPost("/signup")]
        public ActionResult<SigningResponse> signup([FromBody] SignUpInfo userInfo)
        {
            return Ok(userService.signup(userInfo));
        }
        [HttpPost("/signin")]
        public ActionResult<SigningResponse> signin([FromBody] SignInInfo userInfo)
        {
            return Ok(userService.signin(userInfo));
        }
        [HttpGet("/getAllUsers")]
        public ActionResult<List<User>> getAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }
    }
}
