using Intelsoft.Niis.Ibd.Configuration;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Configuration
{
    public class ReceiveStatusServiceConfigurationReader : ConfigurationReader<ReceiveStatusServiceConfiguration>
    {
        public ReceiveStatusServiceConfiguration Read()
        {
            return Read(ReceiveStatusServiceConfiguration.SectionName);
        }
    }
}