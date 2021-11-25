using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementPages.Functions
{
    public interface IDbService
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);

    }
}