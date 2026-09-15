using Microsoft.Data.SqlClient;
using System.Data;

namespace OcuparApi.Services
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
