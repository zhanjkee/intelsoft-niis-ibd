using System.Configuration;
using Intelsoft.Niis.Ibd.Configuration.Base;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Configuration
{
    public class ReceiveStatusServiceConfiguration : ConfigurationSection, IConfiguration
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "receiveStatusServiceSettings";

        private const string WebAddressKey = "webAddress";

        /// <summary>
        ///     Адрес сервиса.
        /// </summary>
        [ConfigurationProperty(WebAddressKey, IsRequired = true)]
        public string WebAddress
        {
            get => this[WebAddressKey].ToString();
            set => this[WebAddressKey] = value;
        }
    }
}