using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;
using Shared.Requests;
using Shared.Responses;
using System.Data;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddNewUser(UserRequest userRequest)
        {
            var user = _mapper.Map<UserRequest, LotteryUser>(userRequest);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<UserResponse> GetUserByPhoneNumber(string phoneNumber)
        {
            var user = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber);
            return _mapper.Map<LotteryUser, UserResponse>(user);
        }

        public async Task<List<UserBetResponse>> GetUserBets(int userId)
        {
            return await _userRepository.GetUserBetsAsyn(userId);
        }
    }
}
