using System;
using Autofac;
using Autofac.Integration.Wcf;
using Intelsoft.Niis.Ibd.Data.Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.WebHost
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            RegisterModules(builder);

            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<ReceiveStatusServiceModule>();
            builder.RegisterModule<DataModule>();
        }
    }
}