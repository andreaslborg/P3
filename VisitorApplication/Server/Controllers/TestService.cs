using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    public interface ITest
    {
        Task<List<Test>> TestList();
    }

    public class TestService : ITest
    {
        private readonly IConfiguration _configuration;

        public TestService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
            return connection;
        }

        public async Task<List<Test>> TestList()
        {
            var connectionString = this.GetConnection();
            List<Test> lst = new List<Test>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand("Select `ID`,`Name` FROM test", con)
                    {
                        CommandType = CommandType.Text
                    };
                    var rdr = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        lst.Add(new Test
                        {
                            //det ID der er i databasen vil vi gerne have hen i en variabel ID
                            ID = (int)rdr["ID"],
                            Name = rdr["Name"].ToString(),
                        });
                    }
                    return lst.ToList();
                }
                finally { con.Close(); }

                
            }

        }

    }
}
