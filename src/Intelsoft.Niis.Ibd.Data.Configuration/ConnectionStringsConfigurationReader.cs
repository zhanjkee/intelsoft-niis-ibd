using Intelsoft.Niis.Ibd.Configuration;

namespace Intelsoft.Niis.Ibd.Data.Configuration
{
    public class ConnectionStringsConfigurationReader : ConfigurationReader<ConnectionStringsConfiguration>
    {
        public ConnectionStringsConfiguration Read()
        {
            return Read(ConnectionStringsConfiguration.SectionName);
        }
    }
}