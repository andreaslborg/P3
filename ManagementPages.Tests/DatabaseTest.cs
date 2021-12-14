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
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        [Fact]
        public async Task FetchFromDbTest()
        {
            DbService dbService = new DbService(configuration);

            var sql = "Select * from Test";
            
            var test = await dbService.LoadData<DbTestClass, dynamic>(sql, new {});

            DbTestClass expectedOjbect = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test",
                TestBool = true

            };

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = test.First().TestInt,
                TestString = test.First().TestString,
                TestBool = test.First().TestBool
            };

            var expectedObj = new Likeness<DbTestClass, DbTestClass>(dbObject);

            Assert.Equal(expectedObj, dbObject);
        }

        [Fact]
        public async Task AddToDbTest()
        {

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
