using Domain.Entities;
using Shared.Responses;

namespace Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<int> AddUserAsync(LotteryUser user);
        public Task<LotteryUser> GetUserByPhoneNumberAsync(string phoneNumber);
        public Task<List<UserBetResponse>> GetUserBetsAsyn(int userId);
    }
}
