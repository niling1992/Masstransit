using System;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;

namespace Masstransit.RabbitMQ.EventSubscriberB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SubscriberB");
            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.GreetingEventSubscriberBQueue, e =>
                {
                    e.Consumer<GreetingEventConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Greeting events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
       

    }
}
