using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "default";

        public DbService(IConfiguration config)
        {
            _config = config;
        }   
     
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<ILicenseViewModel> InitializeLicense(int licenseId)
        {
            ILicenseViewModel result = new LicenseViewModel();
            List<License> licenseList = new List<License>();

            string sql = $"select * from License where LicenseId = {licenseId};";
            licenseList = await LoadData<License, dynamic>(sql, new { });

            result.LicenseModel = licenseList.First();

            return result;
        }


        public void GetLicenseData(int licenseId)
        {
            //var result = new License();

            // hvis vi fetcher et felt ad gangen: 
            //result.LicenseId = licenseId;
            //result.RegistrationDate = ..; //kald til db

            // hvis vi fetcher et helt objekt ad gangen: 
            //result = ... ; //kald til db

            //string sql = "select * from License where LicenseId = @licenseId;";
            //test = await dbService.LoadData<TestModel, dynamic>(sql, new { });

            //LicenseModel = result;
        }

        public void GetInformationBoards(int licenseId)
        {
            // lave informationboard objekter ud fra licenseId i et loop (where licenseId = licenseId)
            // først skal vi identificere deres Id
            //InformationBoards.Add(new InformationBoardViewModel(_dbService, informationBoardId));
        }
    }
}

