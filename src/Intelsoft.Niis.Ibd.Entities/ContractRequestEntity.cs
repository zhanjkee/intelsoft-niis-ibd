using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class ContractRequestEntity : EntityBase
    {
        /// <summary>
        ///     Идентификатор.
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        ///     ИИН/БИН.
        /// </summary>
        public string Xin { get; set; }
        
        /// <summary>
        ///     ФИО/Наименование.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Идентификатор объекта интеллектуальной собственности
        /// </summary>
        public int PropertyId { get; set; }
        
        /// <summary>
        ///     Объект интеллектуальной собственности.
        /// </summary>
        public PropertyEntity Property { get; set; }
        
        /// <summary>
        ///     ИИН/БИН правопреемника.
        /// </summary>
        public string AssigneeXin { get; set; }
        
        /// <summary>
        ///     ФИО/Наименование правопреемника.
        /// </summary>
        public string AssigneeName { get; set; }
        
        /// <summary>
        ///     Номер договора о передаче прав.
        /// </summary>
        public string ContractNumber { get; set; }
        
        /// <summary>
        ///     Дата регистрации договора о передаче прав.
        /// </summary>
        public DateTime? ContractRegistrationDate { get; set; }

        public int TypeId { get; set; }
        
        /// <summary>
        ///     Вид договора.
        /// </summary>
        public ContractTypeEntity Type { get; set; }
        
        /// <summary>
        ///     Срок действия договора.
        /// </summary>
        /// <remarks>Если поле пустое, тогда срок действия = срок действия охранного документа.</remarks>        
        public DateTime? ContractValidityDate
        {
            get => _contractValidityDate ?? Property?.ValidityDate ?? default;
            set => _contractValidityDate = value;
        }
        private DateTime? _contractValidityDate;
        
        /// <summary>
        ///     Дата создания записи.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        ///     Дата изменения записи.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        public ContractRequestDispatchStatusEntity DispatchStatus { get; set; }

        public ICollection<ContractRequestMessageMapEntity> Messages { get; set; }

        public void Dispatch()
        {
            DispatchStatus?.Dispatch();
        }
    }
}
