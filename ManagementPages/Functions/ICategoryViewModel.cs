using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ICategoryViewModel
    {
        CategoryModel CategoryModel { get; set; }

        List<IPostViewModel> Posts { get; set; }

        Task<List<IPostViewModel>> LoadPosts(IDbService dbService);

        Task AddNewPost(PostModel newPost, bool isPublished, IDbService dbService);

        Task EditCategory(IDbService dbService);

        Task DeleteCategory(IDbService dbService);
    }
}