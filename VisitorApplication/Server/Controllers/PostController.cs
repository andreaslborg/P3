using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        readonly IPost _IPost;

        public PostController(IPost Ipost)
        {
            _IPost = Ipost;
        }

        [HttpGet("[action]")]
        public async Task<List<Post>> PostList()
        {
            var post = await _IPost.PostList();
            return post;
        }
    }
}
