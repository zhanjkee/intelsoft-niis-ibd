using System.Configuration;
using Intelsoft.Niis.Ibd.Configuration.Base;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Configuration
{
    public class ContractSenderServiceConfiguration : ConfigurationSection, IConfiguration
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "contractSenderServiceSettings";

        private const string ShepWebAddressKey = "shepWebAddress";
        private const string ServiceIdKey = "serviceId";
        private const string SenderIdKey = "senderId";
        private const string PasswordKey = "password";
        private const string NeedToSignXmlKey = "needToSingXml";
        private const string EdsPathKey = "edsPath";
        private const string EdsPasswordKey = "edsPassword";
        private const string UseRetryPolicyKey = "useRetryPolicy";
        private const string MaxRetryAttemptsKey = "maxRetryAttempts";
        private const string PauseBetweenFailuresInMinutesKey = "pauseBetweenFailuresInMinutes";
        private const string PauseBetweenCyclesInMinutesKey = "pauseBetweenCyclesInMinutes";

        /// <summary>
        ///     Адрес ШЭП.
        /// </summary>
        [ConfigurationProperty(ShepWebAddressKey, IsRequired = true)]
        public string ShepWebAddress
        {
            get => this[ShepWebAddressKey].ToString();
            set => this[ShepWebAddressKey] = value;
        }

        /// <summary>
        ///     Идентификатор сервиса.
        /// </summary>
        [ConfigurationProperty(ServiceIdKey, IsRequired = true)]
        public string ServiceId
        {
            get => this[ServiceIdKey].ToString();
            set => this[ServiceIdKey] = value;
        }

        /// <summary>
        ///     Идентификатор отправителя (системы отправителя).
        /// </summary>
        [ConfigurationProperty(SenderIdKey, IsRequired = true)]
        public string SenderId
        {
            get => this[SenderIdKey].ToString();
            set => this[SenderIdKey] = value;
        }

        /// <summary>
        ///     Пароль отправителя.
        /// </summary>
        [ConfigurationProperty(PasswordKey, IsRequired = true)]
        public string Password
        {
            get => this[PasswordKey].ToString();
            set => this[PasswordKey] = value;
        }


        /// <summary>
        ///     Флаг для определения, нужно ли подписывать xml.
        /// </summary>
        [ConfigurationProperty(NeedToSignXmlKey, IsRequired = true)]
        public bool NeedToSignXml
        {
            get => (bool) this[NeedToSignXmlKey];
            set => this[NeedToSignXmlKey] = value;
        }

        /// <summary>
        ///     Путь к ЭЦП.
        /// </summary>
        [ConfigurationProperty(EdsPathKey, IsRequired = true)]
        public string EdsPath
        {
            get => this[EdsPathKey].ToString();
            set => this[EdsPathKey] = value;
        }

        /// <summary>
        ///     Пароль от ЭЦП.
        /// </summary>
        [ConfigurationProperty(EdsPasswordKey, IsRequired = true)]
        public string EdsPassword
        {
            get => this[EdsPasswordKey].ToString();
            set => this[EdsPasswordKey] = value;
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
        ///     Пауза между сбоями при отправке сообщении в ИБД в минутах.
        /// </summary>
        [ConfigurationProperty(PauseBetweenFailuresInMinutesKey, IsRequired = true)]
        public int PauseBetweenFailuresInMinutes
        {
            get => (int) this[PauseBetweenFailuresInMinutesKey];
            set => this[PauseBetweenFailuresInMinutesKey] = value;
        }

        /// <summary>
        ///     Пауза между циклами при отправке сообщении ИБД в минутах.
        /// </summary>
        [ConfigurationProperty(PauseBetweenCyclesInMinutesKey, IsRequired = true)]
        public int PauseBetweenCyclesInMinutes
        {
            get => (int) this[PauseBetweenCyclesInMinutesKey];
            set => this[PauseBetweenCyclesInMinutesKey] = value;
        }
    }
}