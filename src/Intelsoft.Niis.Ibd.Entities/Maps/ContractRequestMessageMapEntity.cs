using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities.Maps
{
    public class ContractRequestMessageMapEntity : EntityBase
    {
        public int ContractRequestId { get; set; }
        public ContractRequestEntity ContractRequest { get; set; }

        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}
