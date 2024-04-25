using Microsoft.Data.SqlClient;

namespace RoosterLottery.Infrastructure.ADO
{
    public interface IDataAccessService
    {
        //public object ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters);
        public List<T> ExecuteStoredProcedure<T>(string storedProcedureName, SqlParameter[] parameters);
    }
}
