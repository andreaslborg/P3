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
            string sql = $"update Post set Title = \"{PostModel.Title}\", Text = \"{PostModel.Text}\", Author = \"{PostModel.Author}\", IsPublished = {PostModel.IsPublished} where PostId = {PostModel.PostId}";
           
            await dbService.SaveData(sql, PostModel);
        }

        public async Task DeletePost(IDbService dbService)
        {
            string sql = $"delete from Post where PostId = {PostModel.PostId}";

            await dbService.SaveData(sql, PostModel);
        }

        // method to compare to posts based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            var other = obj as IPostViewModel;
            return PostModel.PostId == other.PostModel.PostId;
        }

        public override int GetHashCode()
        {
            return PostModel.PostId;
        }
    }
}