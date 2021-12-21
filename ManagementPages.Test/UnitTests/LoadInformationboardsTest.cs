using ManagementPages.Model.License;
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
    public class LoadInformationboardsTest
    {
        [Fact]
        public async void TestLoadInformationboards()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            LicenseModel licenseModel = new LicenseModel();

            licenseModel.LicenseDataModel = new LicenseDataModel
            {
                LicenseId = 1, CustomerName = "Brugertest", RegistrationDate = DateTime.Today
            };

            //licenseModel.LicenseDataModel.LicenseId = 1;

            var informationboardList = await licenseModel.LoadInformationBoards(dbService);

            Assert.NotEmpty(informationboardList);
        }
    }
}
