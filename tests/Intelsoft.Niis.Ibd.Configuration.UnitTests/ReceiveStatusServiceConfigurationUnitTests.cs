using Intelsoft.Niis.Ibd.ReceiveStatusService.Configuration;
using Xunit;

namespace Intelsoft.Niis.Ibd.Configuration.UnitTests
{
    public class ReceiveStatusServiceConfigurationUnitTests
    {
        [Fact]
        public void Read_ReceiveStatusServiceConfiguration_ShouldSucceed()
        {
            // Arrange.
            const string webAddress = "http://localhost:5005/Services/SendMessageRequest.svc";

            // Act.
            var configuration = new ReceiveStatusServiceConfigurationReader().Read();

            // Assert.
            Assert.Equal(configuration.WebAddress, webAddress);
        }
    }
}