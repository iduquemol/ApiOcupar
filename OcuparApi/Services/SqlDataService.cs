using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OcuparApi.Services
{
    public class SqlDataService : ISqlDataService
    {
        private readonly string _connectionString;

        public SqlDataService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found");
        }

        private static DynamicParameters BuildParameters(
            params (string Name, object Value)[] parameters)
        {
            var dynamicParameters = new DynamicParameters();
            foreach (var (name, value) in parameters)
            {
                dynamicParameters.Add(name, value ?? DBNull.Value);
            }

            return dynamicParameters;
        }

        public async Task<DataTable> ExecuteStoredProcedureAsync(
            string procedureName,
            params (string Name, object Value)[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);

            using var reader = await connection.ExecuteReaderAsync(
                procedureName,
                BuildParameters(parameters),
                commandType: CommandType.StoredProcedure);

            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }

        public async Task<T?> ExecuteScalarAsync<T>(
            string procedureName,
            params (string Name, object Value)[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<T>(
                procedureName,
                BuildParameters(parameters),
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteNonQueryAsync(
            string procedureName,
            params (string Name, object Value)[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteAsync(
                procedureName,
                BuildParameters(parameters),
                commandType: CommandType.StoredProcedure);
        }
    }
}
