using System;

namespace Intelsoft.Niis.Ibd.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContractRepository ContractRepository { get; }
        IMessageRepository MessageRepository { get; }

        void SaveChanges();
    }
}