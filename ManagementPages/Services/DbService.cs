using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper; //query and execute async methods
using Microsoft.Extensions.Configuration; //get connectionstring
using MySql.Data.MySqlClient; //mysqlconnection



namespace ManagementPages.Services
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _config;

        public DbService(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionStringName { get; set; } = "default";

        // Generic method for fetching data from the database
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            var connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        // Generic method for uploading, changing or deleting data from the database
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