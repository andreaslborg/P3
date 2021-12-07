using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IPostViewModel
    {
        public PostModel PostModel { get; set; }

        public void GetPostData(int licenseId);

        Task EditPost(IDbService dbService);

        Task DeletePost(IDbService dbService);
    }
}