using Intelsoft.Niis.Ibd.Configuration;

namespace Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration
{
    public class SerilogConfigurationReader : ConfigurationReader<SerilogConfiguration>
    {
        public SerilogConfiguration Read()
        {
            return Read(SerilogConfiguration.SectionName);
        }
    }
}