using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Shared.Requests;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/bets")]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost("add-bet")]
        public async Task<ActionResult> AddBetAsync([FromBody] BetRequest bet)
        {
            try
            {
                await _betService.AddBat(bet);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserBetAsync([FromQuery] int userId)
        {
            try
            {
                await _betService.GetUserBet(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    //    [HttpGet]
    //    public async Task<ActionResult> CheckWinningBetAsync([FromQuery] int userId, DateTime slotTime)
    //    {
    //        try
    //        {
    //            await _betService.CheckWinningBet(userId, slotTime);
    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
    }
}
