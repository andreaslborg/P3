using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ManagementPages.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ManagementPages.Functions
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _config;

        public DbService(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionStringName { get; set; } = "default";

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            var connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            var connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}