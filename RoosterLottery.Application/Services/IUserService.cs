using Infrastructure.Repository;
using Shared.Requests;
using Shared.Responses;
using System.Data;

namespace Server.Services
{
    public interface IUserService
    {
        public Task AddNewUser(UserRequest userRequest);
        public Task<UserResponse> GetUserByPhoneNumber(string phoneNumber);
        public Task<List<UserBetResponse>> GetUserBets(int userId);
    }
}
