using System.Configuration;
using Intelsoft.Niis.Ibd.Configuration.Base;

namespace Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration
{
    public class SerilogConfiguration : ConfigurationSection, IConfiguration
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "serilogSettings";

        private const string LogPathKey = "logPath";
        private const string FileSizeLimitMBytesKey = "fileSizeLimitMBytes";

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
            get => (int) this[FileSizeLimitMBytesKey];
            set => this[FileSizeLimitMBytesKey] = value;
        }
    }
}