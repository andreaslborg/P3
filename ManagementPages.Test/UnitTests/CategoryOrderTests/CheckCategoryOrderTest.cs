using System.Collections.Generic;
using Xunit;
using ManagementPages.Model.Category;
using ManagementPages.Model.InformationBoard;

namespace ManagementPages.Tests
{
    public class CheckCategoryOrderTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        public void TestCheckCategoryOrder(int[] input, int[] expected)
        {
            // Arrange
            InformationBoardModel informationBoardModel = new InformationBoardModel();
            informationBoardModel.CategoryOrder = new List<int> { 223, 144, 342 };
            CategoryModel categoryModel = new CategoryModel();

            var expectedCategoryOrder = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                expectedCategoryOrder.Add(expected[i]);
            }

            informationBoardModel.Categories.Add(input[0], categoryModel);
            informationBoardModel.Categories.Add(input[1], categoryModel);
            informationBoardModel.Categories.Add(input[2], categoryModel);

            // Act
            informationBoardModel.CheckCategoryOrder();

            // Assert

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            Assert.Equal(expectedCategoryOrder, informationBoardModel.CategoryOrder);
        }
    }
}

/*
 * 
    1 - De kategorier der er i categoryOrder (liste) er præcis det samme som dem der er i category dictionary
    2 - Der er nogle ID'er i categoryOrder som ikke har en korresponderende ID i category dictionary
    3 - Der mangler nogle ID'er i categoryOrder i forhold til de kategorier der er i category dictionary
    4 - Kombination af 2 og 3 - Der mangler ID'er og der er nogle forkerte ID'er
    5 - categoryOrder er en tom liste
    6 - category dicitionary er en tom liste
 */