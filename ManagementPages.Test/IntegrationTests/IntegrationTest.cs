using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using VisitorApplication.Server.Controllers;
using VisitorApplication.Shared;
using System.Collections.Generic;

namespace ManagementPages.Test.IntegrationTests
{
    public class IntegrationTest
    {
        [Fact]
        public async Task AddFromManagement_And_FetchFromVisitor()
        {
            // Insert from management
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            Category category = new Category
            {
                Title = "Test title",
                InformationBoardId = 100,
                Icon = "Test icon",
                IsPublished = true
            };

            var sqlInsert = $"insert into Category (Title, InformationBoardId, IsPublished, Icon) values(\"{category.Title}\", {category.InformationBoardId}, {category.IsPublished}, \"{category.Icon}\");";
            await dbService.SaveData(sqlInsert, category);


            //Fetch from visitor application
            ICategory Icategory = new CategoryService(configuration);
            CategoryController categoryController = new CategoryController(Icategory);

            var categoryList = await Icategory.CategoryList();

            bool objectFound = categoryList.Any(item => item.Title == category.Title && item.InformationBoardId == category.InformationBoardId && item.IsPublished == category.IsPublished && item.Icon == category.Icon);

            //bool objectFound = categoryList.Any(item => item.Title == category.Title && item.InformationBoardId == category.InformationBoardId && item.IsPublished == category.IsPublished);

            Assert.True(objectFound);

        }
    }
}
