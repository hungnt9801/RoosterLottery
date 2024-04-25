using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoosterLottery.Infrastructure;
using RoosterLottery.Infrastructure.ADO;
using System.Data;
using System.Runtime.InteropServices;

namespace Infrastructure.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly LotteryDbContext _dbContext;
        private readonly IDataAccessService _dataAccessService;

        public BetRepository(LotteryDbContext dbContext, IDataAccessService dataAccessService)
        {
            _dbContext = dbContext;
            _dataAccessService = dataAccessService;
        }

        public async Task<int> AddBetAsync(Bet bet)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@UserId", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = bet.UserId},
               new SqlParameter("@BetNumber", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = bet.BetNumber },
               new SqlParameter("@BetTime", SqlDbType.DateTime2) { Direction = ParameterDirection.Input, Value = bet.BetTime },
            };
            var result = _dataAccessService.ExecuteStoredProcedure<int>("AddBet", parameters);

            return 1;
        }

        public async Task<Bet> GetUserBetAsync(int userId)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@UserId", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = userId},
            };
            var result = _dataAccessService.ExecuteStoredProcedure<Bet>("GetUserBet", parameters).FirstOrDefault();

            return result;
        }

        public async Task<Bet> CheckWinningBetAsync(int userId, DateTime slotTime)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@UserId", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = userId},
               new SqlParameter("@SlotTime", SqlDbType.DateTime2) { Direction = ParameterDirection.Input, Value = slotTime },
            };

            var result = _dataAccessService.ExecuteStoredProcedure<Bet>("GetUserBet", parameters).FirstOrDefault();

            return result;
        }
    }
}
