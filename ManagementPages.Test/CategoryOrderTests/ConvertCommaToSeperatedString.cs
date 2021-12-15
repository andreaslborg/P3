using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Model.InformationBoard;

namespace ManagementPages.Tests
{
    public class ConvertCommaToSeperatedStringTest
    {
        [Fact]
        public void TestConvertCommaToSeperatedString()
        {
            InformationBoardDataModel informationBoardDataModel = new InformationBoardDataModel();
            List<int> CategoryOrder = new List<int> { 223, 144, 342, 412, 667, 554 };

            informationBoardDataModel.CategoryOrder = ConvertToCommaSeparatedString(CategoryOrder);

            var expectedCategoryOrderString = "223,144,342,412,667,554,";

            Assert.Equal(expectedCategoryOrderString, informationBoardDataModel.CategoryOrder);
        }

        string ConvertToCommaSeparatedString(List<int> list)
        {
            var result = string.Empty;

            foreach (var number in list) result += $"{number},";

            return result;
        }
    }
}
