using System;
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

        private const string MsSqlConnectionStringKey = "mssqlConnectionString";
     
        /// <summary>
        ///     Строка подключения к бд.
        /// </summary>
        [ConfigurationProperty(MsSqlConnectionStringKey, DefaultValue = "", IsRequired = true)]
        public string MsSqlConnectionString
        {
            get => this[MsSqlConnectionStringKey].ToString();
            set => this[MsSqlConnectionStringKey] = value;
        }
    }
}