using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class ContractEntity : EntityBase
    {
        public ContractDispatchStatusEntity DispatchStatus { get; set; }

        public void Dispatch()
        {
            DispatchStatus?.Dispatch();
        }
    }
}
