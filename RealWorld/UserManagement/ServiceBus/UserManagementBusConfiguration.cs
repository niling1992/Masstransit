using System;
using MassTransit;
using MassTransit.Policies;
using MassTransit.RabbitMqTransport;
using UserManagement.Core;

namespace UserManagement.ServiceBus
{
    public class UserManagementBusConfiguration : BusConfiguration
    {
        public override string RabbitMqAddress { get; } = "rabbitmq://localhost/";
        public override string QueueName { get; } = "UserManagementQueue";
        public override string RabbitMqUserName { get; } = "guest";
        public override string RabbitMqPassword { get; } = "guest";
        public override Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> Configuration
        {
            get
            {
                return (cfg, host) =>
                {
                    cfg.UseRetry(Retry.Interval(3, TimeSpan.FromMinutes(1)));

                };
            }
        }

        private static IBus _bus;

        public static IBus BusInstance
        {
            get
            {
                if (_bus == null)
                {
                    _bus = new UserManagementBusConfiguration().CreateBus();
                }

                return _bus;
            }
        }
    }
}