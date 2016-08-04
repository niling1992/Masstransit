using System;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;

namespace Masstransit.RabbitMQ.MessageSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hierarchy message subscriber");
            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.HierarchyMessageSubscriberQueue, e =>
                {
                   e.Consumer<UserUpdatedMessageConsumer>();
                   e.Consumer<BaseInterfaceMessageConsumer>();
                   e.Consumer<BaseMessageConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Hierarchy events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
