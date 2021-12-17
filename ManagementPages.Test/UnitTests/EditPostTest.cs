using ManagementPages.Model.Category;
using ManagementPages.Model.Post;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementPages.Test.UnitTests
{
    public class EditPostTest
    {
        [Fact]
        public async void TestEditPost()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            PostModel postModel = new PostModel();

            PostDataModel postInitial = new PostDataModel { Title = "This is a test title", CategoryId = 1,
                Text = "This is a test text", Author = "This is a test author", IsPublished = true, Link = "This is a test link" };

            var sqlInsert = $"insert into Post (Title, CategoryId, Text, Author, IsPublished, Link) values (\"{postInitial.Title}\", {postInitial.CategoryId}, \"{postInitial.Text}\", \"{postInitial.Author}\", {postInitial.IsPublished}, \"{postInitial.Link}\" );";
            var sqlSelect = "Select * from Post;";

            await dbService.SaveData(sqlInsert, postInitial);

            postModel.PostDataModel = new PostDataModel { Title = "The title has changed", CategoryId = 1,
                Text = "This is a test text", Author = "This is a test author", IsPublished = true, Link = "This is a test link" };

            var testList = await dbService.LoadData<PostDataModel, dynamic>(sqlSelect, new { });

            var testPost = testList.Where(item => item.Title == postInitial.Title).First();

            postModel.PostDataModel.PostId = testPost.PostId;

            // Act
            await postModel.EditPost(dbService);

            testList = await dbService.LoadData<PostDataModel, dynamic>(sqlSelect, new { });

            bool objectFoundAfterEditingPost = testList.Any(item => item.Title == postModel.PostDataModel.Title);

            // Assert
            Assert.True(objectFoundAfterEditingPost);
        }
    }
}
