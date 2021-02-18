using Intelsoft.Niis.Ibd.Data.Configuration;
using Xunit;

namespace Intelsoft.Niis.Ibd.Configuration.UnitTests
{
    public class ConnectionStringsConfigurationUnitTests
    {
        [Fact]
        public void Read_ConnectionStringsConfiguration_ShouldSucceed()
        {
            // Arrange.
            const string connectionString = "Server=(local);Database=niis_ibd;Trusted_Connection=True;";
            const bool useRetryPolicy = false;
            const int maxRetryAttempts = 2;
            const int pauseBetweenFailuresInMinutes = 3;

            // Act.
            var configuration = new ConnectionStringsConfigurationReader().Read();

            // Assert.
            Assert.Equal(configuration.ConnectionString, connectionString);
            Assert.Equal(configuration.UseRetryPolicy, useRetryPolicy);
            Assert.Equal(configuration.MaxRetryAttempts, maxRetryAttempts);
            Assert.Equal(configuration.PauseBetweenFailuresInMinutes, pauseBetweenFailuresInMinutes);
        }
    }
}