using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Shared.Requests;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync([FromBody] UserRequest user)
        {
            await _userService.AddNewUser(user);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetUserByPhoneNumberAsync([FromQuery] string phoneNumber)
        {
            await _userService.GetUserByPhoneNumber(phoneNumber);
            return Ok();
        }
    }
}
