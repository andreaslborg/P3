using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IPostViewModel
    {
        PostModel PostModel { get; set; }

        Task EditPost(IDbService dbService);

        Task DeletePost(IDbService dbService);
    }
}