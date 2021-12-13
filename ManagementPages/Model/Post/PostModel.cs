using System.Threading.Tasks;
using ManagementPages.Services;

namespace ManagementPages.Model.Post
{
    public class PostModel : IPostModel
    {
        public PostDataModel PostDataModel { get; set; } = new();

        public delegate void PostEvent(PostModel postModel);

        public PostEvent PostDeleted;

        public async Task EditPost(IDbService dbService)
        {
            var sql =
                $"update Post set Title = \"{PostDataModel.Title}\", Text = \"{PostDataModel.Text}\", Author = \"{PostDataModel.Author}\", IsPublished = {PostDataModel.IsPublished}, Link = \"{PostDataModel.Link}\" where PostId = {PostDataModel.PostId}";

            await dbService.SaveData(sql, PostDataModel);
        }

        public async Task DeletePostFromDatabase(IDbService dbService)
        {
            var sql = $"delete from Post where PostId = {PostDataModel.PostId}";

            await dbService.SaveData(sql, PostDataModel);

            PostDeleted?.Invoke(this);
        }

        // method to compare to posts based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            if (obj is IPostModel other) return PostDataModel.PostId == other.PostDataModel.PostId;

            return false;
        }

        public override int GetHashCode()
        {
            return PostDataModel.PostId;
        }
    }
}