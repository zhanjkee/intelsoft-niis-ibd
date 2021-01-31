using Xunit;

namespace Intelsoft.Niis.Ibd.Configuration.Tests
{
    public class NiisIbdConfigurationTests
    {
        [Fact]
        public void ReadConfigurationTest()
        {
            // Arrange.
            const string connectionString = "Server=(local);Database=niis_ibd;Trusted_Connection=True;";
            const string shepWebAddress = "http://10.61.40.133:9010/bip-async";
            const string logPath = "..\\\\logs";
            const int fileSizeLimitMBytes = 1024;
            
            // Act.
            var configuration = NiisIbdSettingsReader.Read();
            
            // Assert.
            Assert.Equal(configuration.ConnectionString, connectionString);
            Assert.Equal(configuration.ShepWebAddress, shepWebAddress);
            Assert.Equal(configuration.LogPath,(logPath));
            Assert.True(configuration.FileSizeLimitMBytes == fileSizeLimitMBytes);
        }
    }
}
