using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementPages.Model.Category;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using VisitorApplication.Shared;
using ManagementPages.Model.InformationBoard;
using Xunit;

namespace ManagementPages.Test.DatabaseTests
{
    public class EditCategoryTest
    {
        CategoryModel categoryModel = new CategoryModel();

        [Fact]
        public async Task TestEditCategoryAsync()
        {
            // Arrange
            // Insert from management
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            var categoryInitial = new CategoryDataModel { Title = "Test title", InformationBoardId = 100,
                Icon = "Test icon", IsPublished = true };

            var sqlInsert = $"insert into Category (Title, InformationBoardId, IsPublished, Icon) values(\"{categoryInitial.Title}\", {categoryInitial.InformationBoardId}, {categoryInitial.IsPublished}, \"{categoryInitial.Icon}\");";
            var sqlSelect = "Select * from Category;";

            await dbService.SaveData(sqlInsert, categoryInitial);

            categoryModel.CategoryDataModel = new CategoryDataModel { CategoryId = 145, Title = "Så er den ændret", 
                Icon = "Test icon", IsPublished = true };

            var testList = await dbService.LoadData<CategoryDataModel, dynamic>(sqlSelect, new { });

            var testCategory = testList.Where(item => item.Title == "Test title").First();

            categoryModel.CategoryDataModel.CategoryId = testCategory.CategoryId;


            // Act
            Task task = categoryModel.EditCategory(dbService);

            testList = await dbService.LoadData<CategoryDataModel, dynamic>(sqlSelect, new { });

            bool objectFound = testList.Any(item => item.Title == "Så er den ændret");


            // Assert
            Assert.True(objectFound);
        }
    }
}
