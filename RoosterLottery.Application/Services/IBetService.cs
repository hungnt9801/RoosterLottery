using Infrastructure.Repository;
using Shared.Requests;
using Shared.Responses;
using System.Data;

namespace Server.Services
{
    public interface IBetService
    {
        public Task AddBat(BetRequest betRequest);
        public Task<BetResponse> GetUserBet(int userId);
        public Task<BetResponse> CheckWinningBet(int userId, DateTime slotTime);
    }
}
