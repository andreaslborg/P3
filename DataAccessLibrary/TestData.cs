using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    /*
    public class TestData : ITestData
    {
        private readonly ISqlDataAccess _db;
        public TestData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<TestModel>> GetTest()
        {
            string sql = "select * from test";

            return _db.LoadData<TestModel, dynamic>(sql, new { });

        }

        public Task InsertTest(TestModel test)
        {
            string sql = @"insert into test (id, name)
                            values (@ID, @Name);";

            return _db.SaveData(sql, test);
        }
   
    }
     */
}
