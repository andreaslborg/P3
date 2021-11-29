using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ICategoryViewModel
    {
        public Category CategoryModel { get; set; }

        List<IPostViewModel> Posts { get; set; }

        public void GetCategoryData(int categoryId);

        public void GetPosts(int categoryId);

        public Task AddNewPost(Post newPost, int categoryId, bool isPublished, IDbService dbService);

        Task EditCategory(int categoryModelCategoryId, IDbService dbService);

        Task DeleteCategory(IDbService dbService);

    }
}