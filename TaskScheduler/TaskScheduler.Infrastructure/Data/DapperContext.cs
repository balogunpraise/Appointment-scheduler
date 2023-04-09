using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace TaskScheduler.Infrastructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly string connectionString;

        public DapperContext(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(connectionString);
    }
}
