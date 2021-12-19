using System;
using System.Collections.Generic;
using System.Linq;
using VisitorApplication.Shared;
using Xunit;

namespace VisitorApplication.Tests
{
    public class CategoryOrderTest
    {
        [Fact]
        public void TestCategoryOrder()
        {
            List<int> CategoryOrder;

            Informationboard SelectedInformationboard = new Informationboard();

            SelectedInformationboard.CategoryOrder = "223, 144, 342, 412, 667, 554";

            CategoryOrder = SplitCategoriesToList(SelectedInformationboard);

            List<int> expectedCategoryOrder = new List<int> { 223, 144, 342, 412, 667, 554 };

            Assert.Equal(expectedCategoryOrder, CategoryOrder);
        }

        public List<int> SplitCategoriesToList(Informationboard informationboard)
        {
            List<string> stringIDList = informationboard.CategoryOrder.Split(",").ToList();
            List<int> intIDList = new();

            foreach (string item in stringIDList)
            {
                try
                {
                    intIDList.Add(Convert.ToInt32(item));
                }
                catch (FormatException)
                {
                }
            }

            return intIDList;
        }

    }
}