using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoosterLottery.Infrastructure;
using RoosterLottery.Infrastructure.ADO;
using Shared.Responses;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LotteryDbContext _dbContext;
        private readonly IDataAccessService _dataAccessService;
        
        public UserRepository(LotteryDbContext dbContext, IDataAccessService dataAccessService)
        {
            _dbContext = dbContext;
            _dataAccessService = dataAccessService;
        }

        public async Task<int> AddUserAsync(LotteryUser user)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@Name", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = user.Name },
               new SqlParameter("@DateOfBirth", SqlDbType.DateTime2) { Direction = ParameterDirection.Input, Value = user.DateOfBirth },
               new SqlParameter("@PhoneNumber", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = user.PhoneNumber }
            };
            var result = _dataAccessService.ExecuteStoredProcedure<int>("AddNewUser", parameters);

            return 1;
        }

        public async Task<LotteryUser> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@PhoneNumber", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = phoneNumber }
            };
            var result = _dataAccessService.ExecuteStoredProcedure<LotteryUser>("GetUserByPhoneNumber", parameters).FirstOrDefault();
            
            return result;
        }

        public async Task<List<UserBetResponse>> GetUserBetsAsyn(int userId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = userId }
            };
            var result = _dataAccessService.ExecuteStoredProcedure<UserBetResponse>("GetUserBets", parameters);

            return result;
        }
    }
}
