using System;
using Intelsoft.Niis.Ibd.Selfhost.HostedServices;
using Intelsoft.Niis.Ibd.Selfhost.Jobs;
using Quartz;
using Topshelf;
using Topshelf.Autofac;
using Topshelf.Quartz;

namespace Intelsoft.Niis.Ibd.Selfhost
{
    internal class Program
    {
        private static int Main()
        {
            return (int)HostFactory.Run(app =>
           {
               var container = Global.Instance.Container;

               app.UseSerilog();

               app.UseAutofacContainer(container);

               app.UseAssemblyInfoForServiceInfo();

               app.Service<ReceiveStatusHostedService>(serviceFactory =>
               {
                   serviceFactory.ConstructUsingAutofacContainer();
                   serviceFactory.WhenStarted((service, control) => service.Start(control));
                   serviceFactory.WhenStopped((service, control) => service.Stop(control));

                   serviceFactory.ScheduleQuartzJob(q =>
                       q.WithJob(() =>
                               JobBuilder.Create<ContractSenderJob>().Build())
                           .AddTrigger(() => TriggerBuilder.Create()
                               .WithSimpleSchedule(b => b
                                       // TODO: Вынести интервал в конфиг.
                                   .WithIntervalInSeconds(1)
                                   .RepeatForever())
                               .Build()));
               });

               app.OnException((exception) =>
               {
                   Console.WriteLine("Exception thrown - " + exception.Message);
               });
           });
        }
    }
}
