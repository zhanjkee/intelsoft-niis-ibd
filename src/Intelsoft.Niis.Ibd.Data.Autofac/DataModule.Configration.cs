using Autofac;
using Intelsoft.Niis.Ibd.Data.Configuration;

namespace Intelsoft.Niis.Ibd.Data.Autofac
{
    public partial class DataModule : Module
    {
        public void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => new ConnectionStringsConfigurationReader().Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }
    }
}