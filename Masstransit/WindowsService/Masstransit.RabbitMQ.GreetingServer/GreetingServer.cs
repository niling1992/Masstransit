using log4net.Config;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;
using Topshelf.Logging;

namespace Masstransit.RabbitMQ.GreetingServer
{
    public class GreetingServer
    {
        private readonly IBusControl _bus;
        private readonly LogWriter _log = HostLogger.Get<GreetingServer>();

        public GreetingServer()
        {
            _log.Info("register consumer");
            _bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.GreetingQueue, e =>
                {
                    e.Consumer<GreetingConsumer>();
                });
            });
        }

        public void Start()
        {
            _log.Info("start greeting service");
            _bus.Start();
        }

        public void Stop()
        {
            _log.Info("stop greeting service");
            _bus.Stop();
        }
    }
}