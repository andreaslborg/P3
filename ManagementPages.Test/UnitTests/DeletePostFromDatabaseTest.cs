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
        public void TestDeletePostFromDatabase()
        {
            // Arrange
            // Insert from management
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);
            IPostModel SelectedPost = new PostModel();

            var categoryInitial = new PostDataModel
            {
                PostId = 200, CategoryId = 1, Title = "Test title",
                Text = "Test text", Author = "Tester", IsPublished = true, Link = "Test Link" };

            var sqlInsert2 = $"insert into Post (Title, CategoryId, Text, Author, IsPublished, Link) values (\"{categoryInitial.Title}\", {categoryInitial.CategoryId}, \"{categoryInitial.Text}\", \"{categoryInitial.Author}\", {categoryInitial.IsPublished}, \"{categoryInitial.Link}\" );";
            dbService.SaveData(sqlInsert2, categoryInitial);

            // Act


            // Assert
        }

    }
}
