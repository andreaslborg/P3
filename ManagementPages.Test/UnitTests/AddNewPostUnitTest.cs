using System;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model.Category;
using ManagementPages.Model.Post;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ManagementPages.Test.UnitTests
{
    public class AddNewPostUnitTest
    {
        [Fact]
        public async Task AddNewPostTest()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            CategoryModel categoryModel = new CategoryModel();

            CategoryDataModel categoryDataModel = new CategoryDataModel
            {
                CategoryId = 1
            };

            categoryModel.CategoryDataModel = categoryDataModel;

            PostDataModel postDataModel = new PostDataModel
            {
                Title = "This is a test title",
                Text = "This is a test text",
                Author = "This is a test author",
                IsPublished = true,
                Link = "This is a test link"
            };

            await categoryModel.AddNewPost(postDataModel, postDataModel.IsPublished, dbService);

            bool objectFound = categoryModel.Posts.Any(item => item.PostDataModel.Title == postDataModel.Title
                                                            && item.PostDataModel.Text == postDataModel.Text
                                                            && item.PostDataModel.Author == postDataModel.Author
                                                            && item.PostDataModel.IsPublished == postDataModel.IsPublished
                                                            && item.PostDataModel.Link == postDataModel.Link);

            Assert.True(objectFound);
        }
    }
}
