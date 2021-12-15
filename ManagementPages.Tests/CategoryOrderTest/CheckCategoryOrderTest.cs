using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Model;

namespace ManagementPages.Tests
{
    public class CheckCategoryOrderTest
    {
        Dictionary<int, CategoryModel> Categories = new();
        List<int> CategoryOrder = new List<int> { 223, 144, 342 };

        

        [Fact]
        public void TestCategoryOrder()
        {
            InformationBoardDataModel informationBoardDataModel = new InformationBoardDataModel();


            var result = new Dictionary<int, ICategoryModel>();

            CategoryModel categoryModel = new CategoryModel();

            /* When CategoryOrder is the same after executing CheckCategoryOrder() */
            // var categoryOrderBefore = new List<int> { 223, 144, 342 };

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            var expectedCategoryOrder = new List<int> { 223, 1443, 3423 };

            Categories.Add(223, categoryModel);
            Categories.Add(1443, categoryModel);
            Categories.Add(3423, categoryModel);

            CheckCategoryOrder();

            /* When CategoryOrder is the same after executing CheckCategoryOrder() */
            // Assert.Equal(categoryOrderBefore, CategoryOrder);

            /* When CategoryOrder changes after executing CheckCategoryOrder() */
            Assert.Equal(expectedCategoryOrder, CategoryOrder);
        }


        public void CheckCategoryOrder()
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
        }


    }    
}

        
