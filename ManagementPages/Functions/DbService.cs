using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "default";

        public DbService(IConfiguration config)
        {
            _config = config;
        }   
     
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionstring))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }

        
        public async Task<ILicenseViewModel> InitializeLicense(int licenseId)
        {
            ILicenseViewModel result = new LicenseViewModel();

            result.LicenseModel = await GetLicenseModel(licenseId);
            result.InformationBoards = await GetInformationBoards(licenseId);

            return result;
        }

        private async Task<List<IInformationBoardViewModel>> GetInformationBoards(int licenseId)
        {
            var result = new List<IInformationBoardViewModel>();

            var informationBoardModels = new List<InformationBoardModel>();
            informationBoardModels = await GetInformationBoardModels(licenseId);

            foreach (var informationBoardModel in informationBoardModels)
            {
                var informationBoard = new InformationBoardViewModel();
                informationBoard.InformationBoardModel = informationBoardModel;
                informationBoard.Categories = await GetCategories(informationBoard.InformationBoardModel.InformationBoardId);
                result.Add(informationBoard);

                if (informationBoardModel.CategoryOrder != null)
                {
                    informationBoard.CategoryOrder = informationBoard.ConvertToListOfInt(informationBoardModel.CategoryOrder);
                }
                informationBoard.CheckCategoryOrder();
            }

            return result;
        }

        public async Task<Dictionary<int, ICategoryViewModel>> GetCategories(int informationBoardId)
        {
            var result = new Dictionary<int, ICategoryViewModel>();

            var categoryModels = new List<CategoryModel>();
            categoryModels = await GetCategoryModels(informationBoardId);

            foreach (var categoryModel in categoryModels)
            {
                var category = new CategoryViewModel();
                category.CategoryModel = categoryModel;
                category.Posts = await GetPosts(category.CategoryModel.CategoryId);
                result.Add(category.GetHashCode(), category);
            }

            return result;
        }

        public async Task<List<IPostViewModel>> GetPosts(int categoryId)
        {
            var result = new List<IPostViewModel>();

            var postModels = new List<PostModel>();
            postModels = await GetPostModels(categoryId);

            foreach (var postModel in postModels)
            {
                var post = new PostViewModel();
                post.PostModel = postModel;
                result.Add(post);
            }

            return result;
        }

        private async Task<List<PostModel>> GetPostModels(int categoryId)
        {
            var postList = new List<PostModel>();

            string sql = $"select * from Post where CategoryId = {categoryId};";
            postList = await LoadData<PostModel, dynamic>(sql, new { });

            return postList;
        }

        private async Task<List<CategoryModel>> GetCategoryModels(int informationBoardId)
        {
            var categoryList = new List<CategoryModel>();

            string sql = $"select * from Category where InformationBoardId = {informationBoardId};";
            categoryList = await LoadData<CategoryModel, dynamic>(sql, new { });

            return categoryList;
        }


        private async Task<List<InformationBoardModel>> GetInformationBoardModels(int licenseId)
        {
            var informationBoardList = new List<InformationBoardModel>();

            string sql = $"select * from InformationBoard where LicenseId = {licenseId};";
            informationBoardList = await LoadData<InformationBoardModel, dynamic>(sql, new { });

            return informationBoardList;
        }


        public async  Task<LicenseModel> GetLicenseModel(int licenseId)
        {
            List<LicenseModel> licenseList = new List<LicenseModel>();

            string sql = $"select * from License where LicenseId = {licenseId};";
            licenseList = await LoadData<LicenseModel, dynamic>(sql, new { });

            return licenseList.First();
        }

        /* ---------------------------- udkast til generic method, dog skal alle overliggende ID'er enten hedde det samme (e.g., ParentID, og så ID til eget id) 
        private async Task<List<T>> GetCategoryModels<T>(int informationBoardId)
        {
            var informationBoardList = new List<T>();

            string sql = $"select * from {nameof(T)} where LicenseId = {licenseId};";
            informationBoardList = await LoadData<InformationBoard, dynamic>(sql, new { });

            return informationBoardList;
        } */
    }
}

