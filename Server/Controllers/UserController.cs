using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Shared.Requests;
using Shared.Responses;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public async Task<ActionResult> AddUserAsync([FromBody] UserRequest user)
        {
            try
            {
                await _userService.AddNewUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user-by-phonenumber")]
        public async Task<UserResponse> GetUserByPhoneNumberAsync([FromQuery] string phoneNumber)
        {
            try
            {
                return await _userService.GetUserByPhoneNumber(phoneNumber);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("user-bets")]
        public async Task<List<UserBetResponse>> GetUserBets(int userId)
        {
            try
            {
                return await _userService.GetUserBets(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
