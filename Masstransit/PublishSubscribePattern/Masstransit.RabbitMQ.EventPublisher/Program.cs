using System;
using Masstransit.RabbitMQ.Event;
using Masstransit.RabbitMQ.Extensions;

namespace Masstransit.RabbitMQ.EventPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Greeting";

            var bus = BusCreator.CreateBus();
            bus.Start();

            do
            {
                Console.WriteLine("Enter message (or quit to exit)");
                Console.Write("> ");
                string value = Console.ReadLine();

                if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                    break;

                bus.Publish(new GreetingEventA() {Id = Guid.NewGuid(),DateTime = DateTime.Now});
                bus.Publish(new GreetingEventB() {Id = Guid.NewGuid(),DateTime = DateTime.Now});
            } 
            while (true);


            Console.WriteLine("Publish Greeting events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
