using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ICategoryViewModel
    {
        public Category CategoryModel { get; set; }

        //List<IPostViewModel> Posts = new List<IPostViewModel>();

        public void GetCategoryData(int categoryId);

        public void GetPosts(int categoryId);
    }
}
