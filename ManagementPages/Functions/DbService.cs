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

            var informationBoardModels = new List<InformationBoard>();
            informationBoardModels = await GetInformationBoardModels(licenseId);

            foreach (var informationBoardModel in informationBoardModels)
            {
                var informationBoard = new InformationBoardViewModel();
                informationBoard.InformationBoardModel = informationBoardModel;
                informationBoard.Categories = await GetCategories(informationBoard.InformationBoardModel.InformationBoardId);
                result.Add(informationBoard);
            }

            return result;
        }

        public async Task<List<ICategoryViewModel>> GetCategories(int informationBoardId)
        {
            var result = new List<ICategoryViewModel>();

            var categoryModels = new List<Category>();
            categoryModels = await GetCategoryModels(informationBoardId);

            foreach (var categoryModel in categoryModels)
            {
                var category = new CategoryViewModel();
                category.CategoryModel = categoryModel;
                category.Posts = await GetPosts(category.CategoryModel.CategoryId);
                result.Add(category);
            }

            return result;
        }

        public async Task<List<IPostViewModel>> GetPosts(int categoryId)
        {
            var result = new List<IPostViewModel>();

            var postModels = new List<Post>();
            postModels = await GetPostModels(categoryId);

            foreach (var postModel in postModels)
            {
                var post = new PostViewModel();
                post.PostModel = postModel;
                result.Add(post);
            }

            return result;
        }

        private async Task<List<Post>> GetPostModels(int categoryId)
        {
            var postList = new List<Post>();

            string sql = $"select * from Post where CategoryId = {categoryId};";
            postList = await LoadData<Post, dynamic>(sql, new { });

            return postList;
        }

        private async Task<List<Category>> GetCategoryModels(int informationBoardId)
        {
            var categoryList = new List<Category>();

            string sql = $"select * from Category where InformationBoardId = {informationBoardId};";
            categoryList = await LoadData<Category, dynamic>(sql, new { });

            return categoryList;
        }


        private async Task<List<InformationBoard>> GetInformationBoardModels(int licenseId)
        {
            var informationBoardList = new List<InformationBoard>();

            string sql = $"select * from InformationBoard where LicenseId = {licenseId};";
            informationBoardList = await LoadData<InformationBoard, dynamic>(sql, new { });

            return informationBoardList;
        }


        public async  Task<License> GetLicenseModel(int licenseId)
        {
            List<License> licenseList = new List<License>();

            string sql = $"select * from License where LicenseId = {licenseId};";
            licenseList = await LoadData<License, dynamic>(sql, new { });

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

