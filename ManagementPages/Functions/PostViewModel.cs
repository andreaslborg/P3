using System;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class PostViewModel : IPostViewModel
    {
        private DbService _dbService;

        public PostViewModel(DbService dbService, int postId)
        {
            _dbService = dbService;
            GetPostData(postId);
        }

        public PostViewModel()
        {
        }

        public Post PostModel { get; set; } = new Post();

        public void GetPostData(int licenseId)
        {
            throw new NotImplementedException();
        }

        public async Task EditPost(int postModelCategoryId, IDbService dbService)
        {
            string sql = $"update Post set Title = \"{PostModel.Title}\", Text = \"{PostModel.Text}\", Author = \"{PostModel.Author}\" where PostId = {PostModel.PostId}";
           
            await dbService.SaveData(sql, PostModel);
        }

        public async Task DeletePost(IDbService dbService)
        {
            string sql = $"delete from Post where PostId = {PostModel.PostId}";

            await dbService.SaveData(sql, PostModel);
        }
    }
}