using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;

namespace ManagementPages.Tests
{
    public class DatabaseTest
    {

        [Fact]
        public async Task AddToDbTest()
        {
            //Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test string",
                TestBool = true
            };

            var sqlInsert = "Insert into Test (TestInt, TestString, TestBool) values (1, \"This is a test string\", true);";
            var sqlSelect = "Select * from Test;";

            //Act
            await dbService.SaveData(sqlInsert, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });

            //Assert
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.True(objectFound);
        }

        // Test only works if database has exactly one row where TestInt = 1, TestString = "This is a test string", TestBool = true.
        [Fact]
        public async Task DeleteFromDbTest()
        {
            //Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test string",
                TestBool = true
            };

            var sqlDelete = "Delete from Test Where TestInt = 1;";
            var sqlSelect = "Select * from Test;";

            //Act
            await dbService.SaveData(sqlDelete, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });

            //Assert
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.False(objectFound);
        }

        [Fact]
        public async Task AddDeleteFetchDbTest()
        {
            //Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test string",
                TestBool = true
            };

            var sqlInsert = "Insert into Test (TestInt, TestString, TestBool) values (1, \"This is a test string\", true);";
            var sqlSelect = "Select * from Test;";
            var sqlDelete = "Delete from Test Where TestInt = 1;";

            //Act
            await dbService.SaveData(sqlInsert, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });

            //Assert
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.True(objectFound);

            //Act
            await dbService.SaveData(sqlDelete, dbObject);
            testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });

            //Assert
            objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.False(objectFound);
        }
    }
}