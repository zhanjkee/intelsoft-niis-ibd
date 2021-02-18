using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities.Maps
{
    public class IbdResponseMessageMapEntity : EntityBase
    {
        protected IbdResponseMessageMapEntity()
        {
        }

        public IbdResponseMessageMapEntity(IbdResponseEntity ibdResponse, MessageEntity message)
        {
            IbdResponse = ibdResponse;
            Message = message;
        }

        public int IbdResponseId { get; set; }
        public IbdResponseEntity IbdResponse { get; set; }

        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}