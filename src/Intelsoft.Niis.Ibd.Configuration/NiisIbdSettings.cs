using System.Configuration;

namespace Intelsoft.Niis.Ibd.Configuration
{
    public class NiisIbdSettings : ConfigurationSection
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "niisIbdSettings";

        public const string ConnectionStringKey = "connectionString";
        public const string ReceiveStatusServiceWebAddressKey = "receiveStatusServiceWebAddress";
        public const string ShepWebAddressKey = "shepWebAddress";
        public const string LogPathKey = "logPath";
        public const string FileSizeLimitMBytesKey = "fileSizeLimitMBytes";

        /// <summary>
        ///     Connection string к базе данных SqlServer.
        /// </summary>
        [ConfigurationProperty(ConnectionStringKey,
                DefaultValue = "Server=(local);Database=niis_ibd;Trusted_Connection=True;",
                IsRequired = true)]
        public string ConnectionString
        {
            get => this[ConnectionStringKey].ToString();
            set => this[ConnectionStringKey] = value;
        }

        /// <summary>
        ///     Адрес WCF сервиса для приема статусов от ИБД.
        /// </summary>
        [ConfigurationProperty(ReceiveStatusServiceWebAddressKey,
            DefaultValue = "http://localhost:5005/Services/SendMessageResponse.svc",
            IsRequired = true)]
        public string ReceiveStatusServiceWebAddress
        {
            get => this[ReceiveStatusServiceWebAddressKey].ToString();
            set => this[ReceiveStatusServiceWebAddressKey] = value;
        }

        /// <summary>
        ///     Адрес ШЭП-а.
        /// </summary>
        [ConfigurationProperty(ShepWebAddressKey,
            DefaultValue = "http://10.61.40.133:9010/bip-async",
            IsRequired = true)]
        public string ShepWebAddress
        {
            get => this[ShepWebAddressKey].ToString();
            set => this[ShepWebAddressKey] = value;
        }

        /// <summary>
        ///     Путь для хранения логов.
        /// </summary>
        [ConfigurationProperty(LogPathKey, DefaultValue = "..\\logs", IsRequired = true)]
        public string LogPath
        {
            get => this[LogPathKey].ToString();
            set => this[LogPathKey] = value;
        }
        
        /// <summary>
        ///     Максимальный порог размера файла, после достижения которого будет создан
        ///     новый файл для продолжения записи.
        /// </summary>
        [ConfigurationProperty(FileSizeLimitMBytesKey, DefaultValue = 1024, IsRequired = true)]
        public int FileSizeLimitMBytes
        {
            get => (int)this[FileSizeLimitMBytesKey];
            set => this[FileSizeLimitMBytesKey] = value;
        }
    }
}
