using System.Configuration;

namespace Intelsoft.Niis.Ibd.Configuration
{
    public class NiisIbdSettingsReader
    {
        public static NiisIbdSettings Read()
        {
            return ConfigurationManager.GetSection(NiisIbdSettings.SectionName) as NiisIbdSettings;
        }
    }
}
