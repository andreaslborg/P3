using System;
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

        public Post PostModel { get; set; }

        public void GetPostData(int licenseId)
        {
            throw new NotImplementedException();
        }
    }
}