using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using Bunit.TestDoubles;
using Xunit;
using ManagementPages.Functions;

namespace ManagementPages.Tests
{
    public class Test1 : TestContext
    {
        

        [Fact]
        public void CounterStartsAtZero()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Assert that content of the paragraph shows counter at zero
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }

        [Fact]
        public void ClickingButtonIncrementsCounter()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Act - click button to increment counter
            cut.Find("button").Click();

            // Assert that the counter was incremented
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}
