﻿using ManagementPages.Model.InformationBoard;
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
    public class EditInformationboardTest
    {
        [Fact]
        public async void TestEditInformationboard()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            InformationBoardModel informationBoardModel = new InformationBoardModel();

            var informationboardInitial = new InformationBoardDataModel { LicenseId = 1, Title = "Test Informationboard", 
                Url="Test Url", QRCode = "Test QRCode", IsPublished = true, CategoryOrder = string.Empty };

            var sqlInsert = $"insert into InformationBoard (Title, IsPublished) values(\"{informationboardInitial.Title}\", {informationboardInitial.IsPublished});";
            var sqlSelect = "Select * from InformationBoard;";

            await dbService.SaveData(sqlInsert, informationboardInitial);

            informationBoardModel.InformationBoardDataModel = new InformationBoardDataModel { LicenseId = 1, Title = "Informationboard Title Changed",
                Url = "Test Url", QRCode = "Test QRCode", IsPublished = true, CategoryOrder = string.Empty };

            var testList = await dbService.LoadData<InformationBoardDataModel, dynamic>(sqlSelect, new { });

            var testInformationboard = testList.Where(item => item.Title == "Test Informationboard").First();

            informationBoardModel.InformationBoardDataModel.InformationBoardId = testInformationboard.InformationBoardId;

            // Act
            Task task = informationBoardModel.EditInformationBoard(dbService);

            testList = await dbService.LoadData<InformationBoardDataModel, dynamic>(sqlSelect, new { });

            bool objectFound = testList.Any(item => item.Title == "Informationboard Title Changed");

            Assert.True(objectFound);
        }
    }
}