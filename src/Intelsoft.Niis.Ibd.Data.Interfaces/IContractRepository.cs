using System.Linq;
using Intelsoft.Niis.Ibd.Data.Interfaces.Base;
using Intelsoft.Niis.Ibd.Entities;

namespace Intelsoft.Niis.Ibd.Data.Interfaces
{
    public interface IContractRepository : IRepository<ContractRequestEntity>
    {
        ContractRequestEntity GetByIds(int contractId, int propertyId);
        IQueryable<ContractRequestEntity> GetAvailableContracts();
        void Dispatched(ContractRequestEntity entity);
    }
}