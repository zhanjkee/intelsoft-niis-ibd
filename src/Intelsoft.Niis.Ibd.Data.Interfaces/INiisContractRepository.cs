using Intelsoft.Niis.Ibd.Entities;
using System.Collections.Generic;

namespace Intelsoft.Niis.Ibd.Data.Interfaces
{
    public interface INiisContractRepository
    {
        IEnumerable<NiisIbdContractEntity> GetContractEntities(IEnumerable<int> contractIds);
    }
}
