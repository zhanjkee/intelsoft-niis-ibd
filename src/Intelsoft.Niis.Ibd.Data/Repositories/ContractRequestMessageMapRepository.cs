using Intelsoft.Niis.Ibd.Data.Base;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities.Maps;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.Data.Repositories
{
    public class ContractRequestMessageMapRepository : Repository<ContractRequestMessageMapEntity>,
        IContractRequestMessageMapRepository
    {
        public ContractRequestMessageMapRepository([NotNull] IDataContext context) : base(context)
        {
        }
    }
}