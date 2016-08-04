using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace UserManagement.Core
{
    public abstract class BusConfiguration
    {
        public abstract string RabbitMqAddress { get; }
        public abstract string QueueName { get; }
        public abstract string RabbitMqUserName { get; }
        public abstract string RabbitMqPassword { get; }
        public abstract Action<IRabbitMqBusFactoryConfigurator,IRabbitMqHost> Configuration { get; }


        public virtual IBus CreateBus()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqAddress), hst =>
                {
                    hst.Username(RabbitMqUserName);
                    hst.Password(RabbitMqPassword);
                });

                Configuration.Invoke(cfg, host);
            });

            return bus;
        }
    }
}