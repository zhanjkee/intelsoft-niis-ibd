using System;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contracts
{
    [Serializable]
    public class ContractType
    {
        public int Id { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }
    }
}
