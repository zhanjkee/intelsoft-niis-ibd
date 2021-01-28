using System.Linq;
using Intelsoft.Niis.Ibd.DataAccess.Base;
using Intelsoft.Niis.Ibd.DataAccess.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.DataAccess.Repositories
{
    public class ContractRepository : Repository<ContractEntity>, IContractRepository
    {
        public ContractRepository([NotNull] IDataContext context) : base(context)
        {
        }

        public IQueryable<ContractEntity> GetAvailableContracts()
        {
            return GetAll()
                .Include(x => x.DispatchStatus)
                .Where(x => x.DispatchStatus.Dispatched == false);
        }

        public void Dispatched(ContractEntity entity)
        {
            entity.Dispatch();
        }
    }
}
