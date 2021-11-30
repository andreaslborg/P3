using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    public interface IPost
    {
        Task<List<Post>> PostList();
    }

    public class PostService //: IPost
    {
    }
}
