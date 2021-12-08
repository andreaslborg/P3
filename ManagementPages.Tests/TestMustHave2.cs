using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using Bunit.TestDoubles;
using Xunit;
using ManagementPages.UI.Components;
using ManagementPages.Model;

namespace ManagementPages.Tests
{
    public class TestMustHave2 : TestContext
    {
        [Fact]
        public void DoesNumbersAddUp()
        {
            // Arrange
            AddNums addNums = new AddNums();
            int input1 = 10;
            int input2 = 30;
            int expected = 40;

            int result = addNums.AddNumbers(input1, input2);

            Assert.Equal(expected, result);
        }
    }
}
