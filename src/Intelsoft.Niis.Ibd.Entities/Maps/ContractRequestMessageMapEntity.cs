using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities.Maps
{
    public class ContractRequestMessageMapEntity : EntityBase
    {
        protected ContractRequestMessageMapEntity()
        {

        }

        public ContractRequestMessageMapEntity(ContractRequestEntity contractRequest, MessageEntity message)
        {
            ContractRequest = contractRequest;
            Message = message;
        }

        public int ContractRequestId { get; set; }
        public ContractRequestEntity ContractRequest { get; set; }

        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}
