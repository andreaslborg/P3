
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
    public interface IInformationboard
    {
        Task<List<Informationboard>> InformationboardList();
    }

    public class InformationboardService : IInformationboard
    {
        private readonly IConfiguration _configuration;

        public InformationboardService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
            return connection;
        }

        public async Task<List<Informationboard>> InformationboardList()
        {
            var connectionString = this.GetConnection();
            List<Informationboard> informationboardList = new List<Informationboard>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand("Select `InformationBoardId`, `Title`, `Url`, `QRCode`, `IsPublished`, `LicenseId`, `CategoryOrder` FROM InformationBoard", con)
                    {
                        CommandType = CommandType.Text
                    };
                    var rdr = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        informationboardList.Add(new Informationboard
                        {
                            InformationboardID = (int)rdr["InformationBoardId"],
                            Title = rdr["Title"].ToString(),
                            Url = rdr["Url"].ToString(),
                            QRCode = rdr["QRCode"].ToString(),
                            IsPublished = (bool)rdr["IsPublished"],
                            LicenseID = (int)rdr["LicenseID"],
                            CategoryOrder = rdr["CategoryOrder"].ToString()
                        });
                    }
                    return informationboardList.ToList();
                }
                finally { con.Close(); }
            }
        }
    }
}
