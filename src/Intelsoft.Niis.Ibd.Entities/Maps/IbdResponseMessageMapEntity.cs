using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities.Maps
{
    public class IbdResponseMessageMapEntity : EntityBase
    {
        public int IbdResponseId { get; set; }
        public IbdResponseEntity IbdResponse { get; set; }

        public int MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}