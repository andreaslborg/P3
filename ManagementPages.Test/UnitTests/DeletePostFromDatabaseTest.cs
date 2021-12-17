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
    public class DeletePostFromDatabaseTest
    {
        [Fact]
        public async void TestDeletePostFromDatabase()
        {
            // Arrange
            // Insert from management
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);
            IPostModel selectedPost = new PostModel();

            var postInitial = new PostDataModel { CategoryId = 1, Title = "Test title",
                Text = "Test text", Author = "Tester", IsPublished = true, Link = "Test Link" };

            selectedPost.PostDataModel = postInitial;

            var sqlInsert2 = $"insert into Post (Title, CategoryId, Text, Author, IsPublished, Link) values (\"{postInitial.Title}\", {postInitial.CategoryId}, \"{postInitial.Text}\", \"{postInitial.Author}\", {postInitial.IsPublished}, \"{postInitial.Link}\" );";
            var sqlSelect = "Select * from Post;";

            await dbService.SaveData(sqlInsert2, postInitial);

            var AllPostsList = await dbService.LoadData<PostDataModel, dynamic>(sqlSelect, new { });

            // This boolean shows that the post has been saved in the database
            bool objectFoundAfterAddingPost = AllPostsList.Any(item => item.Title == postInitial.Title);

            var testPost = AllPostsList.Where(item => item.Title == "Test title").First();

            selectedPost.PostDataModel.PostId = testPost.PostId;

            // Act
            await selectedPost.DeletePostFromDatabase(dbService);

            AllPostsList = await dbService.LoadData<PostDataModel, dynamic>(sqlSelect, new { });

            // This boolean show that the post has been deleted from the database
            bool objectFoundAfterDeletingPost = AllPostsList.Any(item => item.Title == postInitial.Title);

            // Assert
            Assert.NotEqual(objectFoundAfterAddingPost, objectFoundAfterDeletingPost);
        }
    }
}
