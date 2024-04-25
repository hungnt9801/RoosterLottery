using Domain.Entities;

namespace Infrastructure.Repository
{
    public interface IBetRepository
    {
        public Task<int> AddBetAsync(Bet bet);
        public Task<Bet> GetUserBetAsync(int userId);
        public Task<Bet> CheckWinningBetAsync(int userId, DateTime slotTime);
    }
}
