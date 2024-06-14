using AdminApi.Dto.Request;
using AdminApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("total")]
        public IActionResult GetTotalUsers()
        {
            var totalUsers = _userService.GetTotalUsers();
            return Ok(totalUsers);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginRequest request)
        {
            var result = _userService.login(request.Email, request.Password);
            if (result == "Login successful")
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
    }
}
