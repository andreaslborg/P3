using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Function;
using Microsoft.Extensions.Configuration;

namespace ManagementPages.Tests
{ 
    public class DatabaseTest
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        [Fact]
        public async Task AddDeleteFetchDbTest()
        {
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

            await dbService.SaveData(sqlInsert, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.True(objectFound);

            await dbService.SaveData(sqlDelete, dbObject);
            testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });
            objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.False(objectFound);
        }

        [Fact]
        public async Task AddDbTest()
        {
            DbService dbService = new DbService(configuration);

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test string",
                TestBool = true
            };

            var sqlInsert = "Insert into Test (TestInt, TestString, TestBool) values (1, \"This is a test string\", true);";
            var sqlSelect = "Select * from Test;";

            await dbService.SaveData(sqlInsert, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.True(objectFound);
        }

        // Test only works if database has exactly one row where TestInt = 1, TestString = "This is a test string", TestBool = true.
        [Fact]
        public async Task DeleteDbTest()
        {
            DbService dbService = new DbService(configuration);

            DbTestClass dbObject = new DbTestClass
            {
                TestInt = 1,
                TestString = "This is a test string",
                TestBool = true
            };

            var sqlDelete = "Delete from Test Where TestInt = 1;";
            var sqlSelect = "Select * from Test;";

            await dbService.SaveData(sqlDelete, dbObject);
            var testList = await dbService.LoadData<DbTestClass, dynamic>(sqlSelect, new { });
            bool objectFound = testList.Any(item => item.TestInt == dbObject.TestInt && item.TestString == dbObject.TestString && item.TestBool == dbObject.TestBool);
            Assert.False(objectFound);
        }
    }
}
