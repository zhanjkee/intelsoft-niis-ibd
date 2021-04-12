using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Intelsoft.Niis.Ibd.Data.Repositories
{
    public class NiisContractRepository : INiisContractRepository
    {
        private NiisDbContext _niisDbContext;

        public NiisContractRepository(NiisDbContext niisDbContext)
        {
            _niisDbContext = niisDbContext;
        }

        public IEnumerable<NiisIbdContractEntity> GetContractEntities(IEnumerable<int> contractIds)
        {
            var contracts = _niisDbContext.NiisIbdContract.Where(x => contractIds.Contains(x.ContractId)).ToList();

            var contractTypeIds = contracts.Select(x => x.TypeId).Distinct().ToList();
            var contractTypes = _niisDbContext.NiisIbdContractTypes.Where(x => contractTypeIds.Contains(x.Id)).ToList();

            var propertyIds = contracts.Select(x => x.PropertyId).Distinct().ToList();
            var properties = _niisDbContext.NiisIbdProperty
                .Where(x => propertyIds.Contains(x.Id) && x.RegistrationDate.HasValue && x.ValidityDate.HasValue).ToList();

            foreach (var contract in contracts)
            {
                var contractType = contractTypes.FirstOrDefault(x => x.Id == contract.TypeId);
                if (contractType == null) continue;

                contract.Type = contractType;

                var property = properties.FirstOrDefault(x => x.Id == contract.PropertyId);
                if (property == null) continue;

                contract.Property = property;
            }

            return contracts.Where(x => x.Property != null && x.Type != null).ToList();

        }
    }
}
