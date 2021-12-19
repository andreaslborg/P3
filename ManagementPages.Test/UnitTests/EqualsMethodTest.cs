using ManagementPages.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementPages.Test.UnitTests
{
    public class EqualsMethodTest
    {
        [Fact]
        public void TestEqualsMethod()
        {
            PostModel postModel = new PostModel();
            postModel.PostDataModel = new PostDataModel
            {
                PostId = 1, CategoryId = 1, Title = "Equals Method Test",
                Text = "Test text", Author = "Tester"
            };

            IPostModel postModel1 = new PostModel();
            postModel1.PostDataModel = new PostDataModel
            {
                PostId = 1, CategoryId = 1, Title = "Other Equals Method Test",
                Text = "Test text", Author = "Tester"
            };

            bool objectEquals = postModel.Equals(postModel1);

            Assert.True(objectEquals);
        }
    }
}
