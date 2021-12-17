using System;
using System.Collections.Generic;
using Xunit;
using ManagementPages.Model.InformationBoard;
using ManagementPages.Services;

namespace ManagementPages.Tests
{
    public class ConvertToListOfIntTest
    {
        [Fact]
        public void TestConvertToListOfInt()
        {
            InformationBoardModel informationBoardModel = new InformationBoardModel();

            informationBoardModel.InformationBoardDataModel.CategoryOrder = "223, 144, 342, 412, 667, 554";

            informationBoardModel.CategoryOrder = ConversionService.ConvertCommaSeparatedStringToListOfInt(informationBoardModel.InformationBoardDataModel.CategoryOrder);

            List<int> expectedCategoryOrder = new List<int> { 223, 144, 342, 412, 667, 554 };

            Assert.Equal(expectedCategoryOrder, informationBoardModel.CategoryOrder);
        }
    }
}
