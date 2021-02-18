using Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration;
using Xunit;

namespace Intelsoft.Niis.Ibd.Configuration.UnitTests
{
    public class SerilogConfigurationUnitTests
    {
        [Fact]
        public void Read_SerilogConfiguration_ShouldSucceed()
        {
            // Arrange.
            const string logPath = "..\\\\logs";
            const int fileSizeLimitMBytes = 1024;

            // Act.
            var configuration = new SerilogConfigurationReader().Read();

            // Assert.
            Assert.Equal(configuration.LogPath, logPath);
            Assert.Equal(configuration.FileSizeLimitMBytes, fileSizeLimitMBytes);
        }
    }
}