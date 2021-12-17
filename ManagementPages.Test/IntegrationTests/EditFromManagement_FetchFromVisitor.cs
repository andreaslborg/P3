using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using VisitorApplication.Server.Controllers;
using VisitorApplication.Shared;
using System.Collections.Generic;
using ManagementPages.Model.Post;

namespace ManagementPages.Test.IntegrationTests
{
    public class EditFromManagement_FetchFromVisitor
    {
        [Fact]
        public async Task EditFromManagement_And_FetchFromVisitor()
        {
            // Insert from management
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            DbService dbService = new DbService(configuration);

            PostModel postModel = new PostModel();

            PostDataModel postDataModel = new PostDataModel
            {
                Title = "Good test title",
                Text = "Test text",
                Author = "Test Author",
                CategoryId = 100,
                IsPublished = true,
                Link = "Test link."
            };

            var sqlInsert = $"insert into Post (Title, Text, CategoryId, Author, IsPublished, Link) values (\"{postDataModel.Title}\", \"{postDataModel.Text}\",{postDataModel.CategoryId}, \"{postDataModel.Author}\", {postDataModel.IsPublished}, \"{postDataModel.Link}\" );";
            await dbService.SaveData(sqlInsert, postDataModel);

            postDataModel.Title = "Edited test title";
            postDataModel.Text = "Edited test text";
            postDataModel.Author = "Edited test author";
            postDataModel.Link = "Edited test link.";

            postModel.PostDataModel = postDataModel;

            var sqlSelect = "Select * from Post";
            var postList = await dbService.LoadData<PostDataModel,dynamic>(sqlSelect, new { });

            var selectedTestPost = postList.Where(item => item.Title == "Good test title").First();

            postModel.PostDataModel.PostId = selectedTestPost.PostId;

            await postModel.EditPost(dbService);

            //Fetch from visitor app
            IPost post = new PostService(configuration);
            PostController postController = new PostController(post);

            var postsFromVisitorApp = await post.PostList();

            bool objectFound = postsFromVisitorApp.Any(item => item.Title == "Edited test title");

            Assert.True(objectFound);
        }
    }
}