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

            //CheckCategoryOrder();

            /* When CategoryOrder is the same after executing CheckCategoryOrder() */
            // Assert.Equal(categoryOrderBefore, CategoryOrder);

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            Assert.Equal(expectedCategoryOrder, informationBoardModel.CategoryOrder);
        }


        /*public void CheckCategoryOrder()

        {
            // check if all categories are in the CategoryOrder (meaning that they will be displayed), and
            // add them to the end, if they are missing
            List<int> keysToAdd = new();
            List<int> keysToRemove = new();

            foreach (var category in Categories)
                if (!CategoryOrder.Contains(category.Key))
                    keysToAdd.Add(category.Key);

            // check if there are any invalid ids in the CategoryOrder, and if so - delete them
            foreach (var key in CategoryOrder)
                if (!Categories.ContainsKey(key))
                    keysToRemove.Add(key);

            // keys cannot be deleted/added inside foreach loop as it messes up the order
            foreach (var key in keysToAdd) CategoryOrder.Add(key);

            foreach (var key in keysToRemove) CategoryOrder.Remove(key);
        }*/


    }
}
