using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intelsoft.Niis.Ibd.Configuration.Tests
{
    [TestClass]
    public class NiisIbdConfigurationTests
    {
        [TestMethod]
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
            Assert.IsTrue(configuration.ConnectionString.Equals(connectionString));
            Assert.IsTrue(configuration.ShepWebAddress.Equals(shepWebAddress));
            Assert.IsTrue(configuration.LogPath.Equals(logPath));
            Assert.IsTrue(configuration.FileSizeLimitMBytes == fileSizeLimitMBytes);
        }
    }
}
