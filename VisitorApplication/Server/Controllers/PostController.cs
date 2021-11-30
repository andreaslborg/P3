using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        readonly IPost _Ipost;

        public PostController(IPost Ipost)
        {
            _Ipost = Ipost;
        }


        //[HttpGet("[action]")]
        //public async Task<List<Post>> PostList()

    }
}
