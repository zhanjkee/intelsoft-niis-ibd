using Intelsoft.Niis.Ibd.Data.Base;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.Data.Repositories
{
    public class IbdResponseRepository : Repository<IbdResponseEntity>, IIbdResponseRepository
    {
        public IbdResponseRepository([NotNull] IDataContext context) : base(context)
        {
        }
    }
}