using AMHaulage.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AMHaulage.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }

        [Fact]
        public void Privacy_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Privacy() as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Privacy");
        }

    }
}
