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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using Moq;

namespace ManagementPages.Tests
{ 
    public class DatabaseTest
    {
        private readonly Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private readonly Mock<IDbService> dbServiceMock = new Mock<IDbService>();


        [Fact]
        public void TestDatabase()
        {


            var connectionstring = _config.GetConnectionString("Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;");

            //var service = new DbService(_config);


            var expected = "Server=mysql113.unoeuro.com;Database=taldigital_dk_db_aau;Uid=taldigital_dk;Pwd=mrERx2dGezhf;";

            //Assert.NotEqual(expected, service.ConnectionStringName);

            Assert.NotEqual(expected, connectionstring);

        }



        



    }
}
