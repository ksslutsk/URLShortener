using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using URLShortenerBACK.Models;
using URLShortenerBACK.Sevices;
using URLShortenerBACK.DTO;

namespace URLShortenerBACK.Controllers
{
    [Route("auth")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<User> CreateNewUser(User user)
        {
            var res = await _userService.RegisterUser(user);
            return res;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        [HttpPost("login")]
        public async Task<User?> LoginUser(UserLogin userLogin)
        {
            return await this._userService.LoginUser(userLogin);
        }
    }
}

