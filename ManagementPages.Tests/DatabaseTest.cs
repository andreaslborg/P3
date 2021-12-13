using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Function;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Configuration;

using Dapper;

using MySql.Data.MySqlClient;
using ManagementPages.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using Moq;

namespace ManagementPages.Tests
{ 
    public class DatabaseTest
    {
        
        [Fact]
        public async Task TestDatabase()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            var sql = "Select * from Post";
            
            var test = await dbService.LoadData<PostDataModel, dynamic>(sql, new {});
        }

        
        // [Fact]
        // public void TestDatabase()
        // {


        //     var connectionstring = _config.GetConnectionString("Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;");

        //     //var service = new DbService(_config);


        //     var expected = "Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;";

        //     //Assert.NotEqual(expected, service.ConnectionStringName);

        //     Assert.NotEqual(expected, connectionstring); 

        // }







    }
}
