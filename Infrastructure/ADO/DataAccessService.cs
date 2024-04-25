using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace RoosterLottery.Infrastructure.ADO
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IConfiguration _configuration;
        public DataAccessService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public List<T> ExecuteStoredProcedure<T>(string storedProcedureName, SqlParameter[] parameters)
        {
            string connectionString = _configuration.GetConnectionString("RoosterLottery");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    connection.Open();
                    
                    SqlDataReader reader = command.ExecuteReader();

                    var objList = new List<T>();
                    var props = typeof(T).GetRuntimeProperties();

                    var colMapping = reader.GetColumnSchema()
                      .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                      .ToDictionary(key => key.ColumnName.ToLower());

                    while (reader.Read())
                    {
                        T obj = Activator.CreateInstance<T>();
                        foreach (var prop in props)
                        {
                            var val =
                              reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                        objList.Add(obj);
                    }
                    return objList;
                }
            }
        }
    }
}
