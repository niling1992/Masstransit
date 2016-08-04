using System;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;

namespace Masstransit.RabbitMQ.EventSubscriberA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SubscriberA");
            var bus = BusCreator.CreateBus((cfg, host) => cfg.ReceiveEndpoint(host, RabbitMqConstants.GreetingEventSubscriberAQueue, e =>
            {
                e.Consumer<GreetingEventConsumerA>();
                e.Consumer<GreetingEventConsumerB>();
            }));

            bus.Start();

            Console.WriteLine("Listening for Greeting events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
       

    }
}
