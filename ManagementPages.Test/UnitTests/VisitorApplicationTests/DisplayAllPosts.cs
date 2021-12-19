using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorApplication.Server.Controllers;
using Xunit;

namespace VisitorApplication.Test
{
    public class DisplayAllPosts
    {
        [Fact]
        public async void TestDisplayAllPosts()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IPost IPost = new PostService(configuration);
            PostController postController = new PostController(IPost);

            // Act
            var postList = await IPost.PostList();
            var publishedPosts = postList.Where(post => post.IsPublished == true);

            // Assert
            Assert.NotEmpty(publishedPosts);
        }
    }
}
