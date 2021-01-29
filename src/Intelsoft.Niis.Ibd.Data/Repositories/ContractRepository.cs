using System.Linq;
using Intelsoft.Niis.Ibd.Data.Base;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

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
                .Include(x => x.DispatchStatus)
                .Where(x => x.DispatchStatus.Dispatched == false);
        }

        public void Dispatched(ContractRequestEntity entity)
        {
            entity.Dispatch();
        }
    }
}
