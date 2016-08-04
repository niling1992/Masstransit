using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.HierarchyMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.MessageSubscriber
{
    public class BaseMessageConsumer:IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            await Console.Out.WriteLineAsync("consumer is BaseMessageConsumer, message type is {context.Message.GetType()}");
        }
    }
}