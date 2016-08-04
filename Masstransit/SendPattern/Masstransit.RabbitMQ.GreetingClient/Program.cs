using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Extensions;
using Masstransit.RabbitMQ.Greeting.Message;
using MassTransit;

namespace Masstransit.RabbitMQ.GreetingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            var bus = BusCreator.CreateBus();
            var sendToUri = new Uri(RabbitMqConstants.RabbitMqUri+RabbitMqConstants.GreetingQueue);

            while (Console.ReadLine()!=null)
            {
                Task.Run(() => SendCommand(bus, sendToUri)).Wait();

                Task.Run(() => SendCommand2(bus, sendToUri)).Wait();
            }

            Console.ReadLine();
        }

        private static async void SendCommand(IBusControl bus,Uri sendToUri)
        {
            var endPoint =await bus.GetSendEndpoint(sendToUri);
            var command = new GreetingCommandA()
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            await endPoint.Send(command);

            Console.WriteLine("send command:id={" + command.Id + "},{"+command.DateTime+"}");
        }

        private static async void SendCommand2(IBusControl bus, Uri sendToUri)
        {
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            var command = new GreetingCommandB()
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            await endPoint.Send(command);

            Console.WriteLine("send command2:id={command.Id},{command.DateTime}");
        }

    }
}
