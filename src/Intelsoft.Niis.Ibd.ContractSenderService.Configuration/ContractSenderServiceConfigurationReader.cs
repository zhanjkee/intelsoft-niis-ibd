using Intelsoft.Niis.Ibd.Configuration;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Configuration
{
    public class ContractSenderServiceConfigurationReader : ConfigurationReader<ContractSenderServiceConfiguration>
    {
        public ContractSenderServiceConfiguration Read()
        {
            return Read(ContractSenderServiceConfiguration.SectionName);
        }
    }
}