using System;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class PostViewModel : IPostViewModel
    {
        public PostModel PostModel { get; set; } = new();

        public async Task EditPost(IDbService dbService)
        {
            var sql =
                $"update Post set Title = \"{PostModel.Title}\", Text = \"{PostModel.Text}\", Author = \"{PostModel.Author}\", IsPublished = {PostModel.IsPublished}, Link = \"{PostModel.Link}\" where PostId = {PostModel.PostId}";

            await dbService.SaveData(sql, PostModel);
        }

        public async Task DeletePost(IDbService dbService)
        {
            var sql = $"delete from Post where PostId = {PostModel.PostId}";

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