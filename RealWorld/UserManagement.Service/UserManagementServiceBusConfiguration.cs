using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using UserManagement.Core;
using UserManagement.Events;

namespace UserManagement.Service
{
    public class UserManagementServiceBusConfiguration: BusConfiguration
    {
        private UserManagementServiceBusConfiguration() { }
        public override string RabbitMqAddress { get{return  "rabbitmq://localhost/" ;}set; }
        public override string QueueName {  get{return  "UserManagementServiceQueue";}set; } 
        public override string RabbitMqUserName {  get{return "guest";}set; }
        public override string RabbitMqPassword { get{return "guest";}set; }

        private static IBus _bus;

        public static IBus BusInstance (){
            return _bus ?? (_bus = new UserManagementServiceBusConfiguration().CreateBus());
        }

        public override Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> Configuration
        {
            get
            {
                return (cfg, host) =>
                {
                    cfg.UseRetry(Retry.Interval(3, TimeSpan.FromMinutes(1)));
                    cfg.UseRateLimit(1000, TimeSpan.FromSeconds(1));
                    
                    cfg.ReceiveEndpoint(host, QueueName, e =>
                    {
                        e.Consumer<UserCreatedEventConsumer>();
                        e.Consumer<UserUpdatedEventComsumer>();
                    });
                };
            }
        }

    }
}