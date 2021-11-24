using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IPostViewModel
    {
        public Post PostModel { get; set; }

        public void GetPostData(int licenseId);
    }
}