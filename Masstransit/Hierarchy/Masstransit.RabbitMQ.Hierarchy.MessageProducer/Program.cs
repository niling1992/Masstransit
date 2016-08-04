using System;
using Masstransit.RabbitMQ.Extensions;
using Masstransit.RabbitMQ.HierarchyMessage;

namespace Masstransit.RabbitMQ.MessageProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hierarchy message producer";

            var bus = BusCreator.CreateBus();
            bus.Start();

            do
            {
                Console.WriteLine("Enter message (or quit to exit)");
                Console.Write("> ");
                string value = Console.ReadLine();

                if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                    break;

                bus.Publish(new UserUpdatedMessage() {Id = Guid.NewGuid(),Type = "User updated"});
                bus.Publish(new UserDeletedMessage() {Id = Guid.NewGuid(),Type = "User deleted"});
            }
            while (true);


            Console.WriteLine("Publish Hierarchy events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
