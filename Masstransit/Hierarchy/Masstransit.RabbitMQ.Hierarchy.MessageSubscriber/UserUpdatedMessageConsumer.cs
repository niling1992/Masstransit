using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.HierarchyMessage;
using MassTransit;

namespace Masstransit.RabbitMQ.MessageSubscriber
{
    public class UserUpdatedMessageConsumer: IConsumer<UserUpdatedMessage>
    {
        public async Task Consume(ConsumeContext<UserUpdatedMessage> context)
        {
            await Console.Out.WriteLineAsync("consumer is UserUpdatedMessageConsumer,message type is {context.Message.GetType()}");
        }
    }
}