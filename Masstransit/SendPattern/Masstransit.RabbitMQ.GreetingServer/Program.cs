using System;
using Masstransit.RabbitMQ.Extensions;
using MassTransit;

namespace Masstransit.RabbitMQ.GreetingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Greeting";

            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.GreetingQueue, e =>
                {
                    e.Consumer<GreetingConsumer>();
                    e.Consumer<GreetingConsumerB>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Greeting commands.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();

        }
    }
}
