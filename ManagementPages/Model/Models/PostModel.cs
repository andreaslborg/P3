using System.Threading.Tasks;
using ManagementPages.Functions;

namespace ManagementPages.Model
{
    public class PostModel : IPostModel
    {
        public PostDataModel PostDataModel { get; set; } = new();

        public async Task EditPost(IDbService dbService)
        {
            var sql =
                $"update Post set Title = \"{PostDataModel.Title}\", Text = \"{PostDataModel.Text}\", Author = \"{PostDataModel.Author}\", IsPublished = {PostDataModel.IsPublished}, Link = \"{PostDataModel.Link}\" where PostId = {PostDataModel.PostId}";

            await dbService.SaveData(sql, PostDataModel);
        }

        public async Task DeletePost(IDbService dbService)
        {
            var sql = $"delete from Post where PostId = {PostDataModel.PostId}";

            await dbService.SaveData(sql, PostDataModel);
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