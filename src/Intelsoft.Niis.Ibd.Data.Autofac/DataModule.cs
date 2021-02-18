using Autofac;

namespace Intelsoft.Niis.Ibd.Data.Autofac
{
    public partial class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConfiguration(builder);
            RegisterDataContext(builder);
            RegisterUnitOfWork(builder);
        }
    }
}