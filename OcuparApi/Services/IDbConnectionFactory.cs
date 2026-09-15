using System.Data;

namespace OcuparApi.Services
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
