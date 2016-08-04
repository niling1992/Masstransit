using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Extensions;
using Masstransit.RabbitMQ.RequestMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.RequestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            var bus = BusCreator.CreateBus();
            bus.Start();

            var client = CreateRequestClient(bus);

            for (;;)
            {
                Console.Write("Enter customer id (quit exits): ");
                string customerId = Console.ReadLine();
                if (customerId == "quit")
                    break;

                // this is run as a Task to avoid weird console application issues
                Task.Run(async () =>
                {
                    var response = await client.Request(new SimpleRequest() {CustomerId = customerId});

                    Console.WriteLine("Customer Name: {0}", response.CusomerName);
                }).Wait();
            }


        }

        private static IRequestClient<ISimpleRequest, ISimpleResponse> CreateRequestClient(IBusControl busControl)
        {
            var serviceAddress = new Uri("{RabbitMqConstants.RabbitMqUri}{RabbitMqConstants.RequestClientQueue}");
            var client =busControl.CreateRequestClient<ISimpleRequest, ISimpleResponse>(serviceAddress, TimeSpan.FromSeconds(10));
            return client;
        }
    }
}
