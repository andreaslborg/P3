using ManagementPages.Model.Category;
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
    public class DeleteCategoryFromDatabaseTest
    {
        [Fact]
        public async void TestDeleteCategoryFromDatabase()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);
            CategoryModel categoryModel = new CategoryModel();

            var categoryInitial = new CategoryDataModel { InformationBoardId = 1, Title = "Test title", IsPublished = true, Icon = "Test icon" };

            categoryModel.CategoryDataModel = categoryInitial;

            var sqlInsert = $"insert into Category (Title, InformationBoardId, IsPublished, Icon) values(\"{categoryInitial.Title}\", {categoryInitial.InformationBoardId}, {categoryInitial.IsPublished}, \"{categoryInitial.Icon}\"); ";
            var sqlSelect = "Select * from Category;";

            await dbService.SaveData(sqlInsert, categoryInitial);

            var AllPostsList = await dbService.LoadData<CategoryDataModel, dynamic>(sqlSelect, new { });

            // This boolean shows that the post has been saved in the database
            bool objectFoundAfterAddingPost = AllPostsList.Any(item => item.Title == categoryInitial.Title);

            var testPost = AllPostsList.Where(item => item.Title == "Test title").First();

            categoryModel.CategoryDataModel.CategoryId = testPost.CategoryId;

            // Act
            await categoryModel.DeleteCategoryFromDatabase(dbService);

            AllPostsList = await dbService.LoadData<CategoryDataModel, dynamic>(sqlSelect, new { });

            // This boolean show that the post has been deleted from the database
            bool objectFoundAfterDeletingPost = AllPostsList.Any(item => item.Title == categoryInitial.Title);

            // Assert
            Assert.NotEqual(objectFoundAfterAddingPost, objectFoundAfterDeletingPost);
        }
    }
}
