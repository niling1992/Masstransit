using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Event;
using MassTransit;

namespace Masstransit.RabbitMQ.EventSubscriberA
{
    public class GreetingEventConsumerB:IConsumer<GreetingEventB>
    {
        public async Task Consume(ConsumeContext<GreetingEventB> context)
        {
            await Console.Out.WriteLineAsync("receive greeting eventB: id {context.Message.Id}");
        }
    }
}