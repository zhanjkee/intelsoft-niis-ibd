using System.Configuration;
using Intelsoft.Niis.Ibd.Configuration.Base;
using Intelsoft.Niis.Ibd.Validation;

namespace Intelsoft.Niis.Ibd.Data.Configuration
{
    public sealed class ConnectionStringsConfiguration : ConfigurationSection, IConfiguration
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "connectionStringSettings";

        private const string ConnectionStringKey = "connectionString";
        private const string NiisConnectionStringKey = "niisConnectionString";
        private const string UseRetryPolicyKey = "useRetryPolicy";
        private const string MaxRetryAttemptsKey = "maxRetryAttempts";
        private const string PauseBetweenFailuresInMinutesKey = "pauseBetweenFailuresInMinutes";

        /// <summary>
        ///     Строка подключения к базе данных.
        /// </summary>
        [ConfigurationProperty(ConnectionStringKey,
            DefaultValue = "Server=(local);Database=niis_ibd;Trusted_Connection=True;",
            IsRequired = true)]
        [SqlConnectionStringValidator]
        public string ConnectionString
        {
            get => this[ConnectionStringKey].ToString();
            set => this[ConnectionStringKey] = value;
        }

        /// <summary>
        ///     Строка подключения к базе данных.
        /// </summary>
        [ConfigurationProperty(NiisConnectionStringKey,
            DefaultValue = "Server=(local);Database=dbNiis;Trusted_Connection=True;",
            IsRequired = true)]
        [SqlConnectionStringValidator]
        public string NiisConnectionString
        {
            get => this[NiisConnectionStringKey].ToString();
            set => this[NiisConnectionStringKey] = value;
        }


        /// <summary>
        ///     Флаг определяющий, использовать ли политику повтора.
        /// </summary>
        [ConfigurationProperty(UseRetryPolicyKey, IsRequired = true)]
        public bool UseRetryPolicy
        {
            get => (bool) this[UseRetryPolicyKey];
            set => this[UseRetryPolicyKey] = value;
        }

        /// <summary>
        ///     Максимальное количество попыток повтора при возникновени сбоев.
        /// </summary>
        [ConfigurationProperty(MaxRetryAttemptsKey, IsRequired = true)]
        public int MaxRetryAttempts
        {
            get => (int) this[MaxRetryAttemptsKey];
            set => this[MaxRetryAttemptsKey] = value;
        }

        /// <summary>
        ///     Пауза между сбоями при отправке сообщениив ИБД в минутах.
        /// </summary>
        [ConfigurationProperty(PauseBetweenFailuresInMinutesKey, IsRequired = true)]
        public int PauseBetweenFailuresInMinutes
        {
            get => (int) this[PauseBetweenFailuresInMinutesKey];
            set => this[PauseBetweenFailuresInMinutesKey] = value;
        }
    }
}