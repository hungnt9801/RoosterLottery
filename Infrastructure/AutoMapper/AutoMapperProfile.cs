using AutoMapper;
using Domain.Entities;
using Shared.Requests;
using Shared.Responses;

namespace Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRequest, LotteryUser>();
            CreateMap<LotteryUser, UserResponse>();
            CreateMap<BetRequest, Bet>();
            CreateMap<Bet, BetResponse>();
        }
    }
}
