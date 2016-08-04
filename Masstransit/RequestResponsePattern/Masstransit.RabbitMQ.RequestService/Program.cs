using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Extensions;
using Masstransit.RabbitMQ.RequestMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.RequestService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Request Service :");
            var bus = BusCreator.CreateBus((cfg, host) => cfg.ReceiveEndpoint(host, RabbitMqConstants.RequestClientQueue, e =>
            {
                e.Consumer<RequestConsumer>();
            }));

            bus.Start();

            Console.WriteLine("Listening for Request.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
