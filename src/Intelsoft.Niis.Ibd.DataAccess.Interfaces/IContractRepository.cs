using System.Linq;
using Intelsoft.Niis.Ibd.DataAccess.Interfaces.Base;
using Intelsoft.Niis.Ibd.Entities;

namespace Intelsoft.Niis.Ibd.DataAccess.Interfaces
{
    public interface IContractRepository : IRepository<ContractEntity>
    {
        IQueryable<ContractEntity> GetAvailableContracts();
        void Dispatched(ContractEntity entity);
    }
}