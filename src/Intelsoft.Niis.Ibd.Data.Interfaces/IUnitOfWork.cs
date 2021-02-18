using System;

namespace Intelsoft.Niis.Ibd.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IIbdResponseRepository IbdResponseRepository { get; }
        IContractRequestMessageMapRepository ContractRequestMessageMapRepository { get; }
        IIbdResponseMessageMapRepository IbdResponseMessageMapRepository { get; }
        IContractRepository ContractRepository { get; }
        IMessageRepository MessageRepository { get; }

        void SaveChanges();
    }
}