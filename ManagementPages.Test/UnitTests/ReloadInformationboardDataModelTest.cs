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
    public class ReloadInformationboardDataModelTest
    {
        [Fact]
        public async void TestReloadInformationboardDataModel()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);
            
            InformationBoardModel informationBoardModel = new InformationBoardModel();

            informationBoardModel.InformationBoardDataModel = new();




        }
    }


    public async Task ReloadInformationBoardDataModel(IDbService dbService)
    {
        var sql =
            $"select * from InformationBoard where InformationBoardId = {InformationBoardDataModel.InformationBoardId};";

        var informationBoardList = await dbService.LoadData<InformationBoardDataModel, dynamic>(sql, new { });

        InformationBoardDataModel = informationBoardList.First();
    }
}



