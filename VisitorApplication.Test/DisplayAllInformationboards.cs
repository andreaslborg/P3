using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using VisitorApplication.Server.Controllers;
using Microsoft.Extensions.Configuration;

namespace VisitorApplication.Test
{
    public class DisplayAllInformationboards
    {
        // M7 - The content of each information board must be stored in a database from where it can be fetched.
        [Fact]
        public async void TestDisplayAllInformationboards()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IInformationboard Iinformationboard = new InformationboardService(configuration);
            InformationboardController categoryController = new InformationboardController(Iinformationboard);

            var informationboardList = await Iinformationboard.InformationboardList();

            // Assert
            var publishedInformationboards = informationboardList.Where(informationboard => informationboard.IsPublished == true);
            Assert.NotEmpty(publishedInformationboards);
        }
    }
}
