using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ManagementPages.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ManagementPages.Functions
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _config;

        public DbService(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionStringName { get; set; } = "default";

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            var connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            var connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }


        public async Task<ILicenseViewModel> InitializeLicense(int licenseId)
        {
            ILicenseViewModel result = new LicenseViewModel()
            {
                LicenseModel = await GetLicenseModel(licenseId),
                InformationBoards = await GetInformationBoards(licenseId)
            };

            return result;
        }

        public async Task<Dictionary<int, ICategoryViewModel>> GetCategories(int informationBoardId)
        {
            var result = new Dictionary<int, ICategoryViewModel>();

            var categoryModels = await GetCategoryModels(informationBoardId);

            foreach (var categoryModel in categoryModels)
            {
                var category = new CategoryViewModel
                {
                    CategoryModel = categoryModel,
                    Posts = await GetPosts(categoryModel.CategoryId)
                };
                result.Add(category.GetHashCode(), category);
            }

            return result;
        }

        public async Task<List<IPostViewModel>> GetPosts(int categoryId)
        {
            var result = new List<IPostViewModel>();

            var postModels = await GetPostModels(categoryId);

            foreach (var postModel in postModels)
            {
                var post = new PostViewModel
                {
                    PostModel = postModel
                };

                result.Add(post);
            }

            return result;
        }

        private async Task<List<IInformationBoardViewModel>> GetInformationBoards(int licenseId)
        {
            var result = new List<IInformationBoardViewModel>();

            var informationBoardModels = await GetInformationBoardModels(licenseId);

            foreach (var informationBoardModel in informationBoardModels)
            {
                var informationBoard = new InformationBoardViewModel
                {
                    InformationBoardModel = informationBoardModel,
                    Categories = await GetCategories(informationBoardModel.InformationBoardId)
                };

                result.Add(informationBoard);

                if (informationBoardModel.CategoryOrder != null)
                {
                    informationBoard.CategoryOrder =
                        informationBoard.ConvertToListOfInt(informationBoardModel.CategoryOrder);
                }

                informationBoard.CheckCategoryOrder();
            }

            return result;
        }

        private async Task<List<PostModel>> GetPostModels(int categoryId)
        {
            var sql = $"select * from Post where CategoryId = {categoryId};";
            return await LoadData<PostModel, dynamic>(sql, new { });
        }

        private async Task<List<CategoryModel>> GetCategoryModels(int informationBoardId)
        {
            var sql = $"select * from Category where InformationBoardId = {informationBoardId};";
            return await LoadData<CategoryModel, dynamic>(sql, new { });
        }


        private async Task<List<InformationBoardModel>> GetInformationBoardModels(int licenseId)
        {
            var sql = $"select * from InformationBoard where LicenseId = {licenseId};";
            return await LoadData<InformationBoardModel, dynamic>(sql, new { });
        }


        public async Task<LicenseModel> GetLicenseModel(int licenseId)
        {
            var sql = $"select * from License where LicenseId = {licenseId};";
            var licenseList = await LoadData<LicenseModel, dynamic>(sql, new { });

            return licenseList.First();
        }
    }
}