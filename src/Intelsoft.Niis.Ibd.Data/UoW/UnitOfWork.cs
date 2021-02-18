using System;
using Intelsoft.Niis.Ibd.Data.Configuration;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.Repositories;
using JetBrains.Annotations;
using Polly;
using Polly.Retry;

namespace Intelsoft.Niis.Ibd.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConnectionStringsConfiguration _configuration;
        private readonly IDataContext _context;
        private readonly RetryPolicy _soapRetryPolicy;

        public UnitOfWork([NotNull] IDataContextFactory dataContextFactory,
            [NotNull] ConnectionStringsConfiguration configuration)
        {
            if (dataContextFactory == null)
                throw new ArgumentNullException(nameof(dataContextFactory));

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _context = dataContextFactory.Create();

            _soapRetryPolicy = Policy.Handle<Exception>()
                .WaitAndRetry(_configuration.MaxRetryAttempts, i =>
                    TimeSpan.FromMinutes(_configuration.PauseBetweenFailuresInMinutes));

            ContractRepository = new ContractRepository(_context);
            MessageRepository = new MessageRepository(_context);
            IbdResponseRepository = new IbdResponseRepository(_context);
            ContractRequestMessageMapRepository = new ContractRequestMessageMapRepository(_context);
            IbdResponseMessageMapRepository = new IbdResponseMessageMapRepository(_context);
        }

        public IIbdResponseRepository IbdResponseRepository { get; }
        public IContractRequestMessageMapRepository ContractRequestMessageMapRepository { get; }
        public IIbdResponseMessageMapRepository IbdResponseMessageMapRepository { get; }
        public IContractRepository ContractRepository { get; }
        public IMessageRepository MessageRepository { get; }

        public void SaveChanges()
        {
            if (_configuration.UseRetryPolicy)
                _soapRetryPolicy.Execute(() => { _context.SaveChanges(); });
            else _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}