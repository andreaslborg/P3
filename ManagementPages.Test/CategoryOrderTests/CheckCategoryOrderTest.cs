using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Model.Category;
using ManagementPages.Model.InformationBoard;
using ManagementPages.Services;

namespace ManagementPages.Tests
{
    public class CheckCategoryOrderTest
    {
        [Fact]
        public void TestCategoryOrder()
        {
            InformationBoardDataModel informationBoardDataModel = new InformationBoardDataModel();
            InformationBoardModel informationBoardModel = new InformationBoardModel();
            informationBoardModel.CategoryOrder = new List<int> { 223, 144, 342 };

            var result = new Dictionary<int, ICategoryModel>();

            CategoryModel categoryModel = new CategoryModel();

            /* When CategoryOrder is the same after executing CheckCategoryOrder() */
            // var categoryOrderBefore = new List<int> { 223, 144, 342 };

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            var expectedCategoryOrder = new List<int> { 223, 1443, 3423 };

            informationBoardModel.Categories.Add(223, categoryModel);
            informationBoardModel.Categories.Add(1443, categoryModel);
            informationBoardModel.Categories.Add(3423, categoryModel);

            informationBoardModel.CheckCategoryOrder();

            /* When CategoryOrder is the same after executing CheckCategoryOrder() */
            // Assert.Equal(categoryOrderBefore, CategoryOrder);

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            Assert.Equal(expectedCategoryOrder, informationBoardModel.CategoryOrder);
        }
    }
}
