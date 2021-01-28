using Intelsoft.Niis.Ibd.DataAccess.Base;
using Intelsoft.Niis.Ibd.DataAccess.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.DataAccess.Repositories
{
    public class MessageRepository : Repository<MessageEntity> , IMessageRepository
    {
        public MessageRepository([NotNull] IDataContext context) : base(context)
        {
        }
    }
}
