using Intelsoft.Niis.Ibd.ContractSenderService.Configuration;
using Xunit;

namespace Intelsoft.Niis.Ibd.Configuration.UnitTests
{
    public class ContractSenderServiceConfigurationUnitTests
    {
        [Fact]
        public void Read_ContractSenderServiceConfiguration_ShouldSucceed()
        {
            // Arrange.
            const string shepWebAddress = "http://10.61.40.133:9010/bip-async";
            const string serviceId = "IbdNiisActual";
            const string senderId = "kazpatent";
            const string password = "CY}C@ne$Wo";
            const bool needToSingXml = false;
            const string edsPath = "C:\\EDS\\test.pfx";
            const string edsPassword = "123456";
            const bool useRetryPolicy = false;
            const int maxRetryAttempts = 2;
            const int pauseBetweenFailuresInMinutes = 3;
            const int pauseBetweenCyclesInMinutes = 1;

            // Act.
            var configuration = new ContractSenderServiceConfigurationReader().Read();

            // Assert.
            Assert.Equal(configuration.ShepWebAddress, shepWebAddress);
            Assert.Equal(configuration.ServiceId, serviceId);
            Assert.Equal(configuration.SenderId, senderId);
            Assert.Equal(configuration.Password, password);
            Assert.Equal(configuration.NeedToSignXml, needToSingXml);
            Assert.Equal(configuration.EdsPath, edsPath);
            Assert.Equal(configuration.EdsPassword, edsPassword);
            Assert.Equal(configuration.UseRetryPolicy, useRetryPolicy);
            Assert.Equal(configuration.MaxRetryAttempts, maxRetryAttempts);
            Assert.Equal(configuration.PauseBetweenFailuresInMinutes, pauseBetweenFailuresInMinutes);
            Assert.Equal(configuration.PauseBetweenCyclesInMinutes, pauseBetweenCyclesInMinutes);
        }
    }
}