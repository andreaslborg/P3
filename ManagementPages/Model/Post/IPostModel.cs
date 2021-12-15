using System.Threading.Tasks;
using ManagementPages.Services;

namespace ManagementPages.Model.Post
{
    public interface IPostModel
    {
        PostDataModel PostDataModel { get; set; }

        Task EditPost(IDbService dbService);

        Task DeletePostFromDatabase(IDbService dbService);

        Task ReloadPostDataModel(IDbService dbService);
    }
}