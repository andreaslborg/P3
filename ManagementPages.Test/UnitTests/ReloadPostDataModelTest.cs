using ManagementPages.Model.Post;
using ManagementPages.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementPages.Test.UnitTests
{
    public class ReloadPostDataModelTest
    {
        [Fact]
        public async void TestReloadPostDataModel()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            IDbService dbService = new DbService(configuration);

            PostModel postModel = new PostModel();
            postModel.PostDataModel = new PostDataModel { PostId = 2, CategoryId = 1, Title = "Test title", 
                Text = "Test text", Author = "Tester" };

            var postDataModelBeforeReload = postModel.PostDataModel;

            await postModel.ReloadPostDataModel(dbService);

            Assert.NotEqual(postDataModelBeforeReload, postModel.PostDataModel);
        }
    }
}
