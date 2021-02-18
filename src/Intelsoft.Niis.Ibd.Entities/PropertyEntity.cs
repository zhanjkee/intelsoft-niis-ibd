using System;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Enums;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class PropertyEntity : EntityBase
    {
        /// <summary>
        ///     Идентификатор.
        /// </summary>
        public int IntellectualPropertyId { get; set; }

        /// <summary>
        ///     Вид объекта.
        /// </summary>
        public PropertyTypeEntity Type { get; set; }

        /// <summary>
        ///     Номер охранного документа.
        /// </summary>
        public string ProtectionNumber { get; set; }

        /// <summary>
        ///     Название объекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Дата регистрации.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        ///     Срок действия охранного документа.
        /// </summary>
        public DateTime ValidityDate { get; set; }
    }
}