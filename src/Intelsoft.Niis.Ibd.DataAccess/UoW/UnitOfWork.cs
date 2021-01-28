using System;
using Intelsoft.Niis.Ibd.DataAccess.Interfaces;
using Intelsoft.Niis.Ibd.DataAccess.Repositories;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;

        public UnitOfWork([NotNull] IDataContextFactory dataContextFactory)
        {
            if (dataContextFactory == null)
                throw new ArgumentNullException(nameof(dataContextFactory));

            _context = dataContextFactory.Create();
        }

        public IContractRepository ContractRepository
        {
            get
            {
                return _contractRepository ?? (_contractRepository = new ContractRepository(_context));
            }
        }
        private IContractRepository _contractRepository;

        public IMessageRepository MessageRepository
        {
            get
            {
                return _messageRepository ?? (_messageRepository = new MessageRepository(_context));
            }
        }
        private IMessageRepository _messageRepository;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
