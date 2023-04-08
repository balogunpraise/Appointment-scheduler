using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Infrastructure.Data
{
    public class ApplicationContext
    {
        private readonly IConfiguration _config;
        private readonly string connectionString;

        public ApplicationContext(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(connectionString);
    }
}
