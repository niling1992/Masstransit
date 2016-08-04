using System;
using System.Threading.Tasks;
using Masstransit.RabbitMQ.Event;
using MassTransit;

namespace Masstransit.RabbitMQ.EventSubscriberB
{
    public class GreetingEventConsumer:IConsumer<GreetingEventA>
    {
        public async Task Consume(ConsumeContext<GreetingEventA> context)
        {
            await Console.Out.WriteLineAsync("receive greeting eventA: id {context.Message.Id}");
        }
    }
}