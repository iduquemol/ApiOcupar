using Dapper;
using System.Data;

namespace OcuparApi.Services
{
    public class ExtractoRepository : IExtractoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ExtractoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> LoadCajaSocialExtractoAsync(string cajaSocialJson)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("cajaSocial", cajaSocialJson, DbType.String, size: -1);
            parameters.Add("idExtracto", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "usr_sp_itq_CargaExtractoCajaSocial",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("idExtracto");
        }
    }
}
