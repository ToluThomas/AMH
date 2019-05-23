using Xunit;
using AMHaulage.BusinessLogic;
using AMHaulage.Models;
using System.Linq;

namespace AMHaulage.Tests.BusinessLogic
{
    public class AppointmentsBusinessLogicTests
    {
        [Fact]
        public void GetAppointmentsQueryBySummary_ShouldReturnDefaultAppointmentsQuery_WhenSearchStringNull()
        {
            //Arrange
            string searchString = null;

            // Act
            var appointmentsQuery = AppointmentsBusinessLogic.GetAppointmentsQueryBySummary(searchString);
            
            // Assert
            Assert.Null(appointmentsQuery);
        }
    }
}