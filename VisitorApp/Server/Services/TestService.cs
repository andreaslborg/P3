using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorApp.Server.Functions;

namespace VisitorApp.Server.Services
{
    public interface ITest
    {
        Task<List<Test>> TestList();
        Task SaveData(Test tests);
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
                    var com = new MySqlCommand("Select `ID`,`Name` FROM test",
                        con)
                    {
                        CommandType = CommandType.Text
                    };
                    var rdr = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        lst.Add(new Test
                        {
                            ID = (int)rdr["ID"],
                            Name = rdr["Name"].ToString(),
                        });
                    }
                    return lst.ToList();
                }
                finally { con.Close(); }

            }
        }

        public async Task SaveData(Test students)
        {
            var connectionString = this.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand("INSERT INTO tblstudinfo () VALUES (@id,@fname,@mi,@lname,@bdate,@address,@email,@user,@pwd)", con)
                    {
                        CommandType = CommandType.Text
                    };
                    com.Parameters.AddWithValue("@id", students.ID);
                    com.Parameters.AddWithValue("@fname", students.Name);
                   
                    await com.ExecuteNonQueryAsync();
                }
                finally { con.Close(); }

            }
        }


    }
}
