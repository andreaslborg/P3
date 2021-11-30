using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IDbService
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<ILicenseViewModel> InitializeLicense(int licenseId);

        Task<List<IPostViewModel>> GetPosts(int categoryId);

        Task<List<ICategoryViewModel>> GetCategories(int informationBoardId);


    }
}