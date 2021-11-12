using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ITestData
    {
        Task<List<TestModel>> GetTest();
        Task InsertTest(TestModel test);
    }
}