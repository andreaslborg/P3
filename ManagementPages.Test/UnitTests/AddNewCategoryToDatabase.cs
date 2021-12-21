using ManagementPages.Model.Category;
using ManagementPages.Model.InformationBoard;
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
    public class AddNewCategoryToDatabase
    {
        [Fact]
        public async void TestAddNewCategoryToDatabase()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            InformationBoardModel informationboardModel = new InformationBoardModel();

            CategoryDataModel categoryDataModel = new CategoryDataModel
            {
                InformationBoardId = 1,
                Title = "This is a test title",
                IsPublished = true,
                Icon = "Test icon"
            };

            informationboardModel.InformationBoardDataModel.InformationBoardId = categoryDataModel.InformationBoardId;

            // Act
            await informationboardModel.AddNewCategory(categoryDataModel, categoryDataModel.IsPublished, dbService);

            bool objectFound = informationboardModel.Categories.Any(item => item.Key == categoryDataModel.InformationBoardId);

            // Assert
            Assert.True(objectFound);
        }
    }
}
