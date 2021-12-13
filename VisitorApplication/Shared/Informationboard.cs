using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorApplication.Shared
{
    public class Informationboard
    {
        public int InformationboardID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string QRCode { get; set; }
        public bool IsPublished { get; set; }
        public int LicenseID { get; set; }
        public string CategoryOrder { get; set; }

        public bool ContentIsValid => CheckIfContentIsValid();

        private bool CheckIfContentIsValid()
        {
            return !string.IsNullOrEmpty(Title) && Title.Length <= 30
                                                && InformationboardID > 0
                                                && LicenseID > 0;
        }
        
        public void CheckCategoryOrder(List<int> categoryOrder, List<Category> categories)
        {
            // check if all categories are in the CategoryOrder (meaning that they will be displayed), and
            // add them to the end, if they are missing
            List<int> keysToAdd = new();
            List<int> keysToRemove = new();

            foreach (var category in categories)
                if (!categoryOrder.Contains(category.CategoryId))
                    keysToAdd.Add(category.CategoryId);

            // check if there are any invalid ids in the CategoryOrder, and if so - delete them
            foreach (var key in categoryOrder)
                if (!categories.Any(x => x.CategoryId == key))
                    keysToRemove.Add(key);

            // keys cannot be deleted/added inside foreach loop as it messes up the order
            foreach (var key in keysToAdd) categoryOrder.Add(key);

            foreach (var key in keysToRemove) categoryOrder.Remove(key);
        }
    }
}
