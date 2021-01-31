using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;
using Serilog;
using Topshelf;

namespace Intelsoft.Niis.Ibd.Selfhost.HostedServices
{
    public class ReceiveStatusHostedService : ServiceControl
    {
        private readonly IReceiveStatusService _receiveStatusService;
        private readonly NiisIbdSettings _configuration;
        private readonly ILogger _logger;
        private ServiceHost _selfHost;

        public ReceiveStatusHostedService(IReceiveStatusService receiveStatusService, NiisIbdSettings configuration, ILogger logger)
        {
            _receiveStatusService = receiveStatusService ?? throw new ArgumentNullException(nameof(receiveStatusService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool Start(HostControl hostControl)
        {
            try
            {
                // Create a URI to serve as the base address.
                var baseAddress = new Uri(_configuration.ReceiveStatusServiceWebAddress);

                // Create a ServiceHost instance.
                _selfHost = new ServiceHost(_receiveStatusService, baseAddress);

                // Add a service endpoint.
                _selfHost.AddServiceEndpoint(typeof(IReceiveStatusService), new BasicHttpBinding(), "");

                // Enable metadata exchange.
                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                _selfHost.Description.Behaviors.Add(smb);

                // Start the wcf service.
                _selfHost.Open();

                _logger.Information("The receive status service is running.");
                _logger.Information($"The receive service is available at {_configuration.ReceiveStatusServiceWebAddress}");
            }
            catch (Exception e)
            {
                _logger.Error(e, nameof(Start));
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            // Close the ServiceHost to stop the service.
            _selfHost.Close();
            _logger.Information("The receive service was stopped.");
            return true;
        }
    }
}
