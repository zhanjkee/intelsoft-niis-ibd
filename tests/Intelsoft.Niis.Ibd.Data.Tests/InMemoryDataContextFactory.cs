using Intelsoft.Niis.Ibd.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data.Tests
{
    public class InMemoryDataContextFactory : IDataContextFactory
    {
        public IDataContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("niis_ibd");
            
            return new DataContext(optionsBuilder.Options);
        }
    }
}
