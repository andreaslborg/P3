using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorApplication.Server.Controllers;
using Xunit;

namespace VisitorApplication.Test
{
    public class DisplayAllCategories
    {
        [Fact]
        public async void TestDisplayAllCategories()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            ICategory ICategory = new CategoryService(configuration);
            CategoryController categoryController = new CategoryController(ICategory);

            // Act
            var categoryList = await ICategory.CategoryList();
            var publishedCategories = categoryList.Where(category => category.IsPublished == true);

            // Assert
            Assert.NotEmpty(publishedCategories);
        }
    }
}
