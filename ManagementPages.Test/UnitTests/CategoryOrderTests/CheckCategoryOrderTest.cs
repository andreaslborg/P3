using System.Collections.Generic;
using Xunit;
using ManagementPages.Model.Category;
using ManagementPages.Model.InformationBoard;

namespace ManagementPages.Tests
{
    public class CheckCategoryOrderTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3}, new int[] { 1, 2, 3})]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3})]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5})]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 4, 5 }, new int[] { 2, 4, 5 })]
        [InlineData(new int[] {}, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] {}, new int[] {})]
        public void CategoryOrderTest(int[] categoryArr, int[] dictionaryArr, int[] expectedArr)
        {
            //Arrange
            InformationBoardModel informationBoardModel = new InformationBoardModel();
            CategoryModel categoryModel = new CategoryModel();

            for (int i = 0; i < categoryArr.Length; i++)
                informationBoardModel.CategoryOrder.Add(categoryArr[i]);

            for (int i = 0; i < dictionaryArr.Length; i++)
                informationBoardModel.Categories.Add(dictionaryArr[i], categoryModel);

            var expectedList = new List<int>();
            for (int i = 0; i < expectedArr.Length; i++)
                expectedList.Add(expectedArr[i]);

            //Act
            informationBoardModel.CheckCategoryOrder();

            //Assert
            Assert.Equal(expectedList, informationBoardModel.CategoryOrder);
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