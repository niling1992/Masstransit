using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Greeting.Message;
using MassTransit;

namespace Masstransit.RabbitMQ.GreetingServer
{
    public class GreetingConsumerB :
    IConsumer<GreetingCommandB>
    {
        public async Task Consume(ConsumeContext<GreetingCommandB> context)
        {

            await Console.Out.WriteLineAsync("receive greeting commmandB: {context.Message.Id},{context.Message.DateTime}");
        }
    }
}