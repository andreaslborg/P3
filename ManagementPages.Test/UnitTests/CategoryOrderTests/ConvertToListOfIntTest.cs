using System;
using System.Collections.Generic;
using Xunit;
using ManagementPages.Model.InformationBoard;

namespace ManagementPages.Tests
{
    public class ConvertToListOfIntTest
    {
        [Fact]
        public void TestConvertToListOfInt()
        {
            InformationBoardModel informationBoardModel = new InformationBoardModel();

            //InformationBoardDataModel informationBoardDataModel = new InformationBoardDataModel();

            informationBoardModel.InformationBoardDataModel.CategoryOrder = "223, 144, 342, 412, 667, 554";

            informationBoardModel.CategoryOrder = ConvertToListOfInt(informationBoardModel.InformationBoardDataModel.CategoryOrder);

            List<int> expectedCategoryOrder = new List<int> { 223, 144, 342, 412, 667, 554 };

            Assert.Equal(expectedCategoryOrder, informationBoardModel.CategoryOrder);
        }


        public List<int> ConvertToListOfInt(string input)
        {
            List<int> result = new();
            var list = input.Split(',');

            foreach (var numberString in list)
                try
                {
                    var number = int.Parse(numberString);
                    result.Add(number);
                }
                catch (FormatException)
                {
                    // Handle
                }

            return result;
        }

    }
}