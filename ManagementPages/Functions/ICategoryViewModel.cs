using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ICategoryViewModel
    {
        public Category CategoryModel { get; set; }

         List<IPostViewModel> Posts { get; set; }

        public void GetCategoryData(int categoryId);

        public void GetPosts(int categoryId);
    }
}