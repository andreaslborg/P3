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
        Dictionary<int, ICategoryModel> Categories = new();
        List<int> CategoryOrder = new List<int> { 223, 144, 342, 412, 667, 554 };


        [Fact]
        public void TestCategoryOrder()
        {
            InformationBoardDataModel informationBoardDataModel = new InformationBoardDataModel();
            


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

        
