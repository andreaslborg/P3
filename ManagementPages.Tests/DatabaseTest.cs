using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Function;
using Microsoft.Extensions.Configuration;
using System.Data;

using Dapper;

using MySql.Data.MySqlClient;
using ManagementPages.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ManagementPages.Tests
{
    public class DatabaseTest
    {
        private readonly IConfiguration _config;

        public DatabaseTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<SomeContext>(options => options.UseSqlServer("connection string"),
            ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }

        [Fact]
        public void TestDatabase()
        {
            var connectionstring = _config.GetConnectionString("Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;");

            var service = new DbService(_config);

            service.LoadData<string, >

            var expected = "Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;";

            //Assert.NotEqual(expected, service.ConnectionStringName);

            Assert.NotEqual(expected, connectionstring);

        }



        private async Task<List<PostDataModel>> LoadPostDataModels(IDbService dbService)
        {
            var sql = $"select * from Post where CategoryId = {CategoryDataModel.CategoryId};";
            return await dbService.LoadData<PostDataModel, dynamic>(sql, new { });
        }



    }
}
