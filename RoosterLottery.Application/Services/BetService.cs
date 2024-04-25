using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;
using Shared.Requests;
using Shared.Responses;
using System.Data;

namespace Server.Services
{
    public class BetService : IBetService
    {
        private readonly IMapper _mapper;
        private readonly IBetRepository _betRepository;
        public BetService(IBetRepository betRepository, IMapper mapper)
        {
            _betRepository = betRepository;
            _mapper = mapper;
        }

        public async Task AddBat(BetRequest betRequest)
        {
            var bet = _mapper.Map<BetRequest, Bet>(betRequest);
            await _betRepository.AddBetAsync(bet);
        }

        public async Task<BetResponse> GetUserBet(int userId)
        {
            var bet = await _betRepository.GetUserBetAsync(userId);
            return _mapper.Map<Bet, BetResponse>(bet);
        }
        
        public async Task<BetResponse> CheckWinningBet(int userId, DateTime slotTime)
        {
            var bet = await _betRepository.CheckWinningBetAsync(userId, slotTime);
            return _mapper.Map<Bet, BetResponse>(bet);
        }
    }
}
