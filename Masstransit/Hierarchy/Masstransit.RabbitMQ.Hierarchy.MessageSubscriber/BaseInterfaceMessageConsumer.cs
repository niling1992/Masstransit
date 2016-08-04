using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.HierarchyMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.MessageSubscriber
{
    public class BaseInterfaceMessageConsumer:IConsumer<IMessage>
    {
        public async Task Consume(ConsumeContext<IMessage> context)
        {
            await Console.Out.WriteLineAsync("consumer is BaseInterfaceMessageConsumer,message type is {context.Message.GetType()}");
        }
    }
}