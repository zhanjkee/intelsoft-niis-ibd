using System.Linq;
using Intelsoft.Niis.Ibd.Data.Base;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.Data.Repositories
{
    public class ContractRepository : Repository<ContractRequestEntity>, IContractRepository
    {
        public ContractRepository([NotNull] IDataContext context) : base(context)
        {
        }

        public IQueryable<ContractRequestEntity> GetAvailableContracts()
        {
            return GetAll()
                .Where(x => x.Dispatched == false);
        }

        public void Dispatched(ContractRequestEntity entity)
        {
            entity.Dispatch();
        }

        public ContractRequestEntity GetByIds(int contractId, int propertyId)
        {
            return GetAll()
                .Where(x => x.Dispatched == false)
                .FirstOrDefault(x => x.ContractId == contractId && x.PropertyId == propertyId);
        }
    }
}